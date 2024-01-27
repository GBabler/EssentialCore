using System;
using System.Data;
using System.Windows;
using EssentialCore.CLASSE;
using EssentialCore.REPOSITORIO;

namespace EssentialCore.FORMULARIOS
{
    public partial class FrmListaDeClientes : Window
    {
        public FrmListaDeClientes()
        {
            InitializeComponent();
            ExibirDados();
        }

        private void BtnInserirCliente_Click(object sender, RoutedEventArgs e)
        {
            FrmCadastoCliente cadastroCliente = new FrmCadastoCliente();

            // Inscreva-se no evento ClienteCadastrado
            cadastroCliente.ClienteCadastrado += (s, args) => ExibirDados();

            cadastroCliente.ShowDialog();
        }

        private void ExibirDados()
        {
            try
            {
                DataTable dt = SQLITEDAL.GetClientes();
                dgClientes.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private void BtnRecarregarForm_Click(object sender, RoutedEventArgs e)
        {
            // Recarrega os dados
            ExibirDados();
        }

        private void BtnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Adicione a lógica de edição conforme necessário
        }

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                DataTable dt = new DataTable();
                int id = Convert.ToInt32(txtId.Text);

                dt = SQLITEDAL.GetCliente(id);
                dgClientes.ItemsSource = dt.DefaultView;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnExcluirCliente_Click(object sender, RoutedEventArgs e)
        {
            // Adicione a lógica de exclusão conforme necessário
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                // Se não for um número, marca o evento como manipulado para evitar a entrada
                e.Handled = true;
            }
        }
    }
}
