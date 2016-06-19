using IsoGame.Core.Maths;

namespace IsoGame.Core
{
	public class Camera
	{
		public Vector2D Position { get; private set; }

		public Camera(Vector2D position)
		{
			Position = position;
		}

		public void Move(Vector2D delta)
		{
			Position = Position + delta;
		}
	}
}
