using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using static CIPLV2.Tickets.Services.AdditionalInfoDTO;

namespace CIPLV2.Tickets.Services
{
	public class AdditionalInfo
	{

		public async void OSVersionInfo()
		{
			OSInformationDTO Osobj = new OSInformationDTO();
			try
			{
				DateTime lastBootTime = GetLastBootTime();
				//SelectQuery query = new SelectQuery("Win32_OperatingSystem");
				SelectQuery query1 = new SelectQuery("SELECT * FROM Win32_ComputerSystem");
				//byte[] key = GetRegistryDigitalProductId();
				//string cdKey = DecodeProductKey(key);
				string Key = GetWindowsProductKey();
				ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

				foreach (ManagementObject managementObject in mos.Get())
				{
					if (managementObject["Caption"] != null)
					{
						Osobj.Caption = managementObject["Caption"].ToString();
					}
					if (managementObject["OSArchitecture"] != null)
					{
						Osobj.OSArchitecture = managementObject["OSArchitecture"].ToString();

					}
					if (managementObject["Version"] != null)
					{
						Osobj.Version = managementObject["Version"].ToString();

					}
					if (managementObject["BuildNumber"] != null)
					{
						Osobj.BuildNumber = managementObject["BuildNumber"].ToString();

					}
					if (managementObject["Manufacturer"] != null)
					{
						Osobj.Manufacturer = managementObject["Manufacturer"].ToString();

					}
					if (managementObject["LastBootUpTime"] != null)
					{
						var lastBootTimeString = managementObject["LastBootUpTime"].ToString();
						DateTime lastBootUpTime = ManagementDateTimeConverter.ToDateTime(lastBootTimeString);
						Osobj.LastBootUpTime = lastBootUpTime;

						// Calculate the difference in days using UTC time
						TimeSpan lastBootDuration = DateTime.UtcNow - lastBootUpTime.ToUniversalTime();

						// Round the total days to get an accurate count
						Osobj.NoOfDaysLastBoot = (int)Math.Round(lastBootDuration.TotalDays);
					}
					if (managementObject["SerialNumber"] != null)
					{
						Osobj.SerialNumber = managementObject["SerialNumber"].ToString();
					}

					Osobj.SystemId = System.Environment.MachineName;
				}

				using (ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(query1))
				{
					ManagementObjectCollection collection = searcher1.Get();
					foreach (ManagementObject queryObj in collection)
					{
						string membershipType = queryObj["DomainRole"]?.ToString();

						if (!string.IsNullOrEmpty(membershipType))
						{

							if (membershipType == "0" || membershipType == "1")
							{

								Osobj.DomainRole = "Workgroup";

							}
							else if (membershipType == "2" || membershipType == "3" || membershipType == "4" || membershipType == "5")
							{

								Osobj.DomainRole = "Domain";


							}
							else
							{

								Osobj.DomainRole = "Unknown";


							}
						}
					}
				}

				string applicationId = GetWindowsActivationApplicationId();
				if (applicationId != null)
				{
					bool isActivated = IsWindowsActivated(applicationId);
					Osobj.IsActivated = isActivated;

				}

				if (!string.IsNullOrEmpty(Key))
				{
					Osobj.WindowKey = Key;

				}

				bool isAdmin = IsUserAdministrator();

				WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();


				WindowsPrincipal currentPrincipal = new WindowsPrincipal(currentIdentity);

				if (currentIdentity.Name != null)
				{
					Osobj.LastLogged = currentIdentity.Name;
				}

				if (currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
				{
					Osobj.Role = "Admin";

				}
				else
				{
					Osobj.Role = "Non Admin";
				}
				if (isAdmin)
				{
					Osobj.AdminStatus = "Current User Is Admin";
				}
				else
				{
					Osobj.AdminStatus = "Current User Is Non Admin";
				}

			}
			catch (Exception ex)
			{

			}
			await OsInfoSend(Osobj);


		}


		//api
		public async Task OsInfoSend(OSInformationDTO data)
		{
			var jsonData = JsonConvert.SerializeObject(data);
			using (HttpClient httpClient = new HttpClient())
			{
				var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(AdditionalInfoAPI.OS_Information, content);
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
					if (responseModel != null)
					{

					}
				}
			}

		}

