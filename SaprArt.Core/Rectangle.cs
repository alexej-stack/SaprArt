namespace SaprArt.Core;

public class Rectangle(string color, Point boltLeft, Point topRight)
{
	public string Color { get; } = color;
	public Point BoltLeft { get; } = boltLeft;
	public Point TopLeft { get; } = new Point(boltLeft.X, topRight.Y);
	public Point BoltRight { get; } = new Point(topRight.X, boltLeft.Y);
	public Point TopRight { get; } = topRight;

	public override string ToString()
	{
		return
			$"Rectangle(Color={Color}, Coords=[{BoltLeft.X}, {BoltLeft.Y},{TopLeft.X}, {TopLeft.Y},{TopRight.X}, {TopRight.Y},{BoltRight.X}, {BoltRight.Y}]";
	}
}