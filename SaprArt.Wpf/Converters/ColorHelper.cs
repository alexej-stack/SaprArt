using System.Windows.Media;

namespace SaprArt.Wpf.Converters;

public static class ColorHelper
{
	public static Color FromHex(string hexString)
	{
		if (string.IsNullOrEmpty(hexString))
		{
			return new Color();
		}

		hexString = hexString.TrimStart('#');

		byte a = 255;
		byte r, g, b;

		if (hexString.Length == 8)
		{
			a = byte.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			hexString = hexString.Substring(2);
		}

		r = byte.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		g = byte.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		b = byte.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

		return Color.FromArgb(a, r, g, b);
	}

	public static string ToHex(Color color, bool includeAlpha = false)
	{
		var alphaHex = includeAlpha ? color.A.ToString("X2") : string.Empty;
		var redHex = color.R.ToString("X2");
		var greenHex = color.G.ToString("X2");
		var blueHex = color.B.ToString("X2");

		return $"#{alphaHex}{redHex}{greenHex}{blueHex}";
	}
}