@echo off
net stop winmgmt /y
echo Copying DLL
xcopy "CLEVOMOF.dll" "%windir%\SysWOW64" /y
echo Installing DLL
regsvr32 /s "%windir%\SysWOW64\CLEVOMOF.dll"
echo Adding to registry
regedit /s "ClevoWMI.reg"
net start winmgmt
echo Done