using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ValueConverterSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }


        public double Temperature { get; set; } = 21;
        public double ChanceOfRain { get; set; } = 90;

        double windSpeed = 10;

        public double WindSpeed
        {
            get => windSpeed;
            set
            {
                windSpeed = value;
                OnPropertyChanged(nameof(WindSpeed));
            }
        }

        public MainPageViewModel()
        {
        }

        public ICommand CheckWeatherCommand => new Command(async () =>
        {
            IsBusy = true;
            await Task.Delay(1000);
            var rand = new Random();

            Temperature = rand.Next(15, 25);
            ChanceOfRain = rand.Next(0, 100);
            OnPropertyChanged(nameof(Temperature));
            OnPropertyChanged(nameof(ChanceOfRain));
            IsBusy = false;

        });

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
