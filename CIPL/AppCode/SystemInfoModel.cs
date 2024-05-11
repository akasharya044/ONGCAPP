using System;

namespace CIPL.AppCode
{
	
	public class SystemHardware
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string value { get; set; }
		public string Type { get; set; }
		public bool IsLocal { get; set; }
		public bool IsArray { get; set; }
		public string Origin { get; set; }
		public string Qualifires { get; set; }
		public string SystemId { get; set; }
	}
	public class SystemSoftware
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Publisher { get; set; }
		public string InstalledOn { get; set; }
		public string Size { get; set; }
		public string SystemId { get; set; }
		public string Version { get; set; }
	}
}
