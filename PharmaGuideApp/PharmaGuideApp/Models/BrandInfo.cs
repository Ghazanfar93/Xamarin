using SQLite.Net.Attributes;
using System;

namespace PharmaGuideApp.Models
{
    public class BrandInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string TherapeuticCategory { get; set; }
        public string DrugCategory { get; set; }
        public string ContentTitle { get; set; }
        public string Pack { get; set; }
        public string PrescribingInformation { get; set; }
        public bool Status { get; set; }
    }
}
