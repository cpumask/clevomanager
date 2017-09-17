using ClevoManager.Managers;
using Microsoft.Win32;
using System;
using System.Management;

namespace ClevoManager
{
    public class Manager
    {
        private ManagementObject _managementObject;

        #region Managers
        public KeyboardManager KeyboardManager { get; private set; }
        #endregion

        public Manager()
        {
            try
            {
                CheckMofReg();
            }
            catch( Exception )
            {
            }

            Init();
        }

        private void Init()
        {
            _managementObject = new ManagementObject( "root\\WMI", "CLEVO_GET.InstanceName='ACPI\\PNP0C14\\0_0'", null );
            
            // Managers //
            KeyboardManager = new KeyboardManager( this );
        }

        private void CheckMofReg()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\WmiAcpi\\", true);
                string a = registryKey.GetValue("MofImagePath", "").ToString();
                if( string.IsNullOrWhiteSpace( a ) || a != "syswow64\\clevomof.dll" )
                {
                    registryKey.SetValue( "MofImagePath", "syswow64\\clevomof.dll", RegistryValueKind.String );
                }
                registryKey.Close();
            }
            catch
            {
            }
        }

        public void InvokeMethod( string name, uint data )
        {
            var inParams = _managementObject.GetMethodParameters( name );
            inParams["Data"] = data;
            var outParams = _managementObject.InvokeMethod( name, inParams, null );
        }
    }
}
