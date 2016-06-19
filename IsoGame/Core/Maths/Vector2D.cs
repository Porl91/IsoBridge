using ProductiveRage.Immutable;
using System;

namespace IsoGame.Core.Maths
{
	public class Vector2D : IAmImmutable
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public Vector2D(double x = 0, double y = 0)
		{
			this.CtorSet(_ => _.X, x);
			this.CtorSet(_ => _.Y, y);
		}

		#region Arithmetic functions

		public Vector2D Add(Vector2D other)
		{
			return new Vector2D(X + other.X, Y + other.Y);
		}

		public Vector2D Subtract(Vector2D other)
		{
			return new Vector2D(X - other.X, Y - other.Y);
		}

		public Vector2D Multiply(Vector2D other)
		{
			return new Vector2D(X * other.X, Y * other.Y);
		}

		public Vector2D Divide(Vector2D other)
		{
			return new Vector2D(X / other.X, Y / other.Y);
		}

		#endregion

		public double Dot(Vector2D other)
		{
			return X * other.X + Y * other.Y;
		}

		public double Cross(Vector2D other)
		{
			return X * other.Y - other.X * Y;
		}

		public double LengthSquared()
		{
			return Dot(this);
		}

		public double Length()
		{
			return Math.Sqrt(LengthSquared());
		}

		public Vector2D Normalise()
		{
			var recip = 1.0 / Length();
			return new Vector2D(X * recip, Y * recip);
		}

		#region Operator overloads

		public static Vector2D operator +(Vector2D v1, Vector2D v2)
		{
			return v1.Add(v2);
		}

		public static Vector2D operator -(Vector2D v1, Vector2D v2)
		{
			return v1.Subtract(v2);
		}

		public static Vector2D operator *(Vector2D v1, Vector2D v2)
		{
			return v1.Multiply(v2);
		}

		public static Vector2D operator /(Vector2D v1, Vector2D v2)
		{
			return v1.Divide(v2);
		}

		#endregion
	}
}
