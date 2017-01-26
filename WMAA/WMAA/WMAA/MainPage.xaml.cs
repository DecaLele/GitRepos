using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WMAA
{
    public partial class MainPage : ContentPage
    {
        public string MessageStatus { get; set; }

        public MainPage()
        {
            MessageStatus = "Initializing...";
            InitializeComponent();
        }

        private async void btnCamera_Click(object sender, EventArgs e)
        {

        }

        private async void btnGallery_Click(object sender, EventArgs e)
        {

        }
    }
}
