using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;

namespace TestPreview
{
    public class MainVM
    {
        private RelayCommand myPreviewCommand;
        private RelayCommand myWindowCommand;

        public RelayCommand PreviewCommand
        {
            get
            {
                if (myPreviewCommand == null)
                    myPreviewCommand = new RelayCommand(PreviewCommandAction);

                return myPreviewCommand;
            }
        }

        public RelayCommand WindowCommand
        {
            get
            {
                if (myWindowCommand == null)
                    myWindowCommand = new RelayCommand(WindowCommandCommandAction);

                return myWindowCommand;
            }
        }

    private void PreviewCommandAction()
    {
        Paginator paginator = new Paginator();

        MemoryStream lMemoryStream = new MemoryStream();
        Package package = Package.Open(lMemoryStream, FileMode.Create);
        XpsDocument xpsDocument = new XpsDocument(package);
        XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
        writer.Write(paginator);
        xpsDocument.Close();
        package.Close();

        Preview previewWindow = new Preview(lMemoryStream);

        previewWindow.ShowDialog();
    }

    private void WindowCommandCommandAction()
    {
        XamlWindow xw = new XamlWindow();
        xw.Show();
    }
    }
}
