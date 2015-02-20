mkdir C:\Resources\temp\Source
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "(wget -Outfile "C:\Resources\temp\Source\azure-powershell.0.8.11.msi" "http://az412849.vo.msecnd.net/downloads03/azure-powershell.0.8.11.msi")"
msiexec /i C:\Resources\temp\Source\azure-powershell.0.8.11.msi PROPERTY=VALUE /quiet