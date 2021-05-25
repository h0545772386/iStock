using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace iStock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("he-IL");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("he-IL");

            // כדי שלא ישפיע עליו שום פורמט של תאריך
            // מחייב לתת למאפיין של
            // Format = Custom
            // DateTimePicker לכל פקד
            CultureInfo ci = new CultureInfo("he-IL");
            ci.DateTimeFormat.FullDateTimePattern = "dd/MM/yyyy HH:mm:ss";
            ci.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm:ss";
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
        }
    }
}
