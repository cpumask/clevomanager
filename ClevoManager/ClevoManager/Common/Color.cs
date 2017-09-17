namespace ClevoManager.Common
{
    public class Color
    {
        public static readonly Color BLACK      = new Color(   0,   0,   0 );
        public static readonly Color WHITE      = new Color( 255, 255, 255 );
        public static readonly Color RED        = new Color( 255,   0,   0 );
        public static readonly Color GREEN      = new Color(   0, 255,   0 );
        public static readonly Color BLUE       = new Color(   0,   0, 255 );
        public static readonly Color YELLOW     = new Color( 255, 255,   0 );
        public static readonly Color MAGENTA    = new Color( 255,   0, 255 );
        public static readonly Color CYAN       = new Color(   0, 255, 255 );

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
