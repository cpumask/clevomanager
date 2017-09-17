using ClevoManager;
using ClevoManager.Managers;
using ClevoManager.Common;

namespace TestApp
{
    class Program
    {
        static void Main( string[] args )
        {
            Manager clevoManager = new Manager();

            KeyboardManager keyboardManager = clevoManager.KeyboardManager;
            keyboardManager.SetLightOn();
            keyboardManager.SetLightBrightness( KeyboardManager.BrightnessLevel.Low );
            keyboardManager.SetLightColor( new Color( 0, 0, 255 ), KeyboardManager.LightPart.All );
            keyboardManager.SetLightBrightness( KeyboardManager.BrightnessLevel.High );
            keyboardManager.SetLightMode( KeyboardManager.LightMode.Breathe );
            keyboardManager.SetLightOff();
        }
    }
}
