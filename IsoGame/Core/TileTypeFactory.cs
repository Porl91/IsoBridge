using ProductiveRage.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsoGame.Core
{
	public class TileTypeFactory : IAmImmutable
	{
		public Dictionary<int, TileType> TileTypes { get; private set; }

		public TileTypeFactory(Dictionary<int, TileType> tileTypes)
		{
			this.CtorSet(_ => _.TileTypes, tileTypes);
		}

		public TileType GetTileType(int id)
		{
			if (!TileTypes.Any())
				throw new InvalidOperationException("No tile types were created during initialisation.");

			if (!TileTypes.ContainsKey(id))
				return TileTypes.FirstOrDefault().Value;

			return TileTypes[id];
		}
	}
}
