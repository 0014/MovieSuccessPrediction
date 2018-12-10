using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMDB.Model;
using IMDB.Properties;
using SharpLearning.Containers.Matrices;
using SharpLearning.CrossValidation.CrossValidators;
using SharpLearning.DecisionTrees.Learners;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Regression;
using SharpLearning.RandomForest.Learners;

namespace IMDB.Controller
{
    public class MainController
    {
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
            var trainer = new CsvParser(() => new StringReader(File.ReadAllText(@"D:\Workspace\MovieSuccessPrediction\IMDB\Resources\CleanData.int.csv")), ',');

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
            var predictions = learner.Learn(observations, targets).Predict(observations);

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

            var accuracy = (result.TP + result.TN) / predictions.Length * 100;
            return result;
        }
    }
}
