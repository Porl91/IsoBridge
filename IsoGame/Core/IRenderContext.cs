using Bridge.Html5;

namespace IsoGame.Core
{
	public interface IRenderContext
	{
		HTMLCanvasElement Canvas { get; }
		CanvasRenderingContext2D Context { get; }
		HTMLImageElement Image { get; }
		void DrawImage(int xScreen, int yScreen, int xImage, int yImage, int width, int height);
		void ResizeCanvas(int width, int height);
	}
}
