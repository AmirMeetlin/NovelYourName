using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NovelYourName
{
    static class SaveGame
    {
        public static void SaveMe()
        {
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
            PersonList[LocalStorage.id].Login = LocalStorage.login;
            PersonList[LocalStorage.id].Password = LocalStorage.password;
            PersonList[LocalStorage.id].NumOfPage = LocalStorage.numOfPage;
            using (StreamWriter SW = new StreamWriter("Data/Data.txt"))
            {
                SW.Write("");
            }
            using (StreamWriter SW = new StreamWriter(File.Open("Data/Data.txt", FileMode.Append)))
            {
                for (int i = 0; i < PersonList.Count; i++)
                {
                    SW.WriteLine(PersonList[i].Login+";"+ PersonList[i].Password + ";" + PersonList[i].NumOfPage);
                }
                
            }

            // код функции
        }
    }
}
