using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract4_Taztdinova
{
    public partial class MainWindow : Window
    {
        private Student currentStudent = new Student();

        public MainWindow()
        {
            InitializeComponent();
            NewStudent();
        }

        private string GetPath(int id)
        {
            return $"{id}.json";
        }

        private int GenerateId()
        {
            int id = 1;
            while (File.Exists(GetPath(id)))
            {
                id++;
            }
            return id;
        }

        private void NewStudent()
        {
            currentStudent = new Student();
            currentStudent.Id = GenerateId();
            DataContext = currentStudent;
        }

        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            NewStudent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonSerializer.Serialize(currentStudent);
            File.WriteAllText(GetPath(currentStudent.Id), json);
            MessageBox.Show("Студент сохранён");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SearchBox.Text, out int id))
            {
                MessageBox.Show("Введите ID (число)");
                return;
            }

            string path = GetPath(id);
            if (!File.Exists(path))
            {
                MessageBox.Show("Студент с таким ID не найден");
                return;
            }

            string json = File.ReadAllText(path);
            currentStudent = JsonSerializer.Deserialize<Student>(json)!;
            DataContext = currentStudent;
        }
    }
}