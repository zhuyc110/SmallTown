using System.Numerics;
using System.Runtime.CompilerServices;

namespace SmallTown.Infrastructure
{
    public static class Matrix3x2Extensions
    {
        public static Vector2 GetDimension(this Matrix3x2 matrix, int row)
        {
            var vrow = Unsafe.Add(ref Unsafe.As<float, Vector2>(ref matrix.M11), row);
            return vrow;
        }
    }
}