using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using IMDB.Model;
using IMDB.View;
using SharpLearning.CrossValidation.CrossValidators;
using SharpLearning.DecisionTrees.Learners;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Regression;
using SharpLearning.RandomForest.Learners;
using SharpLearning.RandomForest.Models;

namespace IMDB.Controller
{
    public class MainController
    {
        public List<CleanDataModel> Data;
        public ClassificationForestModel Model;

        public void Test()
        {
            // Use StreamReader(filepath) when running from filesystem
            var trainer = new CsvParser(() => new StringReader(File.ReadAllText(@"D:\Workspace\MovieSuccessPrediction\IMDB\Resources\CleanData.train.int.csv")), ',');
            var targetName = "Success";

            // read feature matrix
            var observations = trainer.EnumerateRows("StaringActorId", "ActorAgeGapId", "WriterId", "GenreId")
                .ToF64Matrix();

            // read regression targets
            var targets = trainer.EnumerateRows(targetName)
                .ToF64Vector();

            // create learner
            var learner = new RegressionDecisionTreeLearner();

            // learns a RegressionDecisionTreeModel
            var model = learner.Learn(observations, targets);

            var tester = new CsvParser(() => new StringReader(File.ReadAllText(@"D:\Workspace\MovieSuccessPrediction\IMDB\Resources\CleanData.test.int.csv")), ',');
            observations = tester.EnumerateRows("StaringActorId", "ActorAgeGapId", "WriterId", "GenreId")
                .ToF64Matrix();
            targets = tester.EnumerateRows(targetName)
                .ToF64Vector();
            
            //get results and compare to actual ones
            var result = model.Predict(observations);
            double success = 0, failure = 0;
            for (var i = 0; i < targets.Length; i++)
            {
                if (result[i] == targets[i])
                    success++;
                else
                    failure++;
            }

            double rate = success / (success + failure) * 100;

            Console.WriteLine($@"Success : {success}, Failure: {failure}");
        }

        public MetricModel Train()
        {
            // Use StreamReader(filepath) when running from filesystem
            var trainer = new CsvParser(() => new StringReader(File.ReadAllText(@"C:\Workspace\MovieSuccessPrediction\IMDB\Resources\CleanData.int.csv")), ',');

            // read feature matrix
            var observations = trainer.EnumerateRows("StaringActorId", "ActorAgeGapId", "WriterId", "GenreId")
                .ToF64Matrix();

            // read regression targets
            var targetName = "Success";
            var targets = trainer.EnumerateRows(targetName)
                .ToF64Vector();

            // creates cross validator, observations are shuffled randomly
            var cv = new RandomCrossValidation<double>(crossValidationFolds: 5, seed: 1000);

            // create learner
            var learner = new ClassificationExtremelyRandomizedTreesLearner();

            // cross-validated predictions
            var cvPredictions = cv.CrossValidate(learner, observations, targets);

            // metric for measuring model error
            var metric = new MeanSquaredErrorRegressionMetric();

            // cross-validation provides an estimate on how the model will perform on unseen data
            Console.WriteLine("Cross-validation error: " + metric.Error(targets, cvPredictions));

            // train and predict training set for comparison. 
            Model = learner.Learn(observations, targets);
            var predictions = Model.Predict(observations);

            // The training set is NOT a good estimate of how well the model will perfrom on unseen data. 
            Console.WriteLine("Training error: " + metric.Error(targets, predictions));

            var result = new MetricModel {Predictions = predictions};
            for (var i = 0; i < targets.Length; i++)
            {
                if (predictions[i] == targets[i])
                {
                    if (predictions[i] == 1)
                    {
                        result.TP++;
                    }
                    else
                    {
                        result.TN++;
                    }
                }
                else
                {
                    if (predictions[i] == 1)
                    {
                        result.FP++;
                    }
                    else
                    {
                        result.FN++;
                    }
                }
            }

            return result;
        }

        public double Predict(double[] observations)
        {
            return Model.Predict(observations);
        }

        public List<CleanDataModel> GetDataTable()
        {
            var fileName = @"C:\Workspace\MovieSuccessPrediction\IMDB\Resources\CleanData.xlsx";
            var constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                         fileName +
                         ";Extended Properties='Excel 12.0 XML;HDR=NO;IMEX=1';";

            var con = new OleDbConnection(constr);
            var oconn = new OleDbCommand("Select * From [CleanData$]", con);
            con.Open();

            var sda = new OleDbDataAdapter(oconn);
            var data = new DataTable();
            sda.Fill(data);
            data = FixColumnNames(data);

            Data = (from rw in data.AsEnumerable()
                select new CleanDataModel()
                {
                    //ID = Convert.ToInt32(rw["ID"]),
                    //Name = Convert.ToString(rw["Name"])
                    Id = Convert.ToInt32(rw["Id"]),
                    Title = Convert.ToString(rw["Title"]),
                    StaringActorId = Convert.ToInt32(rw["StaringActorId"]),
                    StaringActor = Convert.ToString(rw["StaringActor"]),
                    ActorAgeGapId = Convert.ToInt32(rw["ActorAgeGapId"]),
                    AgeGapDefinition = Convert.ToString(rw["AgeGapDefinition"]),
                    WriterId = Convert.ToInt32(rw["WriterId"]),
                    Writer = Convert.ToString(rw["Writer"]),
                    Genres = Convert.ToString(rw["Genres"]),
                    GenreId = Convert.ToInt32(rw["GenreId"]),
                    NumberOfVotes = Convert.ToInt32(rw["NumberOfVotes"]),
                    Rating = Convert.ToString(rw["Rating"]),
                    Success = Convert.ToInt32(rw["Success"])
                }).ToList();

            
            return Data;
        }

        private DataTable FixColumnNames(DataTable data)
        {
            foreach (DataColumn column in data.Columns)
            {
                var cName = data.Rows[0][column.ColumnName].ToString();
                if (!data.Columns.Contains(cName) && cName != "")
                {
                    column.ColumnName = cName;
                }

            }
            data.Rows[0].Delete();
            data.AcceptChanges();

            return data;
        }
    }
}
