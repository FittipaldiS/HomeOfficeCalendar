using HomeOffice.Calendar.Helper;
using HomeOffice.Calendar.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using MVVM.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeOffice.Calendar.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //private readonly ILogger<MainWindow> _logger;

        public MainWindowViewModel(IHomeOfficeInfocs homeOfficeInfo, ILogger<MainWindow> logger)
        {
            Id = homeOfficeInfo.Id;
            Date = homeOfficeInfo.Date;
            Holiday = homeOfficeInfo.Holiday;
            SickDay = homeOfficeInfo.SickDay;
            PublicHoliday = homeOfficeInfo.PublicHoliday;
            HomeOfficePercent = homeOfficeInfo.HomeOfficePercent;
            //_logger = logger;
        }

        public MainWindowViewModel()
        {
            Read();
        }

        #region Property

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private int _id;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        private DateTime _date;

        public int? Holiday
        {
            get => _holiday;
            set => SetProperty(ref _holiday, value);
        }
        private int? _holiday;

        public int? SickDay
        {
            get => _sickDay;
            set => SetProperty(ref _sickDay, value);
        }
        private int? _sickDay;

        public int? PublicHoliday
        {
            get => _publicHoliday;
            set => SetProperty(ref _publicHoliday, value);
        }
        private int? _publicHoliday;

        public int? HomeOfficePercent
        {
            get => _homeOfficePercent;
            set => SetProperty(ref _homeOfficePercent, value);
        }
        private int? _homeOfficePercent;

        //TerxtBox
        public DateTime? DateDataPicker
        {
            get => _dateDataPicker;
            set => SetProperty(ref _dateDataPicker, value);
        }
        private DateTime? _dateDataPicker;


        public string HolidayTextBox
        {
            get => _holidayTextBox;
            set => SetProperty(ref _holidayTextBox, value);
        }
        private string _holidayTextBox;

        public string SickDayTextBox
        {
            get => _sickDayTextBox;
            set => SetProperty(ref _sickDayTextBox, value);
        }
        private string _sickDayTextBox;

        public string PublicDayTextBox
        {
            get => _publicDayTextBox;
            set => SetProperty(ref _publicDayTextBox, value);
        }
        private string _publicDayTextBox;

        public int? SelectedPercentComboBox
        {
            get => _selectedPercentComboBox;
            set => SetProperty(ref _selectedPercentComboBox, value);
        }
        private int? _selectedPercentComboBox;

        public string WorkdayTextBox
        {
            get => _workdayTextBox;
            set => SetProperty(ref _workdayTextBox, value);
        }
        private string _workdayTextBox;

        public string HomeOfficeTextBox
        {
            get => _homeOfficeTextBox;
            set => SetProperty(ref _homeOfficeTextBox, value);
        }
        private string _homeOfficeTextBox;

        public string DayInOfficeTextBox
        {
            get => _dayInHomeOfficeTextBox;
            set => SetProperty(ref _dayInHomeOfficeTextBox, value);
        }
        private string _dayInHomeOfficeTextBox;

        public int? Workday
        {
            get => _workday;
            set => SetProperty(ref _workday, value);
        }
        private int? _workday;

        public int? DayInHomeOffice
        {
            get => _dayInHomeOffice;
            set => SetProperty(ref _dayInHomeOffice, value);
        }
        private int? _dayInHomeOffice;

        public int? DayInOffice
        {
            get => _dayInOffice;
            set => SetProperty(ref _dayInOffice, value);
        }
        private int? _dayInOffice;

        public List<HomeOfficeInfo> DatabaseHomeOfficeList { get; set; }

        public List<HomeOfficeInfo> ItemListTable
        {
            get => _itemListTable;
            set => SetProperty(ref _itemListTable, value);
        }
        private List<HomeOfficeInfo> _itemListTable;

        public HomeOfficeInfo SelectedItemTable
        {
            get => _selectedItemTable;
            set => SetProperty(ref _selectedItemTable, value);
        }
        private HomeOfficeInfo _selectedItemTable;

        #endregion

        #region RelayCommand

        private RelayCommand _submit;
        public ICommand SubmitCommand => _submit ??= new RelayCommand(InsertHomeofficeInfo);

        private RelayCommand _delete;
        public ICommand DeleteCommand => _delete ??= new RelayCommand(DeleteHomeofficeInfo);

        #endregion

        private void InsertHomeofficeInfo(object commandParameter)
        {
            //_logger.LogInformation("Try to insert data in database");

            try
            {
                if (DateDataPicker != null || DateDataPicker.HasValue == true)
                {
                    _ = int.TryParse(HolidayTextBox, out int holidayNumber);
                    _ = int.TryParse(SickDayTextBox, out int sickDayNumber);
                    _ = int.TryParse(PublicDayTextBox, out int publicHolidayNumber);

                    var allSummeOfAbsentDays = holidayNumber + sickDayNumber + publicHolidayNumber;

                    var workdayTime = DateDataPicker;

                    var numberOfBusinessDaysSelectedMonth = SummeOfBusinessDayHelper.GetBusinessDay(workdayTime.Value);

                    var summeOfBusinessDays = numberOfBusinessDaysSelectedMonth - allSummeOfAbsentDays;

                    if (summeOfBusinessDays < 0)
                    {
                        MessageBox.Show("Die eingegebenen Zahlen dürfen die Anzahl der Arbeitstage nicht überschreiten.", "Error negativ number", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {

                        var percent = SelectedPercentComboBox ?? 0;
                        var dayInHomeOffice = summeOfBusinessDays * percent / 100;

                        WorkdayTextBox = $"{numberOfBusinessDaysSelectedMonth - allSummeOfAbsentDays}";
                        HomeOfficeTextBox = $"{dayInHomeOffice}";

                        var summeOfRestTag = summeOfBusinessDays - dayInHomeOffice;

                        DayInOfficeTextBox = $"{summeOfRestTag}";
                        DayInOffice = summeOfRestTag;
                    }

                    Create();
                    Read();
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie ein Datum ein", "Datum nicht ersetzt ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                //_logger.LogError("Cannot enter the data into the database");
                throw;
            }
        }

        private void DeleteHomeofficeInfo(object commandParameter)
        {
            Delete(SelectedItemTable);
        }

        public void Create()
        {
            using (var context = new DatabaseContext())
            {
                _ = int.TryParse(HolidayTextBox, out int holiday);
                _ = int.TryParse(SickDayTextBox, out int sickday);
                _ = int.TryParse(PublicDayTextBox, out int publicHoliday);
                _ = int.TryParse(DayInOfficeTextBox, out int dayInOffice);
                _ = int.TryParse(WorkdayTextBox, out int workday);
                _ = int.TryParse(HomeOfficeTextBox, out int homeOffice);

                //TODO : ADD this only for date
                var dateOnly = new DateOnly(DateDataPicker.Value.Year, DateDataPicker.Value.Month, DateDataPicker.Value.Day);

                if (DateDataPicker.HasValue == true)
                {
                    context.Add(new HomeOfficeInfo()
                    {
                        Date = DateDataPicker.Value.Date,
                        Holiday = holiday,
                        SickDay = sickday,
                        PublicHoliday = publicHoliday,
                        HomeOfficePercent = SelectedPercentComboBox,
                        DayInHomeOffice = homeOffice,
                        Workday = workday,
                        DayInOffice = dayInOffice
                    });

                    context.SaveChanges();

                    Read();
                }
            }
        }

        public void Delete(HomeOfficeInfo selectedItemTable)
        {
            using (var context = new DatabaseContext())
            {
                //var selectedHomeOfficeInfo = selectedItemTable;

                var date = DateDataPicker;

                if (selectedItemTable != null)
                {
                    var homeOfficeInfo = context.HomeOfficeInfos.Find(selectedItemTable.Id);

                    if (homeOfficeInfo != null)
                    {
                        //TODO SF: forse update non servirà

                        var result = MessageBox.Show("Sie löschen ein Datenelement aus der Tabelle. Sind Sie sicher, dass Sie das tun wollen?", "Löschung einer Datenposition", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (result == MessageBoxResult.Yes)
                        {
                            context.HomeOfficeInfos.Remove(homeOfficeInfo);
                            context.SaveChanges();
                            Read();
                        }

                        Read();
                    }
                }
                else
                {
                    MessageBox.Show("Um zu löschen, müssen Sie zunächst einen Tabelleneintrag auswählen.", "Es wurden keine Daten ausgewählt", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void Read()
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    DatabaseHomeOfficeList = context.HomeOfficeInfos.ToList();
                    ItemListTable = DatabaseHomeOfficeList;
                }
                catch (Exception ex)
                {
                    //_logger.LogError("I can't read the database");
                    MessageBox.Show("I can't read the database","Dabase error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            }
        }
    }
}
