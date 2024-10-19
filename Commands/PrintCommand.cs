using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Notepad.Commands
{
    public class PrintCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public PrintCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument document = new FlowDocument();
                document.Blocks.Add(new Paragraph(new Run(_mainViewModel.Text)));
                printDialog.PrintDocument(((IDocumentPaginatorSource) document).DocumentPaginator, "");
            }
        }
    }
}
