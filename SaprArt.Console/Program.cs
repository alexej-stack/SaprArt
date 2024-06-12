// See https://aka.ms/new-console-template for more information

using SaprArt.Core;
using SaprArt.Infrastructure;
using Point = SaprArt.Core.Point;
using Rectangle = SaprArt.Core.Rectangle;

Logger.SetupLogging(logToFile: true);
var availableColors = new List<string> { "#38761d", "#f44336", "#2986cc" };
var rectangles = RectangleGenerator.GenerateRandomRectangles(10, availableColors, 0, 0, 100, 100);
//var rectangles = new List<Rectangle>
//{
//	new(Color.Crimson, new Point(1, 2), new Point(4, 5)),
//	new(Color.Blue, new Point(2, 3), new Point(5, 6)),
//	new(Color.Green, new Point(3, 1), new Point(6, 4)),
//};
foreach (var rectangle in rectangles)
{
	Logger.Log(rectangle.ToString());
}

var ignoreColors = new List<string> { "#38761d" };
var includeColors = new List<string> { "#f44336", "#2986cc" };
var mainRectBounds = new Rectangle("#000000", new Point(0, 0), new Point(100, 100));
var boundingRect = RectangleUtils.FindBoundingRectangle(
	rectangles,
	ignoreColors: ignoreColors,
	includeColors: includeColors,
	ignoreOutOfBounds: true,
	mainRectBounds: mainRectBounds);
Logger.Log($"Bounding rectangle: {boundingRect}");