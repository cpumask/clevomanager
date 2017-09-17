namespace ClevoManager.Common
{
    public class Color
    {
        public byte Red   = 255;
        public byte Green = 255;
        public byte Blue  = 255;

        public Color()
        {
        }

        public Color( byte r, byte g, byte b )
        {
            Red   = r;
            Green = g;
            Blue  = b;
        }

        public uint GetPackedValue()
        {
            return (uint)( ( Blue << 16 ) + ( Red << 8 ) + Green );
        }
    }
}
