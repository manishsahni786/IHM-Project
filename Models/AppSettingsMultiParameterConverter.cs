using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MireWpf.Models
{
    public class AppSettingsCommandParameters
    {
        public string settingName { get; set; }
        public bool value { get; set; }
    }

    public class AppSettingsMultiParameterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type Target_Type, object Parameter, CultureInfo culture)
        {
            var findCommandParameters = new AppSettingsCommandParameters();
            findCommandParameters.settingName = (string)values[0];
            findCommandParameters.value = (bool)values[1];
            return findCommandParameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AppSettingsIntCommandParameters
    {
        public string settingName { get; set; }
        public int intValue { get; set; }
    }

    public class AppSettingsIntMultiParameterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type Target_Type, object Parameter, CultureInfo culture)
        {
            var findCommandParameters = new AppSettingsIntCommandParameters();
            findCommandParameters.settingName = (string)values[0];
            findCommandParameters.intValue = (int)values[1];
            return findCommandParameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
