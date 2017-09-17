using ClevoManager.Common;
using System;
using System.Collections.Generic;

namespace ClevoManager.Managers
{
    public class KeyboardManager : ResourceManager
    {
        private class Functions
        {
            internal const string SetKBLED = "SetKBLED";
        }

        private class Keys
        {
            internal const uint LigthOn         = 0xE007F007;
            internal const uint LightOff        = 0xE0003000;
            internal const uint LeftPart        = 0xF0000000;
            internal const uint MidPart         = 0xF1000000;
            internal const uint RightPart       = 0xF2000000;
            internal const uint LightbarPart    = 0xF3000000;
            internal const uint LogoPart        = 0xF4000000;
            internal const uint Brightness      = 0xF4000000;
            internal const uint ModeRandom      = 0x70000000;
            internal const uint ModeBreathe     = 0x1002A000;
            internal const uint ModeCycle       = 0x33010000;
            internal const uint ModeWave        = 0xB0000000;
            internal const uint ModeDance       = 0x80000000;
            internal const uint ModeTempo       = 0x90000000;
            internal const uint ModeFlash       = 0xA0000000;
        }

        public enum LightMode : byte
        {
            Random  = 0,
            Custom  = 1,
            Breathe = 2,
            Cycle   = 3,
            Wave    = 4,
            Dance   = 5,
            Tempo   = 6,
            Flash   = 7,
        }

        [Flags]
        public enum LightPart : uint
        {
            Left     = 1 << 1,
            Mid      = 2 << 1,
            Right    = 3 << 1,
            Lightbar = 4 << 1,
            Logo     = 5 << 1,

            All      = Left | Mid | Right | Lightbar | Logo,
        }

        public enum BrightnessLevel : uint
        {
            Off  =   0,
            Low  =  63,
            Mid  = 127,
            High = 255,
        }

        private Dictionary<LightPart, uint> _partsKeys = new Dictionary<LightPart, uint>();
        private Dictionary<LightMode, uint> _modesKeys = new Dictionary<LightMode, uint>();

        internal KeyboardManager( Manager manager )
            : base( manager )
        {
            _partsKeys[LightPart.Left    ] = Keys.LeftPart;
            _partsKeys[LightPart.Mid     ] = Keys.MidPart;
            _partsKeys[LightPart.Right   ] = Keys.RightPart;
            _partsKeys[LightPart.Lightbar] = Keys.LightbarPart;
            _partsKeys[LightPart.Logo    ] = Keys.LogoPart;

            _modesKeys[LightMode.Random ] = Keys.ModeRandom;
            _modesKeys[LightMode.Breathe] = Keys.ModeBreathe;
            _modesKeys[LightMode.Cycle  ] = Keys.ModeCycle;
            _modesKeys[LightMode.Wave   ] = Keys.ModeWave;
            _modesKeys[LightMode.Dance  ] = Keys.ModeDance;
            _modesKeys[LightMode.Tempo  ] = Keys.ModeTempo;
            _modesKeys[LightMode.Flash  ] = Keys.ModeFlash;
        }

        public void SetLightOn( LightPart part = LightPart.All )
        {
            _manager.InvokeMethod( Functions.SetKBLED, Keys.LigthOn );
        }

        public void SetLightOff()
        {
            _manager.InvokeMethod( Functions.SetKBLED, Keys.LightOff );
        }
        public void SetLightBrightness( BrightnessLevel level )
        {
            _manager.InvokeMethod( Functions.SetKBLED, (uint)level | Keys.Brightness );
        }

        public void SetLightColor( Color color, LightPart part = LightPart.All )
        {
            uint colorValue = color.GetPackedValue();

            foreach( var partKey in _partsKeys )
            {
                if( ( part & partKey.Key ) == partKey.Key )
                {
                    _manager.InvokeMethod( Functions.SetKBLED, colorValue | partKey.Value );
                }
            }
        }

        public void SetLightMode( LightMode mode )
        {
            if( mode == LightMode.Custom )
            {
                return;
            }

            _manager.InvokeMethod( Functions.SetKBLED, _modesKeys[mode] );
        }
    }
}
