using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace TestPreview
{
    /// <summary>
    /// Logique d'interaction pour Preview.xaml
    /// </summary>
    public partial class Preview : Window
    {
        private readonly PreviewVM myPreviewVM;
        public Preview(MemoryStream lMemoryStream)
        {
            InitializeComponent();
            myPreviewVM = new PreviewVM(lMemoryStream);
            DataContext= myPreviewVM;
        }
    }
}
