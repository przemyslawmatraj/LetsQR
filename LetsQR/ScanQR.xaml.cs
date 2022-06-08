using System;
using System.Collections.Generic;
using System.Drawing;
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
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.Win32;

namespace LetsQR
{
    /// <summary>
    /// Logika interakcji dla klasy ScanQR.xaml
    /// </summary>
    public partial class ScanQR : UserControl
    {
        QRCodeDecoder decoder = new QRCodeDecoder();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public ScanQR()
        {
            InitializeComponent();
        }

        private void scanBtn_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));

                QRCodeImage.Source = bitmap;
                string decoded = decoder.Decode(new QRCodeBitmapImage(new Bitmap(openFileDialog.FileName)));
                resutl.Text = decoded;
                SqliteAccess.InsertLog(new LogModel
                {
                    Date = DateTime.Now,
                    Type = "Zeskanowano",
                    Base64QR = QRImage.ToBase64Image(bitmap)
                });

            }
        }

            
    }
}
