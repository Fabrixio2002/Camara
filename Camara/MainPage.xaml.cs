using Xamarin.Essentials;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Camara
{
    public partial class MainPage : ContentPage
    {
        public Command GrabarVideoCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            GrabarVideoCommand = new Command(async () => await GrabarVideo());
            BindingContext = this;
        }





        private async Task GrabarVideo()
        {
            try
            {
                var options = new Microsoft.Maui.Media.MediaPickerOptions
                {
                    Title = "Grabar video"
                };

                var video = await Microsoft.Maui.Media.MediaPicker.CaptureVideoAsync(options);

                // Aquí puedes hacer algo con el video grabado, como guardarlo en el almacenamiento local o subirlo a un servidor.
                // Por ejemplo, mostrar una alerta con la ubicación del video:
                await DisplayAlert("Video grabado", $"El video fue grabado en: {video.FullPath}", "Aceptar");
            }
            catch (Microsoft.Maui.ApplicationModel.FeatureNotSupportedException)
            {
                // La funcionalidad no es soportada en este dispositivo
                await DisplayAlert("Error", "La grabación de video no es soportada en este dispositivo.", "Aceptar");
            }
            catch (Microsoft.Maui.ApplicationModel.PermissionException)
            {
                // El usuario no otorgó permiso para acceder a la cámara
                await DisplayAlert("Error", "No tienes permiso para acceder a la cámara.", "Aceptar");
            }
            catch (Exception ex)
            {
                // Otra excepción ocurrió
                await DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "Aceptar");
            }
        }
    }
}
