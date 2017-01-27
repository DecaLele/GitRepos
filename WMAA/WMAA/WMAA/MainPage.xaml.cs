using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Connectivity;

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
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", "No camera awailable.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = String.Concat("WMAA", DateTime.Now.ToString("ddMMyyyyHHmmss"), ".jpg")
            });
            if (file == null)
            { return; }

            SetPictureSource(file);
        }

        private async void btnGallery_Click(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No upload", "Picking a photo in not supported", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
            { return; }

            SetPictureSource(file);
        }
            
        private void SetPictureSource(Plugin.Media.Abstractions.MediaFile file)
        {
            this.Indicator.IsVisible = true;
            this.Indicator.IsRunning = true;
            Picture.Source = ImageSource.FromStream(() => file.GetStream());
            this.Indicator.IsRunning = false;
            this.Indicator.IsVisible = false;
        }
    }
}
