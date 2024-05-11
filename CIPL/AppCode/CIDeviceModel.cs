using System;
using System.Collections.Generic;

namespace CIPL.AppCode
{
    public class DeviceProperties
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string SubType { get; set; }
        public long LastUpdateTime { get; set; }
        public string DisplayLabel { get; set; }
        public string MfDeviceId { get; set; }// new add
    }
    public class DeviceData
    {
        public string entity_type { get; set; }
        public DeviceProperties properties { get; set; }
    }

    public class DeviceRoot
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<DeviceData> data { get; set; }
    }
    public class PersonProperties
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public bool IsVIP { get; set; }
        public string Name { get; set; }
        public string Upn { get; set; }
        public long LastUpdateTime { get; set; }
        public string MfpersonId { get; set; }
    }

    public class PersonData
    {
        public string entity_type { get; set; }
        public PersonProperties properties { get; set; }
    }

    public class PersonRoot
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<PersonData> data { get; set; }
    }
}
