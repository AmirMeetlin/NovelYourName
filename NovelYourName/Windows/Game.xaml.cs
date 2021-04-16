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
using System.Media;

namespace NovelYourName.Windows
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        SoundPlayer Player = new SoundPlayer();
        public Game()
        {
            InitializeComponent();
            StartMusic();
            SettingGameUi();
            ToggleBtnBeginContent();
            bgVideo.Play();
        }
        
        private void btnBegin_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenuVisibility();
            ToggleBtnBeginContent();
            brdrMainMenu.Visibility = Visibility.Hidden;
            bgImage.Visibility = Visibility.Visible;
            bgVideo.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            StopMusic();

        }
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(LocalStorage.numOfPage) == 27)
            {
                brdrChoise1_1.Visibility = Visibility.Visible;
                brdrChoise1_2.Visibility = Visibility.Visible;
                btnChoise1_1.Visibility = Visibility.Visible;
                btnChoise1_2.Visibility = Visibility.Visible;
                brdrPause.Visibility = Visibility.Visible;
            }
            else    if (Convert.ToInt32(LocalStorage.numOfPage) < LocalStorage.maxNumOfPage - 1)
            {
                LocalStorage.numOfPage = Convert.ToString(Convert.ToInt32(LocalStorage.numOfPage) + 1);
                SettingGameUi();
            }

            
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(LocalStorage.numOfPage) > 0){
                LocalStorage.numOfPage = Convert.ToString(Convert.ToInt32(LocalStorage.numOfPage) - 1);
                SettingGameUi();
            }
            
        }
        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveGame.SaveMe();
        }
        private void btnRepeatEvent(object sender, RoutedEventArgs e)
        {
            LocalStorage.numOfPage = "0";
            SettingGameUi();
            ToggleMenuVisibility();
            SaveGame.SaveMe();
            brdrMainMenu.Visibility = Visibility.Hidden;
            bgImage.Visibility = Visibility.Visible;
            bgVideo.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            StopMusic();
        }
        private void btnMenuEvent(object sender, RoutedEventArgs e)
        {
            brdrPause.Visibility = Visibility.Visible;
            brdrMenu.Visibility = Visibility.Visible;
            gridDialogWindow.Visibility = Visibility.Hidden;
        }
        
        private void SettingGameUi()
        {
            List<GameDialogues> GameDialoduesList = new List<GameDialogues>();

            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Этот звонок мне не знаком. Так подумалось мне сквозь сон. Проснуться окончательно ? Но хочется поспать ещё. Вчера всю ночь писал картину — так увлёкся, что просидел до рассвета...",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Мицуха Миямидзу",
                NameColor = "#FDBDBA",
                DialogueText = "— Эй! Та́ки-кун!",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Кто-то зовёт меня по имени. Женский голос... Женский?",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Мицуха Миямидзу",
                NameColor = "#FDBDBA",
                DialogueText = "— Таки, Таки!",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Реальный голос. И похоже, вот-вот сорвётся в рыдания. Дрожит от горя, точно мерцающий свет далёкой звезды.",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Мицуха Миямидзу",
                NameColor = "#FDBDBA",
                DialogueText = "— Ты... не помнишь меня?",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Вопрос обращён ко мне. Тревожный и очень настойчивый. Но я не знаю, кто это.",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Электричка вдруг останавливается, открываются двери. Ах да! Я же ехал в поезде. Но вспомнил об этом уже на забитом людьми перроне. Я чувствую на себе чей-то пристальный взгляд. Какая-то девчонка в школьной форме уставилась на меня в упор, но людской поток уносит её прочь, всё дальше и дальше.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame1.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Мицуха Миямидзу",
                NameColor = "#FDBDBA",
                DialogueText = "— Меня зовут Ми́цуха! — кричит она, распускает плетёный шнурок, что стягивал волосы в хвост у неё на затылке, и те падают на её плечи. Я невольно протягиваю к ней руку.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame2.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Чистый оранжевый свет, подобный цвету заката на стене поезда. Я проталкиваюсь сквозь толпу и как можно крепче хватаюсь за этот свет...",
                ImageSource = "/Assets/Images/Backgrounds/BGGame3.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "И тут я просыпаюсь.",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "А эхо от её голоса так и звенит у меня в ушах",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "«Меня зовут Мицуха»?",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Ни этого имени, ни самой девчонки я не знаю. Но как же отчаянно она кричала. Эти широко распахнутые глаза прямо передо мной, незнакомая школьная форма. Так отчаянно, словно пыталась удержать не что-нибудь, а свою судьбу...",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Впрочем, ладно. Это всего лишь сон. Если подумать, я уже плохо помню её лицо. И звук её голоса больше меня не тревожит.",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "И всё-таки...",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "И всё-таки, почему так бешено колотится сердце? И откуда такая странная тяжесть в груди? И эта испарина вдруг по всему телу? Пожалуй, для начала стоит вдохнуть поглубже",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана",
                NameColor = "#FFDF84",
                DialogueText = "— Уф-ф-ф?..",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Что такое? Нос и горло стали словно чужими. Будто сузились. И грудь как-то странно потяжелела. То есть буквально, физически. Я опускаю глаза, осматриваю себя. И вижу ложбинку меж двух грудей.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame4.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Ложбинку меж двух грудей?!",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "В утреннем свете отчётливо белеют две пышные округлости. А между ними пролегает глубокая, похожая на озерцо, голубоватая тень.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Этого не может быть.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Я это твёрдо знаю. Так же твёрдо и ясно, как, например, то, что яблоки падают с деревьев на землю.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Я в шоке. «Ох-хо-хо», — думаю. Да что же это творится? Я начинаю судорожно ощупывать себя... Ну это и штука, женский организм...",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Ёцуха Миямидзу",
                NameColor = "#98FB98",
                DialogueText = "— Сестрёнка, ты что тут делаешь?",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Я оборачиваюсь на голос — и вижу маленькую девчушку, которая отодвинула боковую ширму и встала в проходе. Продолжая себя ощупывать, я честно говорю, что думаю.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame6.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана ",
                NameColor = "#FFDF84",
                DialogueText = "— Всё как настоящее... Что?!",
                ImageSource = "/Assets/Images/Backgrounds/BGGame5.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана (про себя)",
                NameColor = "#FFDF84",
                DialogueText = "Я снова смотрю на девочку. Лет ей, наверное, нет ещё и десяти, с двумя косичками, раскосыми глазами и, похоже, весьма нахальная.",
                ImageSource = "/Assets/Images/Backgrounds/BGGame6.jpg"
            });
            //28
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Таки Татибана ",
                NameColor = "#FFDF84",
                DialogueText = "— Сестрёнка? — повторяю я вслед за ней, показывая на себя пальцем. Выходит, мы с нею сёстры? Девчушка смотрит на меня, как на сумасшедшего",
                ImageSource = "/Assets/Images/Backgrounds/BGGame6.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Ёцуха Миямидзу",
                NameColor = "#98FB98",
                DialogueText = "— Кончай валяться! — кричит она мне. — Зав-тра-кать! Бегом",
                ImageSource = "/Assets/Images/Backgrounds/BGGame6.jpg"
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "",
                NameColor = "#98FB98",
                DialogueText = "— Бум-м! — с треском задвинулась ширма.",
                ImageSource = ""
            });
            GameDialoduesList.Add(new GameDialogues
            {
                Name = "Амир",
                NameColor = "#1164B4",
                DialogueText = "Поздравляю, вы прошли демо версию нашей игры!!",
                ImageSource = ""
            });
            LocalStorage.maxNumOfPage = GameDialoduesList.Count;
            tbName.Text = GameDialoduesList[Convert.ToInt32(LocalStorage.numOfPage)].Name;
            tbName.Foreground = new SolidColorBrush() { Color = (Color)(ColorConverter.ConvertFromString(GameDialoduesList[Convert.ToInt32(LocalStorage.numOfPage)].NameColor))};
            tbText.Text = GameDialoduesList[Convert.ToInt32(LocalStorage.numOfPage)].DialogueText;
            bgImage.Source = new BitmapImage(new Uri(GameDialoduesList[Convert.ToInt32(LocalStorage.numOfPage)].ImageSource, UriKind.Relative));
        }
        private void ToggleBtnBeginContent()
        {
            if (Convert.ToInt32(LocalStorage.numOfPage) == 0)
            {
                btnBegin.Content = "Начать игру";
            }
            else
            {
                btnBegin.Content = "Продолжить игру";
            }
        }
        private void ToggleMenuVisibility()
        {
            if (gridMainMenu.Visibility == Visibility.Hidden)
            {
                gridMainMenu.Visibility = Visibility.Visible;
                gridDialogWindow.Visibility = Visibility.Hidden;
                btnNext.Visibility = Visibility.Hidden;
            }
            else
            {
                gridMainMenu.Visibility = Visibility.Hidden;
                gridDialogWindow.Visibility = Visibility.Visible;
                btnNext.Visibility = Visibility.Visible;
            }
        }
        private void StartMusic()
        {
            Player.SoundLocation = "Data/Music/MainMenu.wav";
            Player.Play();
        }
        private void StopMusic()
        {
            Player.Stop();
        }

        private void btnBegin_MouseEnter(object sender, MouseEventArgs e)
        {
            btnBegin.BorderThickness = new Thickness(0,0,0,4);
        }

        private void btnBegin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnBegin.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnRepeat_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRepeat.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnRepeat_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRepeat.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnOptions_MouseEnter(object sender, MouseEventArgs e)
        {
            btnOptions.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnOptions_MouseLeave(object sender, MouseEventArgs e)
        {
            btnOptions.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnQuit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQuit.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnQuit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnQuit.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnBack_MouseEnter(object sender, MouseEventArgs e)
        {
            btnBack.Foreground = Brushes.Gray;
        }

        private void btnBack_MouseLeave(object sender, MouseEventArgs e)
        {
            btnBack.Foreground = Brushes.White;
        }

        private void btnSettings_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSettings.Foreground = Brushes.Gray;
        }

        private void btnSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSettings.Foreground = Brushes.White;
        }

        private void btnSaveGame_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSaveGame.Foreground = Brushes.Gray;
        }

        private void btnSaveGame_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSaveGame.Foreground = Brushes.White;
        }

        private void btnMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenu.Foreground = Brushes.Gray;
        }

        private void btnMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenu.Foreground = Brushes.White;
        }

        private void btnMenuToGame_Click(object sender, RoutedEventArgs e)
        {
            brdrPause.Visibility = Visibility.Hidden;
            brdrMenu.Visibility = Visibility.Hidden;
            gridDialogWindow.Visibility = Visibility.Visible;
        }

        private void btnMenuToGame_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenuToGame.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnMenuToGame_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenuToGame.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnMenuToMainMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenuToMainMenu.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnMenuToMainMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenuToMainMenu.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnMenuOptions_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenuOptions.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnMenuOptions_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenuOptions.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnMenuLoad_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenuLoad.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnMenuLoad_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenuLoad.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnMenuSave_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenuSave.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnMenuSave_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenuSave.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnMenuExit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenuExit.BorderThickness = new Thickness(0, 0, 0, 4);
        }

        private void btnMenuExit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenuExit.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void btnMenuToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            brdrMenu.Visibility = Visibility.Hidden;
            brdrPause.Visibility = Visibility.Hidden;
            brdrMainMenu.Visibility = Visibility.Visible;
            gridMainMenu.Visibility = Visibility.Visible;
            bgVideo.Visibility = Visibility.Visible;
            StartMusic();
            SettingGameUi();
            ToggleBtnBeginContent();

        }

        private void bgVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;
            mediaElement.Stop();
            mediaElement.Play();
        }

        private void btnMenuLoad_Click(object sender, RoutedEventArgs e)
        {
            brdrMenu.Visibility = Visibility.Hidden;
            brdrPause.Visibility = Visibility.Hidden;
            ToggleMenuVisibility();
            ToggleBtnBeginContent();
            brdrMainMenu.Visibility = Visibility.Hidden;
            bgImage.Visibility = Visibility.Visible;
            bgVideo.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            StopMusic();
        }

        private void btnMenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChoise1_2_MouseEnter(object sender, MouseEventArgs e)
        {
            brdrChoise1_2.Width = 550;
            brdrChoise1_2.Height = 65;
        }

        private void btnChoise1_2_MouseLeave(object sender, MouseEventArgs e)
        {
            brdrChoise1_2.Width = 600;
            brdrChoise1_2.Height = 70;
        }

        private void brdrChoise1_1_MouseEnter(object sender, MouseEventArgs e)
        {
            brdrChoise1_1.Width = 550;
            brdrChoise1_1.Height = 65;
        }

        private void brdrChoise1_1_MouseLeave(object sender, MouseEventArgs e)
        {
            brdrChoise1_1.Width = 600;
            brdrChoise1_1.Height = 70;
        }

        private void btnChoise1_1_Click(object sender, RoutedEventArgs e)
        {
            brdrChoise1_1.Visibility = Visibility.Hidden;
            brdrChoise1_2.Visibility = Visibility.Hidden;
            btnChoise1_1.Visibility = Visibility.Hidden;
            btnChoise1_2.Visibility = Visibility.Hidden;
            brdrPause.Visibility = Visibility.Hidden;
            LocalStorage.numOfPage = Convert.ToString(Convert.ToInt32(LocalStorage.numOfPage) + 1);
            SettingGameUi();
        }

        private void btnChoise1_2_Click(object sender, RoutedEventArgs e)
        {
            brdrChoise1_1.Visibility = Visibility.Hidden;
            brdrChoise1_2.Visibility = Visibility.Hidden;
            btnChoise1_1.Visibility = Visibility.Hidden;
            btnChoise1_2.Visibility = Visibility.Hidden;
            brdrPause.Visibility = Visibility.Hidden;
            LocalStorage.numOfPage = Convert.ToString(Convert.ToInt32(LocalStorage.numOfPage) + 1);
            SettingGameUi();
        }
    }
}
