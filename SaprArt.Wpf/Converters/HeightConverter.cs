using System.Globalization;
using System.Windows.Data;

namespace SaprArt.Wpf.Converters;

public class HeightConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values is [double topRightY, double bottomLeftY])
		{
			return topRightY - bottomLeftY;
		}

		throw new ArgumentException("Invalid values passed to HeightConverter");
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}