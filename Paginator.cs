using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace TestPreview
{        
    public class Paginator : DocumentPaginator
    {
        double pageHeight = 1122.52;
        double pageWidth = 793.7;
        Size mySize;

        public Paginator()
        {
            mySize = new Size(pageWidth, pageHeight);
        }

        
        public override DocumentPage GetPage(int pageNumber)
        {
            XamlPage page = new XamlPage();
            page.Measure(PageSize);
            page.Arrange(new Rect(new Point(0, 0), PageSize));
            page.UpdateLayout();
            return new DocumentPage(page, PageSize, new Rect(0, 0, 10, 10), new Rect());
        }

        public override bool IsPageCountValid
        {
            get { return true; }
        }

        public override int PageCount
        {
            get { return 1; }
        }

        public override Size PageSize
        {
            get { return mySize; }
            set { mySize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }
    }
}