		public async Task HardDiskInfoSend(HardDiskDto data)
		{
			try
			{
				var jsonData = JsonConvert.SerializeObject(data);
				using (HttpClient httpClient = new HttpClient())
				{
					var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
					HttpResponseMessage response = await httpClient.PostAsync(AdditionalInfoAPI.HardDiskInfo, content);
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
						if (responseModel != null)
						{

						}
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public async Task NoOfServicesSend(List<NoOfServicesDto> data)
		{
			var jsonData = JsonConvert.SerializeObject(data);
			using (HttpClient httpClient = new HttpClient())
			{
				var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(AdditionalInfoAPI.NoOfServicesInfo, content);
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
					if (responseModel != null)
					{

					}
				}
			}
		}

		public async Task DeviceInfoSend(DeviceDataDto data)
		{
			var jsonData = JsonConvert.SerializeObject(data);
			using (HttpClient httpClient = new HttpClient())
			{
				var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(AdditionalInfoAPI.DeviceInfo, content);
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
					if (responseModel != null)
					{

					}
				}
			}
		}
		//api

		static DateTime GetLastBootTime()
		{
			DateTime lastBootTime = DateTime.MinValue;

			try
			{
				using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem"))
				{
					ManagementObjectCollection results = searcher.Get();

					foreach (ManagementObject result in results)
					{
						string lastBootTimeString = result["LastBootUpTime"]?.ToString();
						lastBootTime = ManagementDateTimeConverter.ToDateTime(lastBootTimeString);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving last boot time: {ex.Message}");
			}

			return lastBootTime;
		}

		public static string GetWindowsActivationApplicationId()
		{
			try
			{
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM SoftwareLicensingProduct WHERE LicenseStatus = 1");
				ManagementObjectCollection objCollection = searcher.Get();

				foreach (ManagementObject obj in objCollection)
				{
					// Assuming the first activated product is the one we want
					return obj["ApplicationID"]?.ToString();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving Application ID: {ex.Message}");
			}

			return null;
		}

		public static bool IsWindowsActivated(string applicationId)
		{
			if (string.IsNullOrEmpty(applicationId))
			{
				Console.WriteLine("Application ID is null or empty.");
				return false;
			}

			ManagementScope scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\cimv2");
			scope.Connect();

			SelectQuery searchQuery = new SelectQuery($"SELECT * FROM SoftwareLicensingProduct WHERE ApplicationID = '{applicationId}' AND LicenseStatus = 1");
			ManagementObjectSearcher searcherObj = new ManagementObjectSearcher(scope, searchQuery);

			using (ManagementObjectCollection obj = searcherObj.Get())
			{
				return obj.Count > 0;
			}
		}

	
		public static string GetWindowsProductKey()
		{
			try
			{
				ProcessStartInfo psi = new ProcessStartInfo("wmic", "path softwarelicensingservice get OA3xOriginalProductKey");
				psi.RedirectStandardOutput = true;
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;

				using (Process process = new Process() { StartInfo = psi })
				{
					process.Start();
					string result = process.StandardOutput.ReadToEnd();
					process.WaitForExit();

					string input = result;

					// Define the pattern for the product key
					string pattern = @"\b([A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5})\b";

					// Use Regex.Match to find the first match in the input string
					Match match = Regex.Match(input, pattern);

					// Check if a match is found
					if (match.Success)
					{
						// Extract the matched product key
						string productKey = match.Groups[1].Value;
						return productKey;
						// Print the extracted product key
						//Console.WriteLine(productKey);
					}
					else
					{
						Console.WriteLine("No product key found in the input string.");
					}
					return result;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving Windows Product Key: {ex.Message}");
			}

			return null;
		}

		static bool IsUserAdministrator()
		{
			try
			{
				// Get the identity of the current user
				System.Security.Principal.WindowsIdentity currentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();

				// Get the principal representing the current user
				System.Security.Principal.WindowsPrincipal currentPrincipal = new System.Security.Principal.WindowsPrincipal(currentIdentity);

				// Check if the user is a member of the Administrator group
				return currentPrincipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
			}
			catch (Exception)
			{
				// If an exception occurs, return false (not an administrator)
				return false;
			}
		}
		///HardDisk Info



		//second method harddisk info
		public async void HardDiskInfo()
		{
			HardDiskDto hardDiskDto = new HardDiskDto();
			try
			{

				string nonSystemDrive = GetNonSystemDrive();

				DriveInfo[] allDrives = DriveInfo.GetDrives();


				string[] driveLetters = Environment.GetLogicalDrives()
				.Select(drive => Path.GetPathRoot(drive).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))
				.Select(drive => drive.Substring(0, 1))
				.ToArray();

				string driveLetter = driveLetters[0];

				string systemdrive = GetSystemDrive();

				foreach (DriveInfo drive in allDrives)
				{

					string serialNumber = GetDriveSerialNumber(driveLetter.ToString());
					string drivename = drive.Name;
					string drivetype = drive.DriveType.ToString();
					if (systemdrive.Contains(drive.Name))
					{
						if (drivename != null)
						{
							hardDiskDto.DriveName = drivename;

						}
						if (drivetype != null)
						{
							hardDiskDto.DriveType = drivetype;
						}





						if (systemdrive != null)
						{
							string totalsize = FormatBytes(drive.TotalSize);
							string freespace = FormatBytes(drive.TotalFreeSpace);
							string Availablefreespace = FormatBytes(drive.AvailableFreeSpace);
							string driveformat = drive.DriveFormat.ToString();


							if (totalsize != null)
							{
								hardDiskDto.TotalSize = drive.TotalSize;
							}
							if (freespace != null)
							{
								hardDiskDto.FreeSpace = drive.TotalFreeSpace;
							}
							if (Availablefreespace != null)
							{
								hardDiskDto.AvailableFreeSpace = drive.AvailableFreeSpace;
							}
							if (driveformat != null)
							{
								hardDiskDto.DriveFormat = drive.DriveFormat;
							}



						}


						if (drive.DriveType == DriveType.Fixed)
						{
							if (serialNumber != null)
							{
								hardDiskDto.SerialNumber = serialNumber;
							}

						}
					}

					if (nonSystemDrive != null)
					{
						DriveInfo driveInfo = new DriveInfo(nonSystemDrive);

						string nonsysdrive = driveInfo.Name;
						string nontoal = FormatBytes(driveInfo.TotalSize);
						string nonfree = FormatBytes(driveInfo.TotalFreeSpace);

						if (driveInfo.Name != null)
						{
							hardDiskDto.NonSystemDriveName = driveInfo.Name;
						}
						if (driveInfo.TotalSize != null)
						{
							hardDiskDto.NonSystemTotalSpace = driveInfo.TotalSize;
						}

						if (driveInfo.TotalFreeSpace != null)
						{
							hardDiskDto.NonSystemFreeSpace = driveInfo.TotalFreeSpace;
						}


					}

				}



				hardDiskDto.SystemId = System.Environment.MachineName;

			}
			catch (Exception ex)
			{

			}

			await HardDiskInfoSend(hardDiskDto);

		}

		static string FormatBytes(long bytes)
		{
			string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
			int suffixIndex = 0;

			while (bytes >= 1024 && suffixIndex < suffixes.Length - 1)
			{
				bytes /= 1024;
				suffixIndex++;
			}

			return $"{bytes} {suffixes[suffixIndex]}";
		}

		static string GetDriveSerialNumber(string driveLetter)
		{

			try
			{
				ManagementObject disk = new ManagementObject($"win32_logicaldisk.deviceid=\"{driveLetter}:\"");
				disk.Get();
				return disk["VolumeSerialNumber"].ToString();
			}
			catch (ManagementException mex)
			{
				Console.WriteLine($"ManagementException: {mex.Message}");
			}
			catch (UnauthorizedAccessException uae)
			{
				Console.WriteLine($"UnauthorizedAccessException: {uae.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving drive serial number: {ex.Message}");
			}

			return "N/A";
		}

		static string GetNonSystemDrive()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();

			foreach (DriveInfo drive in drives)
			{
				if (drive.DriveType == DriveType.Fixed && !Path.GetPathRoot(Environment.SystemDirectory).StartsWith(drive.Name))
				{
					return drive.Name;
				}
			}

			return null;
		}

		static string GetSystemDrive()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				if (drive.DriveType == DriveType.Fixed && Path.GetPathRoot(Environment.SystemDirectory).StartsWith(drive.Name))
				{
					return drive.Name;
				}
			}
			return null;
		}


		public async void NoOfServices()
		{
			List<NoOfServicesDto> SericesList = new List<NoOfServicesDto>();

			try
			{


				ServiceController[] services = ServiceController.GetServices();

				int serviceCount = 0;
				foreach (ServiceController service in services)
				{
					NoOfServicesDto nosos = new NoOfServicesDto();
					serviceCount++;


					string serviceName = service.ServiceName;
					string DisplayName = service.DisplayName;
					string Status = service.Status.ToString();
					if (service.StartType == ServiceStartMode.Automatic)
					{
						nosos.startup = true;
					}
					else
					{
						nosos.startup = false;
					}

					nosos.ServiceName = serviceName;
					nosos.ServiceDisplayName = DisplayName;
					nosos.ServiceStatus = Status;


					nosos.SystemId = System.Environment.MachineName;
					SericesList.Add(nosos);

				}


			}
			catch (Exception ex)
			{

			}
			await NoOfServicesSend(SericesList);


		}


		public async void DeviceData()
		{

			DeviceDataDto deviceData = new DeviceDataDto();
			try
			{

				PerformanceCounter totalVirtualMemoryCounter = new PerformanceCounter("Memory", "Committed Bytes");
				PerformanceCounter availableVirtualMemoryCounter = new PerformanceCounter("Memory", "Available Bytes");

				ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");
				ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
				ObjectQuery displayquery = new ObjectQuery("SELECT * FROM Win32_VideoController");
				ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
				ManagementObjectSearcher dissearcher = new ManagementObjectSearcher(scope, displayquery);


				long totalVirtualMemory = (long)totalVirtualMemoryCounter.NextValue();
				long availableVirtualMemory = (long)availableVirtualMemoryCounter.NextValue();

				// Convert bytes to megabytes for better readability
				double totalVirtualMemoryMB = totalVirtualMemory / (1024.0 * 1024.0);
				double availableVirtualMemoryMB = availableVirtualMemory / (1024.0 * 1024.0);


				// Get device type, model, and name
				string deviceType = Environment.OSVersion.Platform.ToString();
				string deviceModel = Environment.MachineName;
				string deviceName = Environment.MachineName;


				string biosSerialNumber = GetBiosSerialNumber();

				string macAddress = GetMacAddress();


				string ipAddress = GetIpAddress();
				string devicetype = deviceType.ToString();
				string devicemodel = deviceModel.ToString();
				string devicename = deviceName.ToString();
				string bios = biosSerialNumber.ToString();
				string mac = macAddress.ToString();
				string ip = ipAddress.ToString();
				string vmemory = totalVirtualMemoryMB.ToString("N2");
				string avmemory = availableVirtualMemoryMB.ToString("N2");




				deviceData.DeviceType = deviceType;
				deviceData.DeviceName = deviceName;
				deviceData.DeviceModel = deviceModel;
				deviceData.BIOS = bios;
				deviceData.MAC = mac;
				deviceData.IP = ip;
				deviceData.VirtualMemory = vmemory;
				deviceData.AvilableMemory = avmemory;



				foreach (ManagementObject queryObj in searcher.Get())
				{
					deviceData.displayManufacture = queryObj["Manufacturer"].ToString();
					//richTextBox1.AppendText("\nManufacturer: " + $"{queryObj["Manufacturer"]}");

				}

				foreach (ManagementObject querydis in dissearcher.Get())
				{

					deviceData.displaydetails = querydis["Description"].ToString();
					deviceData.displayname = querydis["Name"].ToString();
					//richTextBox1.AppendText("\nDescription " + $"{querydis["Description"]}");
					//richTextBox1.AppendText("\nName " + $"{querydis["Name"]}");
				}
				deviceData.SystemId = System.Environment.MachineName;
			}
			catch (Exception ex)
			{

			}

			await DeviceInfoSend(deviceData);

		}

		static string GetBiosSerialNumber()
		{
			using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
			{
				ManagementObjectCollection biosCollection = searcher.Get();
				foreach (ManagementObject bios in biosCollection)
				{
					return bios["SerialNumber"].ToString();
				}
			}
			return "N/A";
		}

		static string GetMacAddress()
		{
			NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in networkInterfaces)
			{
				//if (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
				//	networkInterface.OperationalStatus == OperationalStatus.Up)
				//{
				//	return networkInterface.GetPhysicalAddress().ToString();
				//}
				string tempMac = networkInterface.GetPhysicalAddress().ToString();
				if (!string.IsNullOrEmpty(tempMac) &&
					tempMac.Length >= 8)
				{
					return tempMac;
					//return macAddress;
				}

			}
			return "N/A";
		}

