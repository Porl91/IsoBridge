using Bridge.Html5;
using ProductiveRage.Immutable;

namespace IsoGame.Core
{
	class RenderContext: IRenderContext, IAmImmutable
	{
		public HTMLCanvasElement Canvas { get; private set; }
		public CanvasRenderingContext2D Context { get; private set; }
		public HTMLImageElement Image { get; private set; }

		public RenderContext(HTMLCanvasElement canvas, HTMLImageElement image)
		{
			this.CtorSet(_ => _.Canvas, canvas);
			this.CtorSet(_ => _.Context, canvas.GetContext("2d"));
			this.CtorSet(_ => _.Image, image);
		}

		public void ResizeCanvas(int width, int height)
		{
			Canvas.Width = width;
			Canvas.Height = height;
		}

		public void DrawImage(int xScreen, int yScreen, int xImage, int yImage, int width, int height)
		{
			Context.DrawImage(
				Image, 
				xScreen, yScreen, width, height, 
				xImage, yImage, width, height
			);
		}
	}
}
