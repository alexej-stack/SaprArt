using SaprArt.Core;
using SaprArt.Infrastructure;
using Point = SaprArt.Core.Point;
using Rectangle = SaprArt.Core.Rectangle;

Logger.SetupLogging(logToFile: true);
var availableColors = new List<string> { "#38761d", "#f44336", "#2986cc" };
var rectangles = RectangleGenerator.GenerateRandomRectangles(10, availableColors, 0, 0, 100, 100);
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