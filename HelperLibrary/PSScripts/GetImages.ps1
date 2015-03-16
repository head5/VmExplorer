  Import-Module "C:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell\ServiceManagement\Azure\Azure.psd1"
  $userName = "head5@achiever100outlook.onmicrosoft.com"
  $securePassword = ConvertTo-SecureString -String "achiever12!@" -AsPlainText -Force
  $cred = New-Object System.Management.Automation.PSCredential($userName, $securePassword)
  $null = Add-AzureAccount -Credential $cred
  Get-AzureVMImage | Select ImageName