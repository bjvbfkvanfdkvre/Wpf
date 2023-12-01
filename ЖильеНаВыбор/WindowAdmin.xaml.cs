using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace ЖильеНаВыбор
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window

    {
        ObservableCollection<Квартиры> ListТовар;
       
        private bool isDirty = true;
        public WindowAdmin()
        {
            InitializeComponent();
            DataGridKvartira.ItemsSource = ZilyeEntities.GetContext().Квартиры.ToList();
            DataGridArenda.ItemsSource = ZilyeEntities.GetContext().Аренда.ToList();
            ListТовар = new ObservableCollection<Квартиры>();


        }
        private void GetTovar()
        {
            var queryTovar1 = from t in ZilyeEntities.GetContext().Квартиры
                              orderby t.КодКвартиры
                              select t;
            foreach (Квартиры t in queryTovar1)
            {
                ListТовар.Add(t);

            }
            DataGridKvartira.ItemsSource = ListТовар;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetTovar();
            DataGridKvartira.SelectedIndex = 0;
        }

        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridKvartira.BeginEdit();
            DataGridArenda.BeginEdit();
            isDirty = false;
        }
        private void EditCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            try
            {
                ZilyeEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено");
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message.ToString());

            }
            DataGridKvartira.IsReadOnly = true;
            DataGridArenda.IsReadOnly = true;
            isDirty = true;

        }
        private void SaveCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }
        private void UndoCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }
        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var context = ZilyeEntities.GetContext();
            var changedEntries = context.ChangeTracker.Entries()
                .Where (x => x.State != EntityState.Unchanged).ToList();
            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                        break;
                        case EntityState.Deleted:
                        entry.State= EntityState.Unchanged;
                        break;
                }
            }
            DataGridKvartira.ItemsSource = null;
            DataGridKvartira.ItemsSource=ZilyeEntities.GetContext().Квартиры.ToList();
                DataGridArenda.ItemsSource = null;
            DataGridArenda.ItemsSource = ZilyeEntities.GetContext().Аренда.ToList();
            MessageBox.Show("Отмена действия");
            isDirty = true;
            DataGridKvartira.IsReadOnly = true;
            DataGridArenda.IsReadOnly = true;
        }
        private void RefreshCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void RefreshCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = false;

            DataGridKvartira = null;
            DataGridArenda =null;

            DataGridKvartira.ItemsSource = ZilyeEntities.GetContext().Квартиры.ToList();
            DataGridArenda.ItemsSource = ZilyeEntities.GetContext().Аренда.ToList();
        }
        private void KvartiraButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridKvartira.Visibility=Visibility.Visible;
            DataGridArenda.Visibility = Visibility.Hidden;
        }
        private void ArendaButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridKvartira.Visibility = Visibility.Hidden;
            DataGridArenda.Visibility = Visibility.Visible;
        }
        private void NewCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            
            int maxIDTovar = (from us in ZilyeEntities.GetContext().Квартиры
                              select us.КодКвартиры).Max();
            var agr = new Квартиры();
            agr.КодКвартиры = maxIDTovar + 1;
            
            agr.Описание = "не задано";
            agr.Цена = 0;
            agr.Этаж = "не задано";
            agr.Адрес = "не задано";
            agr.НомерКвартиры = "?";
            agr.Фото = null;

            try
            {
                ZilyeEntities.GetContext().Квартиры.Add(agr);
                ListТовар.Add(agr);
                isDirty = false;
            }
            catch
            {
                throw new ApplicationException("Ошибка добавления новой квартиры в контекст данных");
            }
        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Квартиры emp = DataGridKvartira.SelectedItem as Квартиры;
            if (emp != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить квартиру:" + emp.КодКвартиры,
                    "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    ZilyeEntities.GetContext().Квартиры.Remove(emp);
                    DataGridKvartira.SelectedIndex = DataGridKvartira.SelectedIndex == 0 ? 1 : DataGridKvartira.SelectedIndex - 1;
                    ListТовар.Remove(emp);
                    ZilyeEntities.GetContext().SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }
        private void DeleteCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
    }
}
