using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EssentialCore.CLASSE;
using EssentialCore.REPOSITORIO;

namespace EssentialCore.FORMULARIOS
{
    public partial class FrmListaDeClientes : Window
    {
        FrmCadastoCliente cadastroCliente = new FrmCadastoCliente();

        public FrmListaDeClientes()
        {
            InitializeComponent();
            ExibirDados();
        }

        private void BtnInserirCliente_Click(object sender, RoutedEventArgs e)
        {
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

        private void BtnAcao_Click(object sender, RoutedEventArgs e)
        {
            // Encontre o DataGrid pai
            if (dgClientes.SelectedItem != null && dgClientes.SelectedItem != "")
            {
                // Obtenha a linha selecionada
                try
                {
                    var selectedRow = (DataRowView)dgClientes.SelectedItem;

                    if (selectedRow != null)
                    {
                        

                        try
                        {
                            CLIENTE dgv = new CLIENTE();
                            dgv.Id = Convert.ToInt32(selectedRow.Row["id"]);
                            dgv.Nome = selectedRow.Row["nome"].ToString();
                            dgv.Celular = selectedRow.Row["celular"].ToString();
                            dgv.Endereco = selectedRow.Row["endereco"].ToString();
                            dgv.NumEnd = selectedRow.Row["numend"].ToString();

                            // Consulte o nome do cliente pelo ID

                            // Exiba o nome do cliente em um MessageBox
                            if (dgv.Id != null)
                            {
                                MessageBox.Show("ID: " + dgv.Id +
                                                "\nNOME: " + dgv.Nome +
                                                "\nCELULAR: " + dgv.Celular +
                                                "\nENDERECO: " + dgv.Endereco + "   Num: " + dgv.NumEnd);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("DataGrid Vazio!.");
            }
        }
    }
}
