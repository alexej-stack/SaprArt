using Point = SaprArt.Core.Point;
using Rectangle = SaprArt.Core.Rectangle;

namespace SaprArt.Infrastructure;

public static class RectangleGenerator
{
	private static readonly Random Random = new Random();

	public static IEnumerable<Rectangle> GenerateRandomRectangles(int count, IList<string> avalableColrs, double minX,
		double minY, double maxX, double maxY)
	{
		var rectangles = new List<Rectangle>();

		for (int i = 0; i < count; i++)
		{
			var color = avalableColrs[Random.Next(avalableColrs.Count)];

			double x1 = Random.NextDouble() * (maxX - minX) + minX;
			double y1 = Random.NextDouble() * (maxY - minY) + minY;
			double x2 = Random.NextDouble() * (maxX - minX) + minX;
			double y2 = Random.NextDouble() * (maxY - minY) + minY;

			var bottomLeft = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
			var topRight = new Point(Math.Max(x1, x2), Math.Max(y1, y2));

			rectangles.Add(new Rectangle(color, bottomLeft, topRight));
		}

		return rectangles;
	}
}