using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EduScoreDatabase;
using Microsoft.EntityFrameworkCore;

namespace EduScore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var context = new EduScoreContext())
            {
                context.Database.Migrate();
                var dbfill = new ExampleData();
                dbfill.SeedData(context);
            }
        }
    }
}
