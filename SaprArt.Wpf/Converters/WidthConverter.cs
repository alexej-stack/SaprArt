using System.Globalization;
using System.Windows.Data;

namespace SaprArt.Wpf.Converters;

public class WidthConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is double topRightX && values[1] is double bottomLeftX)
		{
			return topRightX - bottomLeftX;
		}

		throw new ArgumentException("Invalid values passed to WidthConverter");
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}