using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace TestPreview
{
    public class PreviewVM : ObservableObject
    {
        private IDocumentPaginatorSource myDocument;
        private XpsDocument xps;
        private Uri packageUri;
        private Stream docStream;

        public PreviewVM(MemoryStream xpsStreamDocument)
        {
            docStream = xpsStreamDocument;
            Package package = Package.Open(docStream);

            //Create URI for Xps Package
            //Any Uri will actually be fine here. It acts as a place holder for the
            //Uri of the package inside of the PackageStore
            string inMemoryPackageName = string.Format("memorystream://{0}.xps", Guid.NewGuid());
            packageUri = new Uri(inMemoryPackageName);

            //Add package to PackageStore
            PackageStore.AddPackage(packageUri, package);

            xps = new XpsDocument(package, CompressionOption.SuperFast, inMemoryPackageName);
            Document = xps.GetFixedDocumentSequence();
        }

        public IDocumentPaginatorSource Document
        {
            get { return myDocument; }
            set
            { 
                if (myDocument == value) return;
                myDocument = value;
                OnPropertyChanged(nameof(Document));
            }
        }
    }
}
