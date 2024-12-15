using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOffice.Calendar.Models
{
    public interface IHomeOfficeInfocs
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? Holiday { get; set; }

        public int? SickDay { get; set; }

        public int? PublicHoliday { get; set; }

        public int? HomeOfficePercent { get; set; }

        public int? Workday { get; set; }

        public int? DayInHomeOffice { get; set; }

        public int? DayInOffice { get; set; }
    }
}
