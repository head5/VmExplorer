using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using WebRole.B_Entity;

namespace WebRole.B_Data
{
    public class PSHelper
    {
        Collection<PSObject> results = null;
        static RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
        Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration); 
        public PSHelper()
        { 
        
        }

        public List<String> GetAzureImages(out string errormsg)
        {
            errormsg = null;
            List<String> ImageList = new List<string>();
            Collection<PSObject> result = null;
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("Get-AzureVMImage |Select ImageName");
                    result = PowerShellInstance.Invoke();
                    while (result.Count == 0)
                    {
                        result = PowerShellInstance.Invoke();

                    }

                    foreach (PSObject obj in result)
                    {
                        PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                        foreach (PSPropertyInfo propInfo in propInfos)
                        {
                            string propInfoValue = (propInfo.Value == null) ? "" : propInfo.Value.ToString();
                            ImageList.Add(propInfoValue);
                        }

                    }
                }
                return ImageList;
            }
            catch (Exception ex)
            {
                errormsg = ex.Message.ToString();
            }            
            return null;
        }

        public String createVM(VMDetails vmDetails)
        {

            try
            {
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                String scriptfile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/CreateVM.ps1");
                Command myCommand = new Command(scriptfile);

                CommandParameter Imagename = new CommandParameter("imageName", vmDetails.ImageName);
                myCommand.Parameters.Add(Imagename);
                CommandParameter VmName = new CommandParameter("vmName", vmDetails.VMName);
                myCommand.Parameters.Add(VmName);
                CommandParameter InstanceSize = new CommandParameter("instanceSize", vmDetails.VMSize);
                myCommand.Parameters.Add(InstanceSize);                
                CommandParameter serviceName = new CommandParameter("serviceName", vmDetails.ServiceName);
                myCommand.Parameters.Add(serviceName);
                CommandParameter userName = new CommandParameter("userName", vmDetails.UserName);
                myCommand.Parameters.Add(userName);
                CommandParameter Password = new CommandParameter("Password", vmDetails.Passowrd);
                myCommand.Parameters.Add(Password);
                CommandParameter Location = new CommandParameter("Location", vmDetails.Location);
                myCommand.Parameters.Add(Location);
                
                pipeline.Commands.Add(myCommand);
                results = pipeline.Invoke();
                return "VM Created Successfully....  Username: " + vmDetails.UserName + "  Password: " + vmDetails.Passowrd + results.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public string SetupAzure()
        {
            String str = null;
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // this script has a sleep in it to simulate a long running script                   
                String scriptfile = System.Web.HttpContext.Current.Server.MapPath("App_Data/AzureSetup.ps1");
                PowerShellInstance.AddScript(scriptfile);

                // begin invoke execution on the pipeline
                Collection<PSObject> result = PowerShellInstance.Invoke();
                foreach (PSObject obj in result)
                {
                    PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                    foreach (PSPropertyInfo propInfo in propInfos)
                    {
                        string propInfoValue = (propInfo.Value == null) ? "" : propInfo.Value.ToString();
                        str += propInfoValue + "    " + propInfo.Name + "\n";
                    }
                }
            }
            return str;
        }
   
    }
}