using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using HelperLibrary.B_Entity;

namespace HelperLibrary.B_Data
{
    public class PSHelper
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PSHelper()
        {
        }

        /// <summary>
        /// Set-Up azure account for PowerShell
        /// </summary>
        /// <returns>Command Output</returns>
        public string SetupAzureUsingRunspace()
        {
            string output = string.Empty;
            List<string> lstVmOsImages = new List<string>();

            try
            {
                Command command = new Command(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/AzureSetup.ps1"));
                Collection<PSObject> psResult = RunPowerShellScript(command, out output);
                if (psResult != null)
                {
                    foreach (PSObject obj in psResult)
                    {
                        PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                        foreach (PSPropertyInfo propInfo in propInfos.Where(prop => (prop.Value != null)))
                        {
                            output = string.Format("{0}{1}\t{2}{3}",
                                output, propInfo.Value.ToString(), propInfo.Name, Environment.NewLine);
                        }
                    }
                }
                else
                {
                    lstVmOsImages.Add(output);
                }
            }
            catch (Exception ex)
            {
                output = string.Format("{0}Error{1}{2}", output, Environment.NewLine, ex.Message);
            }

            return output;
        }

        /// <summary>
        /// Gets Azure OS images using PowerShell
        /// </summary>
        /// <returns>list of Azure OS Images</returns>
        public List<string> GetAzureImages()
        {
            string output = string.Empty;
            List<string> lstVmOsImages = new List<string>();

            try
            {
                Collection<PSObject> psResult = new Collection<PSObject>();

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("Get-AzureVMImage | Select ImageName");

                    psResult = PowerShellInstance.Invoke();

                    if (psResult.Count > 0)
                    {
                        foreach (PSObject psObject in psResult)
                        {
                            PSMemberInfoCollection<PSPropertyInfo> propInfos = psObject.Properties;
                            foreach (PSPropertyInfo propInfo in propInfos.Where(prop => (prop.Value != null)))
                            {
                                lstVmOsImages.Add(propInfo.Value.ToString());
                            }
                        }
                    }
                    else
                    {
                        lstVmOsImages = GetAzureImagesUsingRunspace();
                    }
                }
            }
            catch (Exception ex)
            {
                lstVmOsImages = new List<string>();
                lstVmOsImages.Add(string.Format("Error occurred while getting list of OS Images. {0}", ex.Message));
            }
            return lstVmOsImages;
        }

        /// <summary>
        /// Create VM
        /// </summary>
        /// <param name="vmDetails">Details of VM</param>
        /// <returns>VM Creation Result Message</returns>
        public string CreateVM(VMDetails vmDetails)
        {
            string errMsg = string.Empty;
            try
            {
                Command cmdCreateVM = new Command(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/CreateVM.ps1"));

                CommandParameter Imagename = new CommandParameter("imageName", vmDetails.ImageName);
                cmdCreateVM.Parameters.Add(Imagename);
                CommandParameter VmName = new CommandParameter("vmName", vmDetails.VMName);
                cmdCreateVM.Parameters.Add(VmName);
                CommandParameter InstanceSize = new CommandParameter("instanceSize", vmDetails.InstanceSize);
                cmdCreateVM.Parameters.Add(InstanceSize);
                CommandParameter serviceName = new CommandParameter("serviceName", vmDetails.ServiceName);
                cmdCreateVM.Parameters.Add(serviceName);
                CommandParameter userName = new CommandParameter("userName", vmDetails.UserName);
                cmdCreateVM.Parameters.Add(userName);
                CommandParameter Password = new CommandParameter("Password", vmDetails.Password);
                cmdCreateVM.Parameters.Add(Password);
                CommandParameter Location = new CommandParameter("Location", vmDetails.Location);
                cmdCreateVM.Parameters.Add(Location);

                Collection<PSObject> psResult = RunPowerShellScript(cmdCreateVM, out errMsg);

                if (psResult.Count > 0)
                {
                    return "VM Created Successfully....  Username: " + vmDetails.UserName + "  Password: " + vmDetails.Password;
                }
                else
                {
                    return errMsg;
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Gets Azure OS images using PowerShell using Runspace
        /// </summary>
        /// <returns>list of Azure OS Images</returns>
        private List<string> GetAzureImagesUsingRunspace()
        {
            string output = string.Empty;
            List<string> lstVmOsImages = new List<string>();

            try
            {
                Command command = new Command(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/GetImages.ps1"));
                Collection<PSObject> psResult = RunPowerShellScript(command, out output);

                if (psResult != null)
                {
                    foreach (PSObject obj in psResult)
                    {
                        PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                        foreach (PSPropertyInfo propInfo in propInfos.Where(prop => (prop.Value != null)))
                        {
                            lstVmOsImages.Add(propInfo.Value.ToString());
                            //output = string.Format("{0}{1}\t{2}{3}",
                            //    output, propInfo.Value.ToString(), propInfo.Name, Environment.NewLine);
                        }
                    }
                }
                else
                {
                    lstVmOsImages.Add(output);
                }
            }
            catch (Exception ex)
            {
                lstVmOsImages.Add(string.Format("{0}Error{1}{2}", output, Environment.NewLine, ex.Message));
            }

            return lstVmOsImages;
        }

        /// <summary>
        /// Runs the command returns the output in collection of objects
        /// </summary>
        /// <param name="command">PowerShell command object</param>
        /// <param name="errMsg">Error Message if any</param>
        /// <returns>Output in collection of objects</returns>
        private Collection<PSObject> RunPowerShellScript(Command command, out string errMsg)
        {
            errMsg = string.Empty;

            Collection<PSObject> psResult = new Collection<PSObject>();

            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            Pipeline pipeline = runspace.CreatePipeline();

            pipeline.Commands.Add(command);
            try
            {
                runspace.Open();
                psResult = pipeline.Invoke();
            }
            catch (Exception ex)
            {
                errMsg = string.Format("Error while running script '{0}' : {1}",
                    command.CommandText.Substring(command.CommandText.LastIndexOf("/")), ex.Message);
                psResult = null;
            }
            finally
            {
                runspace.Close();
            }

            return psResult;
        }
    }
}