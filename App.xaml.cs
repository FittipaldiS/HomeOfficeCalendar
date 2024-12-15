using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HomeOffice.Calendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HomeOffice.Calendar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Non gestisce le migrazioni
            //DatabaseFacade databaseFacade = new(new DatabaseContext());
            //databaseFacade.EnsureCreated();
            using (var context = new DatabaseContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
