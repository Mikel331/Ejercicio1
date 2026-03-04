using Microsoft.Reporting.WebForms;
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
using System.Windows.Shapes;
using System.Windows.Forms;



namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private List<MainWindow.Producto> _productos;
        private ReportViewer reportViewer;
        public Window1(List<MainWindow.Producto> productos)
        {
            InitializeComponent();
            _productos = productos;
            CargarInforme();
        }

        
        private void CargarInforme()
        {
            reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.ReportPath = ("Report1.rdlc");
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _productos));

            reportViewer.LocalReport.Refresh();


            host.Child = reportViewer;


        }
    }
}