		static string GetIpAddress()
		{
			string hostName = Dns.GetHostName();
			IPHostEntry ipEntry = Dns.GetHostEntry(hostName);

			foreach (IPAddress ipAddress in ipEntry.AddressList)
			{
				if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return ipAddress.ToString();
				}
			}

			return "N/A";
		}

	}

	public class AdditionalInfoDTO
	{
		public class OSInformationDTO
		{
			public int Id { get; set; }
			public string Caption { get; set; }
			public string OSArchitecture { get; set; }
			public string Version { get; set; }
			public string BuildNumber { get; set; }
			public string Manufacturer { get; set; }
			public string SerialNumber { get; set; }
			public string DomainRole { get; set; }
			public DateTime LastBootUpTime { get; set; }
			public int NoOfDaysLastBoot { get; set; }
			public bool IsActivated { get; set; }
			public string WindowKey { get; set; }
			public string SystemId { get; set; }

			public string Role { get; set; }

			public string LastLogged { get; set; }

			public string AdminStatus { get; set; }
		}
		public class HardDiskDto
		{
			public int Id { get; set; }
			public string DriveName { get; set; }
			public string DriveType { get; set; }
			public string DriveFormat { get; set; }
			public string SerialNumber { get; set; }
			public long TotalSize { get; set; }
			public long FreeSpace { get; set; }
			public long AvailableFreeSpace { get; set; }

			public string NonSystemDriveName { get; set; }

			public long NonSystemTotalSpace { get; set; }

			public long NonSystemFreeSpace { get; set; }

			public string SystemId { get; set; }
		}

		public class NoOfServicesDto
		{
			public string ServiceName { get; set; }
			public string ServiceDisplayName { get; set; }

			public string ServiceStatus { get; set; }
			public bool startup { get; set; }

			public string SystemId { get; set; }
		}

		public class DeviceDataDto
		{
			public string DeviceType { get; set; }
			public string DeviceModel { get; set; }
			public string DeviceName { get; set; }

			public string BIOS { get; set; }

			public string MAC { get; set; }

			public string IP { get; set; }
			public string VirtualMemory { get; set; }
			public string AvilableMemory { get; set; }

			public string displayManufacture { get; set; }

			public string displaydetails { get; set; }

			public string displayname { get; set; }

			public string SystemId { get; set; }

		}


	}

	public class AdditionalInfoAPI
	{
		//public static string OS_Information { get; set; } = "http://10.205.48.200:1007/api/additional/additionalinfo/Upsert";
		//public static string HardDiskInfo { get; set; } = "http://10.205.48.200:1007/api/additional/additionalinfo/HardDisk";

		//public static string NoOfServicesInfo { get; set; } = "http://10.205.48.200:1007/api/additional/additionalinfo/NoOfService";
		//public static string DeviceInfo { get; set; } = "http://10.205.48.200:1007/api/additional/additionalinfo/AddDeviceData";


		public static string OS_Information { get; set; } = "http://65.2.100.52:1007/api/additional/additionalinfo/Upsert";
		public static string HardDiskInfo { get; set; } = "http://65.2.100.52:1007/api/additional/additionalinfo/HardDisk";

		public static string NoOfServicesInfo { get; set; } = "http://65.2.100.52:1007/api/additional/additionalinfo/NoOfService";
		public static string DeviceInfo { get; set; } = "http://65.2.100.52:1007/api/additional/additionalinfo/AddDeviceData";

		//public static string OS_Information { get; set; } = "http://localhost:5028/api/additional/additionalinfo/Upsert";
		//public static string HardDiskInfo { get; set; } = "http://localhost:5028/api/additional/additionalinfo/HardDisk";

		//public static string NoOfServicesInfo { get; set; } = "http://localhost:5028/api/additional/additionalinfo/NoOfService";
		//public static string DeviceInfo { get; set; } = "http://localhost:5028/api/additional/additionalinfo/AddDeviceData";

	}

}
