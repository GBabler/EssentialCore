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
using EssentialCore.FORMULARIOS;

namespace EssentialCore.FORMULARIOS
{
    /// <summary>
    /// Lógica interna para FrmMenu.xaml
    /// </summary>
    public partial class FrmMenu : Window
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void BtnCadastroCliente_Click(object sender, RoutedEventArgs e)
        {
            //FrmCadastoCliente cadastroCliente = new FrmCadastoCliente();
            FrmListaDeClientes listaDeClientes = new FrmListaDeClientes();
            listaDeClientes.ShowDialog();

        }
    }
}
