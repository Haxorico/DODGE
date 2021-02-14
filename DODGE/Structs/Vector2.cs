using System.Runtime.InteropServices;

namespace DODGE.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public int X, Y;
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
