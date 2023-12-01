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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ЖильеНаВыбор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int tries;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (tbxLogin_.Text == null)
            {
                MessageBox.Show("Введите логинь");
                return;
            }
            if (tbxPassword_.Password == null)
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            Пользователи userData = new Пользователи();
            var tbxPasswordMD5 = WindowRegistration.GetHash(tbxPassword_.Password);
            userData = ZilyeEntities.GetContext().Пользователи.Where(u => u.Логин == tbxLogin_.Text && u.Пароль == tbxPasswordMD5).FirstOrDefault();

            if (tries >= 3 && userData == null)
            {
                DateTime date = DateTime.Now;
                MessageBox.Show($"Вы ввели неправильные данные больше трех раз. Система заблокированна на {10} секунд");
                while (date.AddSeconds(10) > DateTime.Now)
                {
                    tbxLogin_.IsEnabled = false;
                    tbxPassword_.IsEnabled = false;
                    BtnOK.IsEnabled = false;
                }
                tbxLogin_.IsEnabled = true;
                tbxPassword_.IsEnabled = true;
                BtnOK.IsEnabled = true;
            }
            if (userData == null)
            {
                MessageBox.Show("Данные введены неверно, либо пользователя не существует");
                tries++;
                return;
            }
            DataTransfer.userID = userData.КодПользователя;
            DataTransfer.Name = userData.Имя;
            DataTransfer.Surname = userData.Фамилия;
            DataTransfer.Patronic = userData.Отчество;


            if (userData.Тип == "админ")
            {
                {
                    WindowAdmin window = new WindowAdmin();
                    window.Show();
                    MessageBox.Show("Добро пожаловать, администратор!");
                    this.Close();
                }
            }
            else
                if (userData.Тип == "пользователь")
            {
                WindowUser window = new WindowUser();
                window.Show();
                MessageBox.Show("Добро пожаловать!");
                
            }
        }
        public void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistration window = new WindowRegistration();
            window.Show();
            this.Close();
        }
        public void BtnWatch_Click(object sender, RoutedEventArgs e)
        {
            WindowUser windowUser = new WindowUser();
            windowUser.Show();
            this.Close();
        }
    }
}
