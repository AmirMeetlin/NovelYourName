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

namespace NovelYourName.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewProfile.xaml
    /// </summary>
    public partial class NewProfile : Window
    {
        public NewProfile()
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
                    if(File.ReadLines("Data/Data.txt").Count()>0)
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
                        for (int i = 0; i < PersonList.Count; i++)
                        {
                            if (tbLog.Text == PersonList[i].Login)
                            {
                                erorr = true;
                                i = PersonList.Count;
                            }
                            else
                            {
                                LocalStorage.id = i;
                                LocalStorage.login = PersonList[i].Login;
                                LocalStorage.password = PersonList[i].Password;
                                LocalStorage.numOfPage = PersonList[i].NumOfPage;
                                erorr = false;
                            }
                        }
                    }
                    else
                    {
                        PersonList.Add(new person
                        {
                            Id = 0,
                            Login = tbLog.Text,
                            Password = tbPas.Password,
                            NumOfPage = "0"
                        });
                        LocalStorage.id = 0;
                        LocalStorage.login = PersonList[0].Login;
                        LocalStorage.password = PersonList[0].Password;
                        LocalStorage.numOfPage = PersonList[0].NumOfPage;
                        erorr = false;
                    }
                }
                if (erorr)
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                }
                else
                {
                    using (StreamWriter SW = new StreamWriter(File.Open("Data/Data.txt", FileMode.Append)))
                    {
                        SW.WriteLine(tbLog.Text + ";" + tbPas.Password + ";0");
                    }
                    this.Close();
                    Game game = new Game();
                    game.ShowDialog();
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
