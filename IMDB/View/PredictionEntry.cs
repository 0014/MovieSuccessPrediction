using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMDB.Controller;
using IMDB.Model;

namespace IMDB.View
{
    public partial class PredictionEntry : Form
    {
        private readonly MainController _controller;

        public PredictionEntry(MainController controller)
        {
            InitializeComponent();

            _controller = controller;
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            var data = _controller.Data.OrderBy(o => o.Id).ToList();

            var actors = data.Select(_ => new ActorModel
            {
                ActorId = _.StaringActorId ?? 0,
                Actor = _.StaringActor
            }).GroupBy(i => new { i.ActorId, i.Actor })
            .Select(i => i.First()).ToList();

            cmbActors.Properties.DataSource = actors;
            cmbActors.Properties.DisplayMember = "Actor";

            var writers = data.Select(_ => new WriterModel
            {
                WriterId = _.WriterId ?? 0,
                Writer = _.Writer
            }).GroupBy(i => new { i.WriterId, i.Writer })
            .Select(i => i.First()).ToList();

            cmbWriter.Properties.DataSource = writers;
            cmbWriter.Properties.DisplayMember = "Writer";

            var ageGaps = data.Select(_ => new AgeGapModel
            {
                AgeGapId = _.ActorAgeGapId ?? 0,
                AgeGap = _.AgeGapDefinition
            }).GroupBy(i => new { i.AgeGapId, i.AgeGap })
            .Select(i => i.First()).ToList();

            cmbAgeGap.Properties.DataSource = ageGaps;
            cmbAgeGap.Properties.DisplayMember = "AgeGap";

            var genres = data.Select(_ => new GenreModel()
            {
                GenreId = _.GenreId ?? 0,
                Genre = _.Genres
            }).GroupBy(i => new { i.GenreId, i.Genre })
            .Select(i => i.First()).ToList();

            cmbGenre.Properties.DataSource = genres;
            cmbGenre.Properties.DisplayMember = "Genre";
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            var id = _controller.Data.OrderByDescending(o => o.Id).Select(_ => _.Id).First() + 1;

            //"StaringActorId", "ActorAgeGapId", "WriterId", "GenreId"
            var success = _controller.Predict(new double[]
            {
                ((ActorModel) cmbActors.EditValue).ActorId,
                ((AgeGapModel) cmbAgeGap.EditValue).AgeGapId,
                ((WriterModel) cmbWriter.EditValue).WriterId,
                ((GenreModel) cmbGenre.EditValue).GenreId
            });

            var entry = new CleanDataModel
            {
                Id = id,
                Title = "_Prediction_",
                NumberOfVotes = 0,
                Rating = "",
                ActorAgeGapId = ((AgeGapModel)cmbAgeGap.EditValue).AgeGapId,
                AgeGapDefinition = ((AgeGapModel)cmbAgeGap.EditValue).AgeGap,
                GenreId = ((GenreModel)cmbGenre.EditValue).GenreId,
                Genres = ((GenreModel)cmbGenre.EditValue).Genre,
                StaringActor = ((ActorModel)cmbActors.EditValue).Actor,
                StaringActorId = ((ActorModel)cmbActors.EditValue).ActorId,
                Writer = ((WriterModel)cmbWriter.EditValue).Writer,
                WriterId = ((WriterModel)cmbWriter.EditValue).WriterId,
                Success = (int)success
            };
            _controller.Data.Insert(0, entry);

            Close();
        }

        private void PredictionEntry_Load(object sender, EventArgs e)
        {
            cmbActors.ItemIndex = 0;
            cmbWriter.ItemIndex = 0;
            cmbAgeGap.ItemIndex = 0;
            cmbGenre.ItemIndex = 0;
        }
    }
}
