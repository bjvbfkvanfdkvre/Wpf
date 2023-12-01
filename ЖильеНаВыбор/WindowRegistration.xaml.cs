using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace ЖильеНаВыбор
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();
        }
        private void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {
            bool existsLogin = false;
            ZilyeEntities dbhotel = new ZilyeEntities();
            using (dbhotel)
            {
                var users = dbhotel.Пользователи;
                foreach (Пользователи u in users)
                {
                    if (tbLogin.Text == u.Логин)
                    {
                        MessageBox.Show("Такой логин уже существует");
                        existsLogin = true;
                    }
                }
            }
            if (existsLogin == false)
            {
                ZilyeEntities dbhotel1 = new ZilyeEntities();
                using (dbhotel1)
                {
                    int maxIDUser = (from us in dbhotel1.Пользователи
                                     select us.КодПользователя).Max();
                    Пользователи user = new Пользователи();
                    user.Логин = tbLogin.Text;
                    user.Пароль = GetHash(tbPassword.Password);
                    user.Тип = "пользователь";
                    user.Фамилия = tbSurname.Text;
                    user.Имя = tbName.Text;
                    user.Отчество = tbSecondName.Text;
                    user.Почта = tbMail.Text;
                    user.Телефон = tbNumber.Text;
                    user.КодПользователя = maxIDUser + 1;
                    dbhotel1.Пользователи.Add(user);
                    dbhotel1.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!");
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
            }
        }
        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
