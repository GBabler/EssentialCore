﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using EssentialCore.CLASSE;
using EssentialCore.REPOSITORIO;

namespace EssentialCore.FORMULARIOS
{
    public partial class FrmListaDeClientes : Window
    {
        FrmCadastoCliente cadastroCliente = new FrmCadastoCliente();
        FrmCadastoCliente editarCliente = new FrmCadastoCliente();
        int idCliente = 0;
        public FrmListaDeClientes()
        {
            InitializeComponent();
            ExibirDados();
        }

        private void BtnInserirCliente_Click(object sender, RoutedEventArgs e)
        {
            // Inscreva-se no evento ClienteCadastrado
            cadastroCliente.ClienteCadastrado += (s, args) => ExibirDados();

            if (cadastroCliente != null && cadastroCliente.IsVisible)
            {
                cadastroCliente.Focus();
            }
            else
            {
                // Se não estiver aberta, crie uma nova instância
                cadastroCliente = new FrmCadastoCliente();
                cadastroCliente.ClienteCadastrado += (s, args) => ExibirDados();

                // Use ShowDialog() para bloquear a janela principal
                cadastroCliente.ShowDialog();
            }


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
            txtId.Text = "";
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

                var testeando = OpcaoBuscaCliente.Text.ToString();

                    if (OpcaoBuscaCliente.Text.ToString() == "Id")
                    {
                        if (int.TryParse(txtId.Text, out int id))
                        {
                            dt = SQLITEDAL.GetCliente(id);
                            dgClientes.ItemsSource = dt.DefaultView;
                        }
                        else
                        {
                            ExibirDados();
                        }
                    }
                    else if (OpcaoBuscaCliente.Text.ToString() == "Nome")
                    {
                        // Lógica para buscar por Nome
                        string nome = txtId.Text;
                        dt = SQLITEDAL.GetClienteNome(nome);
                        dgClientes.ItemsSource = dt.DefaultView;
                    }

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

            if (OpcaoBuscaCliente.Text.ToString() == "Id")
            {
                if (!char.IsDigit(e.Text, 0))
                {
                    // Se não for um número, marca o evento como manipulado para evitar a entrada
                    e.Handled = true;
                }
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
                                FrmEditarCliente editarCliente = new FrmEditarCliente();

                                try
                                {
                                    editarCliente.idCliente.Content = Convert.ToInt32(dgv.Id);
                                    editarCliente.nomeCompleto.Text = dgv.Nome;
                                    editarCliente.celular.Text = dgv.Celular;
                                    editarCliente.endereco.Text = dgv.Endereco;
                                    editarCliente.numeroEnd.Text = dgv.NumEnd;


                                    editarCliente.ClienteEditado += (s, args) => ExibirDados();
                                    editarCliente.Show();
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
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

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}