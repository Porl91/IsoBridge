using Bridge.Html5;
using IsoGame.Core;
using IsoGame.Core.Maths;
using System.Collections.Generic;

namespace IsoGame
{
    public class App
    {
		[Ready]
		public static void Main()
		{
			var canvas = (HTMLCanvasElement)Document.GetElementById("scene");
			var image = new HTMLImageElement();
			image.Src = "/Content/Images/Sprites.png";
			image.OnLoad += e =>
			{
				var renderContext = new RenderContext(canvas, image);
				var camera = new Camera(new Vector2D(0, 0));
				var map = new Map(10, 10, (x, y) => 1);
				var tileTypeFactory = new TileTypeFactory(
					new Dictionary<int, TileType>
					{
						{ 0, new TileType(64, 0, 64, 32) },
						{ 1, new TileType(0, 0, 64, 32) },
					}
				);

				Window.OnLoad = Window.OnResize = ev =>
				{
					renderContext.ResizeCanvas(Window.InnerWidth, Window.InnerHeight);
				};

				new GameContext(renderContext, map, tileTypeFactory, camera).Start();
			};
		}
    }
}
