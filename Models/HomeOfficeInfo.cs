using System;
using System.ComponentModel.DataAnnotations;

namespace HomeOffice.Calendar.Models
{
    public class HomeOfficeInfo : IHomeOfficeInfocs
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? Holiday { get; set; }

        public int? SickDay { get; set; }

        public int? PublicHoliday { get; set; }

        public int? HomeOfficePercent { get; set; }

        public int? Workday { get; set; }

        public int? DayInHomeOffice { get; set; } = 0;

        public int? DayInOffice { get; set; }
    }
}