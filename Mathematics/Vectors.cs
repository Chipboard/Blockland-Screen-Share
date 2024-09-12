namespace BLSS.Mathematics
{
    public struct Vectors(float x, float y, float z)
    {
        public float x = x, y = y, z = z;

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }

    public struct Vector3Int(int x, int y, int z)
    {
        public int x = x, y = y, z = z;

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }

    public struct Vector2(float x, float y)
    {
        public float x = x, y = y;

        public override string ToString()
        {
            return $"{x} {y}";
        }
    }

    public struct Vector2Int(int x, int y)
    {
        public int x = x, y = y;

        public override string ToString()
        {
            return $"{x} {y}";
        }
    }
}
