using Bridge.Html5;
using ProductiveRage.Immutable;
using System;

namespace IsoGame.Core
{
	public class GameContext : IGameContext
	{
		public IRenderContext RenderContext { get; private set; }
		public Map Map { get; private set; }
		public TileTypeFactory TileTypeFactory { get; private set; }
		public Camera Camera { get; private set; }

		public GameContext(
			IRenderContext renderContext, 
			Map map, 
			TileTypeFactory tileTypeFactory, 
			Camera camera
		)
		{
			RenderContext = renderContext;
			Map = map;
			TileTypeFactory = tileTypeFactory;
			Camera = camera;
		}

		public void Start()
		{
			GameLoop();
			Window.SetInterval(() => GameLoop(), 20);
		}

		private void GameLoop()
		{
			Update();
			Render();
		}

		public void Update()
		{
		}

		public void Render()
		{
			var viewportWidth = 1000;
			var viewportHeight = 500;
			var tilesInWidth = Math.Floor(viewportWidth / (double)TileType.TileWidth);
			var tilesInHeight = Math.Floor(viewportHeight / (double)(TileType.TileHeight >> 1));
			var halfTileWidth = TileType.TileWidth >> 1;
			var halfTileHeight = TileType.TileHeight >> 1;

			for(var y = 0; y < tilesInHeight; y++)
			{
				for(var x = 0; x < tilesInWidth; x++)
				{
					var xScreen = x * TileType.TileWidth - (y & 1) * halfTileWidth;
					var yScreen = y * halfTileHeight;
					var xMap = (int)Math.Floor(x + y * 0.5);
					var yMap = -(int)Math.Floor(x - y * 0.5);
					var tileTypeId = Map.GetMapTileTypeId(xMap, yMap);
					TileTypeFactory.GetTileType(tileTypeId).Render(RenderContext, xScreen, yScreen);
				}
			}
		}
	}
}
