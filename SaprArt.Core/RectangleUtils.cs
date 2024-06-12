using System.Drawing;

namespace SaprArt.Core;

public static class RectangleUtils
{
	public static Rectangle FindBoundingRectangle(
		IEnumerable<Rectangle> rectangles,
		IEnumerable<string> ignoreColors = null,
		IEnumerable<string> includeColors = null,
		bool ignoreOutOfBounds = false,
		Rectangle mainRectBounds = null)
	{
		double minX = double.MaxValue;
		double minY = double.MaxValue;
		double maxX = double.MinValue;
		double maxY = double.MinValue;

		foreach (var rect in rectangles)
		{
			if (ignoreColors != null && ignoreColors.Contains(rect.Color))
			{
				continue;
			}

			if (includeColors != null && !includeColors.Contains(rect.Color))
			{
				continue;
			}

			if (ignoreOutOfBounds && mainRectBounds != null)
			{
				if (rect.BoltLeft.X < mainRectBounds.BoltLeft.X || rect.BoltLeft.Y < mainRectBounds.BoltLeft.Y ||
				    rect.TopRight.X > mainRectBounds.TopRight.X || rect.TopRight.Y > mainRectBounds.TopRight.Y)
				{
					continue;
				}
			}

			minX = Math.Min(minX, rect.BoltLeft.X);
			minY = Math.Min(minY, rect.BoltLeft.Y);
			maxX = Math.Max(maxX, rect.TopRight.X);
			maxY = Math.Max(maxY, rect.TopRight.Y);
		}

		return new Rectangle("#000000", new Point(minX, minY), new Point(maxX, maxY));
	}
}