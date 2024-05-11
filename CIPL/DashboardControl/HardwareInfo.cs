using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;
using Newtonsoft.Json;

namespace CIPL.DashboardControl
{
	public partial class HardwareInfo : UserControl
	{
		public HardwareInfo()
		{
			InitializeComponent();
		}
		List<SystemHardware> systemHardware = new List<SystemHardware>();
		private void HardewareInfo_Load(object sender, EventArgs e)
		{
			ManagementObjectSearcher searcher;
			int i = 0;
			ArrayList arrayListInformationCollactor = new ArrayList();
			try
			{
				searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
				foreach (ManagementObject mo in searcher.Get())
				{
					i++;
					PropertyDataCollection searcherProperties = mo.Properties;
					foreach (PropertyData sp in searcherProperties)
					{
						SystemHardware hardware = new SystemHardware();
						hardware.SystemId = System.Environment.MachineName;
						hardware.Name = sp.Name;
						hardware.IsArray = sp.IsArray;
						hardware.IsLocal = sp.IsLocal;
						hardware.Origin = sp.Origin;
						hardware.Type = sp.Type != null ? sp.Type.ToString():"";
						hardware.value = sp.Value!=null?sp.Value.ToString():"";
						hardware.Qualifires = sp.Qualifiers != null ? sp.Qualifiers.ToString() : "";
						systemHardware.Add(hardware);
						arrayListInformationCollactor.Add(sp);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			dgvWMI.DataSource = arrayListInformationCollactor;
			HardwareInform(systemHardware);
		}

		public async Task HardwareInform(List<SystemHardware> data)
		{
			var jsonData = JsonConvert.SerializeObject(data);
			using (HttpClient httpClient = new HttpClient())
			{
				var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(ChatAPIs.Hardware_url, content);
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
	}
}
