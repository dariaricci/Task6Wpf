using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task6Wpf
{
    enum Precipitation
    {
        Sunny = 0,
        Cloudy = 1,
        Rainy = 2,
        Snow = 3

    }
    class WeatherControl : DependencyObject
    {
        public string WindDir { get; set; }
        public int WindSpeed{ get; set; }
        public Precipitation precipitation;

        public WeatherControl(string windDir, int windSpeed, Precipitation precipitation)
        {
            WindDir = windDir;
            WindSpeed = windSpeed;
            this.precipitation = precipitation;
        }

        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
            nameof(TemperatureProperty),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));

        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
                return t;
            else
                return 0;
        }
    }
}
