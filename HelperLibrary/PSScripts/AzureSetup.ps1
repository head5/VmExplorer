#$storageDir = $PSScriptRoot
#$a=Get-WmiObject -Class Win32_Product |Select Name | Where {$_.Name -Match "Microsoft Azure PowerShell"}

#if($a -eq $null)
#{
 #   webpicmd.exe /install /accepteula /products:WindowsAzurePowershell
#}

#sleep -Seconds 60
#$a=Get-WmiObject -Class Win32_Product |Select Name | Where {$_.Name -Match "Microsoft Azure PowerShell"}

#if($a -ne $null)
#{
   Import-Module "D:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell\ServiceManagement\Azure\Azure.psd1"
   $userName = "head5@achiever100outlook.onmicrosoft.com"
   $securePassword = ConvertTo-SecureString -String "achiever12!@" -AsPlainText -Force
   $cred = New-Object System.Management.Automation.PSCredential($userName, $securePassword)
   Add-AzureAccount -Credential $cred
  
#}