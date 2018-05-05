using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cloud_Insights.DAL
{
    class DAL_GetInfo
    {
        public static string LocalIPAddress()
        {
            string localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
        public static  string GetMotherboardID()
        {
            string result = string.Empty;
            ManagementObjectSearcher objectSearcher =new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection collect = objectSearcher.Get();

            foreach (ManagementObject o in objectSearcher.Get())
            {
                result = o["SerialNumber"].ToString();
            }
            return result;
        }

        public static void getProcessorInfo()
        {
            MessageBox.Show("d 3");

            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Name"] != null)
                {
                    if (DAL_Composant.composant(Program.UUIDMachine, managementObject["DeviceID"].ToString()) == true)
                    {
                         if (managementObject["AddressWidth"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"AddressWidth", managementObject["AddressWidth"].ToString(), Program.iplocal);
                         }
                         if (managementObject["Architecture"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Architecture", managementObject["Architecture"].ToString(), Program.iplocal);
                         }
                         if (managementObject["Availability"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Availability", managementObject["Availability"].ToString(), Program.iplocal);
                         }
                         if (managementObject["Caption"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Caption", managementObject["Caption"].ToString(), Program.iplocal);
                         }
                         if (managementObject["CpuStatus"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant, "CpuStatus",managementObject["CpuStatus"].ToString(), Program.iplocal);
                         }
                         if (managementObject["CreationClassName"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"CreationClassName", managementObject["CreationClassName"].ToString(), Program.iplocal);
                         }
                         if (managementObject["CurrentClockSpeed"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant, "CurrentClockSpeed", managementObject["CurrentClockSpeed"].ToString(), Program.iplocal);
                         }
                         if (managementObject["CurrentVoltage"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant, "CurrentVoltage",managementObject["CurrentVoltage"].ToString(), Program.iplocal);
                         }
                         if (managementObject["DataWidth"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"DataWidth", managementObject["DataWidth"].ToString(), Program.iplocal);
                         }
                         if (managementObject["Description"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Description", managementObject["Description"].ToString(), Program.iplocal);
                         }
                         if (managementObject["Name"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant, "Name",managementObject["DeviceID"].ToString(), Program.iplocal);
                         }
                         if (managementObject["ExtClock"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"ExtClock", managementObject["ExtClock"].ToString(), Program.iplocal);
                         }
                         if (managementObject["Family"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Family", managementObject["Family"].ToString(), Program.iplocal);
                         }
                         if (managementObject["L2CacheSize"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"L2CacheSize", managementObject["L2CacheSize"].ToString(), Program.iplocal);
                         }
                         if (managementObject["L3CacheSize"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"L3CacheSize", managementObject["L3CacheSize"].ToString(), Program.iplocal);
                         }
                         if (managementObject["L3CacheSpeed"] != null)
                         {
                             DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"L3CacheSpeed", managementObject["L3CacheSpeed"].ToString(), Program.iplocal);
                         }

                    }
                }

            }
        }

        public static void getBaseBoardInfo()
        {
                 ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_BaseBoard");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Product"] != null)
                {
                    if (DAL_Composant.composant(Program.UUIDMachine, "Carte Mere" + managementObject["Product"].ToString()) == true)
                    {
                        if (managementObject["CreationClassName"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"CreationClassName", managementObject["CreationClassName"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Description"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Description", managementObject["Description"].ToString(), Program.iplocal);
                        }
                        if (managementObject["HostingBoard"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"HostingBoard", managementObject["HostingBoard"].ToString(), Program.iplocal);
                        }
                        if (managementObject["HotSwappable"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"HotSwappable", managementObject["HotSwappable"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Manufacturer"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Manufacturer", managementObject["Manufacturer"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Name"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Name", managementObject["Name"].ToString(), Program.iplocal);
                        }
                        if (managementObject["PoweredOn"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"PoweredOn", managementObject["PoweredOn"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Caption"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Caption", managementObject["Caption"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Removable"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Removable", managementObject["Removable"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Replaceable"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Replaceable", managementObject["Replaceable"].ToString(), Program.iplocal);
                        }
                        if (managementObject["RequiresDaughterBoard"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"RequiresDaughterBoard", managementObject["RequiresDaughterBoard"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SerialNumber"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SerialNumber", managementObject["SerialNumber"].ToString(), Program.iplocal);
                        } if (managementObject["Status"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Status", managementObject["Status"].ToString(), Program.iplocal);
                        }
                        } if (managementObject["Tag"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Tag", managementObject["Tag"].ToString(), Program.iplocal);
                        }
                    }
                }
            }
        
        public static void getBatteryInfo()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_Battery");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Name"] != null)
                {
                    if (DAL_Composant.composant(Program.UUIDMachine, "Battery " + managementObject["Name"].ToString()) == true)
                    {
                        if (managementObject["Availability"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Availability", managementObject["Availability"].ToString(), Program.iplocal);
                        }
                        if (managementObject["BatteryStatus"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"BatteryStatus", managementObject["BatteryStatus"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Caption"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Caption", managementObject["Caption"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Chemistry"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Chemistry", managementObject["Chemistry"].ToString(), Program.iplocal);
                        }
                        if (managementObject["CreationClassName"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"CreationClassName", managementObject["CreationClassName"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Description"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Description", managementObject["Description"].ToString(), Program.iplocal);
                        }
                        if (managementObject["DesignVoltage"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"DesignVoltage", managementObject["DesignVoltage"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Caption"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Caption", managementObject["Caption"].ToString(), Program.iplocal);
                        }

                       
                        if (managementObject["DeviceID"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"DeviceID", managementObject["DeviceID"].ToString(), Program.iplocal);
                        }
                        if (managementObject["EstimatedChargeRemaining"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"EstimatedChargeRemaining", managementObject["EstimatedChargeRemaining"].ToString(), Program.iplocal);
                        }
                        if (managementObject["EstimatedRunTime"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"EstimatedRunTime", managementObject["EstimatedRunTime"].ToString(), Program.iplocal);
                        } if (managementObject["Status"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Status", managementObject["Status"].ToString(), Program.iplocal);
                        }
                    } if (managementObject["PowerManagementCapabilities"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"PowerManagementCapabilities", managementObject["PowerManagementCapabilities"].ToString(), Program.iplocal);
                        }
                    if (managementObject["Status"] != null)
                    {
                        DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Status", managementObject["Status"].ToString(), Program.iplocal);
                    }
                    if (managementObject["PowerManagementSupported"] != null)
                    {
                        DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"PowerManagementSupported", managementObject["PowerManagementSupported"].ToString(), Program.iplocal);
                    }
                    if (managementObject["SystemCreationClassName"] != null)
                    {
                        DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SystemCreationClassName", managementObject["SystemCreationClassName"].ToString(), Program.iplocal);
                    }
                    if (managementObject["SystemName"] != null)
                    {
                        DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SystemName", managementObject["SystemName"].ToString(), Program.iplocal);
                    }
                    }
                }
            }

        public static void getDiskDriveInfo()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_DiskDrive");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["DeviceID"] != null)
                {
                    if (DAL_Composant.composant(Program.UUIDMachine, "WDiskDrive " + managementObject["DeviceID"].ToString()) == true)
                    {
                        if (managementObject["BytesPerSector"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"BytesPerSector", managementObject["BytesPerSector"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Capabilities"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Capabilities", managementObject["Capabilities"].ToString(), Program.iplocal);
                        }
                        if (managementObject["CapabilityDescriptions"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"CapabilityDescriptions", managementObject["CapabilityDescriptions"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Caption"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Caption", managementObject["Caption"].ToString(), Program.iplocal);
                        }
                        if (managementObject["ConfigManagerErrorCode"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"ConfigManagerErrorCode", managementObject["ConfigManagerErrorCode"].ToString(), Program.iplocal);
                        }
                        if (managementObject["ConfigManagerUserConfig"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"ConfigManagerUserConfig", managementObject["ConfigManagerUserConfig"].ToString(), Program.iplocal);
                        }
                        if (managementObject["CreationClassName"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"CreationClassName", managementObject["CreationClassName"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Description"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Description", managementObject["Description"].ToString(), Program.iplocal);
                        }
                        if (managementObject["FirmwareRevision"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"FirmwareRevision", managementObject["FirmwareRevision"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Index"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Index", managementObject["Index"].ToString(), Program.iplocal);
                        }
                        if (managementObject["InterfaceType"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"InterfaceType", managementObject["InterfaceType"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Manufacturer"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Manufacturer", managementObject["Manufacturer"].ToString(), Program.iplocal);
                        }
                        if (managementObject["MediaLoaded"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"MediaLoaded", managementObject["MediaLoaded"].ToString(), Program.iplocal);
                        }
                        if (managementObject["MediaType"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"MediaType", managementObject["MediaType"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Model"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Model", managementObject["Model"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Name"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Name", managementObject["Name"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Partitions"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Partitions", managementObject["Partitions"].ToString(), Program.iplocal);
                        }
                        if (managementObject["PNPDeviceID"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"PNPDeviceID", managementObject["PNPDeviceID"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SCSIBus"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SCSIBus", managementObject["SCSIBus"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SCSILogicalUnit"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SCSILogicalUnit", managementObject["SCSILogicalUnit"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SCSIPort"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SCSIPort", managementObject["SCSIPort"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SCSITargetId"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SCSITargetId", managementObject["SCSITargetId"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SectorsPerTrack"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SectorsPerTrack", managementObject["SectorsPerTrack"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SerialNumber"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SerialNumber", managementObject["SerialNumber"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Signature"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Signature", managementObject["Signature"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Size"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Size", managementObject["Size"].ToString(), Program.iplocal);
                        }
                        if (managementObject["Status"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"Status", managementObject["Status"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SystemCreationClassName"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SystemCreationClassName", managementObject["SystemCreationClassName"].ToString(), Program.iplocal);
                        }
                        if (managementObject["SystemName"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"SystemName", managementObject["SystemName"].ToString(), Program.iplocal);
                        }
                        if (managementObject["TotalCylinders"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"TotalCylinders", managementObject["TotalCylinders"].ToString(), Program.iplocal);
                        }
                        if (managementObject["TotalHeads"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"TotalHeads", managementObject["TotalHeads"].ToString(), Program.iplocal);
                        }
                        if (managementObject["TotalSectors"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"TotalSectors", managementObject["TotalSectors"].ToString(), Program.iplocal);
                        }
                        if (managementObject["TotalTracks"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"TotalTracks", managementObject["TotalTracks"].ToString(), Program.iplocal);
                        }
                        if (managementObject["TracksPerCylinder"] != null)
                        {
                            DAL_proprieteComposant.inserpropocomposant(Program.IDComposant,"TracksPerCylinder", managementObject["TracksPerCylinder"].ToString(), Program.iplocal);
                        }

                    }
                }
            }
        }
   
    
    }


}
