using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;

namespace LetsQR
{
    /// <summary>
    /// Logika interakcji dla klasy Log.xaml
    /// </summary>
    public partial class Log : UserControl
    {
        public Log()
        {
            InitializeComponent();
            List<LogModel> logs = new List<LogModel>();
            logs = SqliteAccess.GetAllLogs();
            logsList.ItemsSource = logs;
        }
    }
}
