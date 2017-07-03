using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfSlider
{
  public sealed class NumberToTimeConverter : IValueConverter
  {
    public bool IsReversed { get; set; }
    public bool UseHidden { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      double number = Math.Round((double)value, 0);
      double newNumber = number + number;
      string val = number.ToString() + " + " + number.ToString() + " = " + newNumber.ToString();
      return val;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
