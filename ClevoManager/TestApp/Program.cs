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
            //keyboardManager.SetLightOn();
            //keyboardManager.SetLightMode( KeyboardManager.LightMode.Custom );
            //keyboardManager.SetLightColor( Color.MAGENTA, KeyboardManager.LightPart.All );
            //keyboardManager.SetLightColor( Color.MAGENTA, KeyboardManager.LightPart.Mid );
            //keyboardManager.SetLightBrightness( KeyboardManager.BrightnessLevel.Low );
            //keyboardManager.SetLightBrightness( KeyboardManager.BrightnessLevel.High );
            keyboardManager.SetLightOff();
        }
    }
}
