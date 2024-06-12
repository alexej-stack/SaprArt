using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaprArt.Core;
using Rectangle = SaprArt.Core.Rectangle;
using Point = SaprArt.Core.Point;
using SaprArt.Infrastructure;

namespace SaprArt.Wpf;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty] private ObservableCollection<Rectangle> rectangles;
	private readonly IList<string> availableColors;
	[ObservableProperty] private ObservableCollection<string> ignoreColors;
	[ObservableProperty] private ObservableCollection<string> includeColors;

	[RelayCommand]
	private Task GenerateRectangles()
	{
		rectangles.Clear();
		var boundRectangle = new Rectangle("#000000", new Point(10, 10), new Point(990, 990));
		rectangles.Add(boundRectangle);
		var rects =
			new ObservableCollection<Rectangle>(
				RectangleGenerator.GenerateRandomRectangles(10, availableColors, 0, 0, 1000, 1000));
		foreach (var rectangle in rects)
		{
			rectangles.Add(rectangle);
			Logger.Log(rectangle.ToString());
		}

		return Task.CompletedTask;
	}

	[RelayCommand]
	private Task EvaluateBoundRectangle()
	{
		ignoreColors = ["#38761d"];
		includeColors = ["#f44336", "#2986cc"];
		var initBound = rectangles.First();
		rectangles.RemoveAt(0);
		var boundRectangle = RectangleUtils.FindBoundingRectangle(
			rectangles,
			ignoreColors: ignoreColors,
			includeColors: includeColors,
			ignoreOutOfBounds: true,
			mainRectBounds: initBound);
		rectangles.Add(boundRectangle);
		Logger.Log($"Bounding rectangle: {boundRectangle}");
		return Task.CompletedTask;
	}

	public MainViewModel()
	{
		rectangles = new ObservableCollection<Rectangle>();
		Logger.SetupLogging(logToFile: true);
		availableColors = new List<string> { "#38761d", "#f44336", "#2986cc" };
	}
}