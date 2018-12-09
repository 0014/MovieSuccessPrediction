using System.Windows.Forms;
using IMDB.Controller;

namespace IMDB.View
{
    public partial class Form1 : Form
    {
        private MainController _controller;

        public Form1()
        {
            InitializeComponent();

            _controller = new MainController();

            _controller.Test2();
        }


    }
}
