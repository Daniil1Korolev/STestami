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

namespace remont
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public remontEntities db = new remontEntities();
        public MainWindow()
        {
            InitializeComponent();
            Data_Reload();
        }

        public void Data_Reload()
        {
            var AppList = db.Applications.ToList();
            dgApplication.SelectedValuePath = "ID";
            dgApplication.ItemsSource = AppList;
            dgApplication.SelectionMode = DataGridSelectionMode.Single;

            var StatusList = db.Status.ToList();    
            Status.ItemsSource = StatusList;
            Status.SelectedIndex = 0;
            Status.DisplayMemberPath = "NameStatus";
            Status.SelectedValuePath = "ID";

            var ExecutorList = db.Executor.ToList();
            Executor.ItemsSource = ExecutorList;
            Executor.SelectedIndex = 0;
            Executor.DisplayMemberPath = "NameExecutor";
            Executor.SelectedValuePath = "ID";

            Functional functional = new Functional();

            Kolvo.Text = functional.CountApplication().ToString();

            //Kolvo.Text = db.Applications.Where(a => a.Status.NameStatus == "Выполнено").ToList().Count.ToString();
        }

        private void dgApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgApplication.SelectedItem != null)
            {
                Applications selectedItem = (Applications)dgApplication.SelectedItem;
                Opisanie.Text = selectedItem.Descriotion;
                Status.SelectedItem = selectedItem.Status;
                Executor.SelectedItem = selectedItem.Executor;
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var AppList = db.Applications.Where(a => a.Problem.Contains(Search.Text)).ToList();
            dgApplication.SelectedValuePath = "ID";
            dgApplication.ItemsSource = AppList;
            dgApplication.SelectionMode = DataGridSelectionMode.Single;
        }

        

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dgApplication.SelectedItem != null)
            {
                Applications selectedItem = (Applications)dgApplication.SelectedItem;
                selectedItem.Descriotion = Opisanie.Text;
                selectedItem.Status = (Status)Status.SelectedItem;
                selectedItem.Executor = (Executor)Executor.SelectedItem;

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Запись успешно обновлена.");
                    Data_Reload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении записи: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для обновления.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgApplication.SelectedItem != null)
            {
                Applications selectedItem = (Applications)dgApplication.SelectedItem;
                db.Applications.Remove(selectedItem);

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Запись успешно удалена.");
                    Data_Reload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }
    }
}
