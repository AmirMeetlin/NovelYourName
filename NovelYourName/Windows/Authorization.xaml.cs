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
using System.Windows.Shapes;
using System.IO;
using NovelYourName.Windows;

namespace NovelYourName.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Логин")
            {
                textBox.Text = "";
            }
        }
        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "tbLog" && textBox.Text == "")
            {
                tbLog.Text = "Логин";
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLog.Text))
            {
                MessageBox.Show("Введите текст!");
            }
            else if (string.IsNullOrWhiteSpace(tbPas.Password))
            {
                MessageBox.Show("Введите текст!");
            }
            else
            {
                bool erorr = true;
                List<person> PersonList = new List<person>();
                using (StreamReader sr = new StreamReader("Data/Data.txt"))
                {
                    for (int i = 0; i < File.ReadLines("Data/Data.txt").Count(); i++)
                    {
                        string str = sr.ReadLine();
                        if (str.ToString().Length > 4)
                        {
                            string[] split = str.Split(';');
                            PersonList.Add(new person
                            {
                                Id = i,
                                Login = split[0],
                                Password = split[1],
                                NumOfPage = split[2]
                            });
                        }
                    }
                }
                for (int i = 0; i < PersonList.Count; i++)
                {
                    if (tbLog.Text == PersonList[i].Login && tbPas.Password == PersonList[i].Password)
                    {
                        LocalStorage.id = i;
                        LocalStorage.login = PersonList[i].Login;
                        LocalStorage.password = PersonList[i].Password;
                        LocalStorage.numOfPage = PersonList[i].NumOfPage;
                        this.Close();
                        Game game = new Game();
                        game.ShowDialog();
                        erorr = false;
                        i = PersonList.Count;
                    }
                    else
                    {
                        erorr = true;

                    }
                }
                if (erorr)
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            StartWindow startWindow = new StartWindow();
            startWindow.ShowDialog();
        }

        private void btnBack_MouseEnter(object sender, MouseEventArgs e)
        {
            btnBack.BorderThickness = new Thickness(0, 0, 0, 2);
        }

        private void btnBack_MouseLeave(object sender, MouseEventArgs e)
        {
            btnBack.BorderThickness = new Thickness(0, 0, 0, 0);
        }
    }
}
