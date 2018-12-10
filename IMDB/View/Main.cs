using System.Windows.Forms;
using IMDB.Controller;

namespace IMDB.View
{
    public partial class Form1 : Form
    {
        private readonly MainController _controller;

        public Form1()
        {
            InitializeComponent();

            _controller = new MainController();
        }

        private void btnTrain_Click(object sender, System.EventArgs e)
        {
            var metric = _controller.Train();


        }

        private void DisplayFormulas()
        {

        }
    }
}
