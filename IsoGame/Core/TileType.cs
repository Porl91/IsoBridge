using ProductiveRage.Immutable;

namespace IsoGame.Core
{
	public class TileType : IAmImmutable
	{
		public int SpriteX { get; private set; }
		public int SpriteY { get; private set; }
		public int SpriteWidth { get; private set; }
		public int SpriteHeight { get; private set; }

		public static readonly int TileWidth = 64;
		public static readonly int TileHeight = 32;

		public TileType(int xSprite, int ySprite, int spriteWidth, int spriteHeight)
		{
			this.CtorSet(_ => _.SpriteX, xSprite);
			this.CtorSet(_ => _.SpriteY, ySprite);
			this.CtorSet(_ => _.SpriteWidth, spriteWidth);
			this.CtorSet(_ => _.SpriteHeight, spriteHeight);
		}

		public void Render(IRenderContext renderContext, int xScreen, int yScreen)
		{
			renderContext.DrawImage(SpriteX, SpriteY, xScreen, yScreen, SpriteWidth, SpriteHeight);
		}
	}
}
