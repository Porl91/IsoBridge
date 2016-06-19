using ProductiveRage.Immutable;
using System;

namespace IsoGame.Core
{
	public class Map : IAmImmutable
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int[] MapData { get; private set; }

		public Map(int width, int height, Func<int, int, int> tileMapper)
		{
			this.CtorSet(_ => _.Width, width);
			this.CtorSet(_ => _.Height, height);
			this.CtorSet(_ => _.MapData, GetMap(width, height, tileMapper));
		}

		private int[] GetMap(int width, int height, Func<int, int, int> tileMapper)
		{
			var mapData = new int[width * height];

			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < width; x++)
				{
					mapData[y * width + x] = tileMapper(x, y);
				}
			}

			return mapData;
		}

		public int GetMapTileTypeId(int x, int y)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
				return 0;

			return MapData[y * Width + x];
		}
	}
}
