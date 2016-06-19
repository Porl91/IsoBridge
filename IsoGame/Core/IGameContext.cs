namespace IsoGame.Core
{
	public interface IGameContext
	{
		IRenderContext RenderContext { get; }

		void Start();
		void Update();
		void Render();
	}
}
