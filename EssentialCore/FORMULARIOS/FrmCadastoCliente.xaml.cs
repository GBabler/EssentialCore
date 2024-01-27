using EssentialCore.CLASSE;
using EssentialCore.REPOSITORIO;
using System;
using System.Windows;

namespace EssentialCore.FORMULARIOS
{
    /// <summary>
    /// Lógica interna para FrmCadastoCliente.xaml
    /// </summary>
    public partial class FrmCadastoCliente : Window
    {
        public event EventHandler ClienteCadastrado;

        public FrmCadastoCliente()
        {
            InitializeComponent();
        }

        private void BtnRegistarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nomeCompleto.Text) || string.IsNullOrWhiteSpace(celular.Text))
                {
                    MessageBox.Show("Campos obrigatórios vazios!");
                    return;
                }

                CLIENTE cliente = new CLIENTE
                {
                    Nome = nomeCompleto.Text,
                    Endereco = endereco.Text,
                    NumEnd = numeroEnd.Text,
                    Celular = celular.Text
                };

                SQLITEDAL.Add(cliente);

                nomeCompleto.Clear();
                endereco.Clear();
                numeroEnd.Clear();
                celular.Clear();
                OnClienteCadastrado(EventArgs.Empty);
                var resultado = MessageBox.Show("Deseja cadastrar um novo Cliente?", "Sucesso!!!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar cliente: {ex.Message}");
            }
        }

        protected virtual void OnClienteCadastrado(EventArgs e)
        {
            ClienteCadastrado?.Invoke(this, e);
        }

        private void BtnCancelarRegistro_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
