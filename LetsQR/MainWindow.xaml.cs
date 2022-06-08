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

namespace LetsQR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void DragGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Refresh(UIElement view)
        {
            MainContent.Children.Clear();
            MainContent.Children.Add(view);
        }
        
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListMenu.SelectedIndex;
            MoveCursor(index);
            switch (index)
            {
                case 0:
                    Refresh(new Generate());
                    break;
                case 1:
                    Refresh(new ScanQR());
                    break;
                case 2:
                    Refresh(new Log());
                    break;
            }

        }
        private void MoveCursor(int index)
        {
            TransitionContent.OnApplyTemplate();
            Cursor.Margin = new Thickness(30, (96 + index*72), 0,0);
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh(new Generate());
        }
    }
}
