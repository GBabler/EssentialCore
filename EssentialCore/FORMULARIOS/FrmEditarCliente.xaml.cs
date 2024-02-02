using EssentialCore.CLASSE;
using EssentialCore.REPOSITORIO;
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

namespace EssentialCore.FORMULARIOS
{
    /// <summary>
    /// Lógica interna para FrmEditarCliente.xaml
    /// </summary>
    public partial class FrmEditarCliente : Window
    {
        public event EventHandler ClienteEditado;


        public FrmEditarCliente()
        {
            InitializeComponent();
        }

        private void BtnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nomeCompleto.Text) || string.IsNullOrWhiteSpace(celular.Text))
                {
                    MessageBox.Show("Campos obrigatórios vazios!");

                }

                CLIENTE cliente = new CLIENTE();

                cliente.Id = int.Parse(idCliente.Content.ToString());
                cliente.Nome = nomeCompleto.Text;
                cliente.Endereco = endereco.Text;
                cliente.NumEnd = numeroEnd.Text;
                cliente.Celular = celular.Text;


                SQLITEDAL.Update(cliente);

                OnClienteEditado(EventArgs.Empty);

                var resultado = MessageBox.Show("Deseja finalizar a EDIÇÃO ?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao EDITAR cliente: {ex.Message}");
            }
        }
        protected virtual void OnClienteEditado(EventArgs e)
        {
            ClienteEditado?.Invoke(this, e);
        }

        private void BtnCancelarEdicaoRegistro_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
