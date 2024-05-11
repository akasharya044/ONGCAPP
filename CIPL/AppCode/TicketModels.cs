using System;
using System.Collections.Generic;


namespace CIPL.AppCode
{
    public class StarRatingResponseModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public StarRatingDataModel data { get; set; }
        public int status { get; set; }
    }

    public class StarRatingDataModel
    {
        public string ongccat_c { get; set; }
        public string ongcsub_c { get; set; }
        public string ongcarea_c { get; set; }
        public string username { get; set; }
        public string starcount { get; set; }
    }
    public class RaiseMFTicketDTO
    {
        public List<MFEntity> entities { get; set; }
        public string operation { get; set; }
    }
    public class MFEntity
    {
        public string entity_type { get; set; }
        public MFProperty properties { get; set; }
    }
    public class MFProperty
    {
        public string ServiceDeskGroup { get; set; }
        public string Description { get; set; }
        public string RegisteredForActualService { get; set; }
        public string RequestedByPerson { get; set; }
        public string Priority { get; set; }
        public string ONGCCAT_c { get; set; }
        public string ONGCSUB_c { get; set; }
        public string ONGCAREA_c { get; set; }
        public string ContactPerson { get; set; }
        public string DisplayLabel { get; set; }
        public string SystemId { get; set; }//For machine request sent
        public int RegisteredForDevice_c { get; set; }

    }
}
