using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy Generate.xaml
    /// </summary>
    public partial class Generate : UserControl
    {
        QRCodeEncoder encoder = new QRCodeEncoder();
        Bitmap bitmap = new Bitmap(8, 8);
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Generate()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            encoder.QRCodeScale = 8;
            bitmap = encoder.Encode(generateText.Text);
            QRCodeImage.Source = QRImage.Generate(bitmap);
        }

        private void downloadBtn_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog.Filter = "PNG (*.png)|*.png";
            string fileName = Regex.Replace(generateText.Text,"[^a-zA-Z0-9%]", string.Empty).Trim();
            saveFileDialog.FileName = "QR_" + fileName;
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "" && bitmap!=null)
            {
                bitmap.Save(string.Concat(saveFileDialog.FileName, ".png"), ImageFormat.Png);
            }
        }
    }
}
