using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EssentialCore.FORMULARIOS;
using EssentialCore.REPOSITORIO;


namespace EssentialCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SQLITEDAL.CriarBancoSQLite();
            SQLITEDAL.CriarTabelasSQLite();
            
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (nomeLogin.Text == "admin" && senhaLogin.Password == "admin123") 
            {
                FrmMenu menu = new FrmMenu();
                this.Close();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario ou Senha incorretos","ERRO");
            }
        }
    }
}