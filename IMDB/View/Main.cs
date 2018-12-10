using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using IMDB.Controller;
using IMDB.Model;

namespace IMDB.View
{
    public partial class Form1 : Form
    {
        private readonly MainController _controller;

        public Form1()
        {
            InitializeComponent();

            _controller = new MainController();
            LoadData();
        }

        private void LoadData()
        {
            gridView1.Columns.Clear();
            gridControl1.DataSource = _controller.GetDataTable();
        }

        private void DisplayFormulas(MetricModel metric)
        {
            panelFormulaResults.Visible = true;

            var accuracy = (metric.TP + metric.TN) / (metric.TP + metric.FP + metric.TN + metric.FN);
            var error = (metric.FP + metric.FN) / (metric.TP + metric.FP + metric.TN + metric.FN);
            var recall = metric.TP / (metric.TP + metric.FN);
            var specificity = metric.TN / (metric.FP + metric.TN);
            var precision = metric.TP / (metric.TP + metric.FP);
            var f = 2 * precision * recall / (precision + recall);
            var fBeta = (1 + 0.5 * 0.5) * precision * recall / (0.5 * 0.5 * precision + recall);

            lblTp.Text = metric.TP.ToString();
            lblTp2.Text = metric.TP.ToString();
            lblTp3.Text = metric.TP.ToString();
            lblFp.Text = metric.FP.ToString();
            lblFn.Text = metric.FN.ToString();
            lblTn.Text = metric.TN.ToString();
            lblTn2.Text = metric.TN.ToString();
            lblTpAddFp.Text = $@"{metric.TP} + {metric.FP}";
            lblFpAddFn.Text = $@"{metric.FP} + {metric.FN}";
            lblTpAddFp2.Text = (metric.TP + metric.FP).ToString();
            lblFnAddTn.Text = (metric.FN + metric.TN).ToString();
            lblTpAddFn.Text = (metric.TP + metric.FN).ToString();
            lblFpAddTn.Text = (metric.FP + metric.TN).ToString();
            lblTpAddTn.Text = $@"{metric.TP} + {metric.TN}";
            lblPAddN.Text = (metric.TP + metric.FP + metric.TN + metric.FN).ToString();
            lblPAddN2.Text = (metric.TP + metric.FP + metric.TN + metric.FN).ToString();
            lblTotal.Text = (metric.TP + metric.FP + metric.TN + metric.FN).ToString();
            lblP.Text = (metric.TP + metric.FN).ToString();
            lblN.Text = (metric.FP + metric.TN).ToString();
            lbl2xPrecisionxRecall.Text = $@"2 x {precision:0.##} x {recall:0.##}";
            lblPrecisionAddRecall.Text = $@"{precision:0.##} + {recall:0.##}";
            lbl1AddBetta2xPrecisionxRecall.Text = $@"(1 + 0.5²) x {precision:0.##} x {recall:0.##}";
            lblBeta2xPrecisionxRecall.Text = $@"0.5² x {precision:0.##} + {recall:0.##}";

            lblAccuracy.Text = accuracy.ToString("0.##");
            lblErrorRate.Text = error.ToString("0.##");
            lblRecall.Text = recall.ToString("0.##");
            lblSpecificity.Text = specificity.ToString("0.##");
            lblPrecision.Text = precision.ToString("0.##");
            lblF.Text = f.ToString("0.##");
            lblFBeta.Text = fBeta.ToString("0.##");

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            var metric = _controller.Train();

            DisplayFormulas(metric);

            gridView1.Columns[2].AppearanceCell.BackColor = Color.LightGreen;
            gridView1.Columns[4].AppearanceCell.BackColor = Color.LightGreen;
            gridView1.Columns[6].AppearanceCell.BackColor = Color.LightGreen;
            gridView1.Columns[9].AppearanceCell.BackColor = Color.LightGreen;

            gridView1.Columns[12].AppearanceCell.BackColor = Color.SandyBrown;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var form = new PredictionEntry(_controller) {Visible = true};

            form.Closing += Closing;
        }

        private void Closing(object sender, EventArgs e)
        {
            //gridView1.Columns.Clear();
            gridControl1.DataSource = _controller.Data;
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var view = sender as GridView;

            var id = view?.GetRowCellValue(e.RowHandle, "Id");

            if (id == null)
                return;

            if ((int) id > 5412)
            {
                if ((int)view?.GetRowCellValue(e.RowHandle, "Success") == 1)
                    e.Appearance.BackColor = Color.DarkSeaGreen;
                else
                    e.Appearance.BackColor = Color.IndianRed;
            }
            
        }
    }
}
