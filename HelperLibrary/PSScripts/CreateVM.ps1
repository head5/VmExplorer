param (

        [Parameter(Mandatory=$true)]
        [string] $imageName = $null,

        [Parameter(Mandatory=$true)]
        [string] $vmName = $null,

        [Parameter(Mandatory=$true)]
        [string] $serviceName = $null,


        [Parameter(Mandatory=$true)]
        [string] $instanceSize = $null,
        
        [Parameter(Mandatory=$true)]
        [string] $userName = $null,

        [Parameter(Mandatory=$true)]
        [string] $Password = $null,

        [Parameter(Mandatory=$true)]
        [string] $Location = $null        

                
)

Set-AzureSubscription -SubscriptionId d4732b22-2544-4835-b65e-5ad5b7f42c27 -CurrentStorageAccountName portalvhdssbm9zt69dcv0q

$VM= New-AzureVMConfig -Name $vmName -InstanceSize $instanceSize -Image $imageName |
       Add-AzureProvisioningConfig -Windows -AdminUserName $userName -Password $Password     

 New-AzureVM -ServiceName $serviceName -Location "$Location" -VMs $VM

