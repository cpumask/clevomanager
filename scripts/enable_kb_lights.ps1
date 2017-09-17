$clevo = get-wmiobject -query "select * from CLEVO_GET" -namespace "root\WMI"
$clevo.SetKBLED(3758616583)