using System;

namespace FinalProject_Task_5._6_
{
    class Program
    {
        public static void Main()
        {
            // Начало программы 
            (string name, string surname, int age, string[] pets, string[] favcolors) User;
            User = UserInput();
            PrintUser(User);


            // Сбор даннах о пользователе + основа программы
            static (string name, string surname, int age, string[] pets, string[] favcolors) UserInput()
            {
                (string name, string surname, int age, string[] pets, string[] favcolors) User;
                
                Console.WriteLine("Vvedite vashe imja: ");
                User.name = Console.ReadLine();
                
                Console.WriteLine("Vvedite vashu familiju: ");
                User.surname = Console.ReadLine();

                Console.WriteLine("Skol'ko vam let?");
                User.age = UserAge();

                User.pets = GetPet();
                
                User.favcolors = UserColors();
                
                return User;
            }


            //Метод для проверки корректности ввода возраста
            static int UserAge()
            {
                string inputstr = "";
                int age = 0;
                bool check;
 
                do
                {
                    inputstr = Console.ReadLine();
                    check = !int.TryParse(inputstr, out age) | (inputstr == "");
                    if (!check && (age < 1 | age > 100))
                    {
                        Console.Write("Vvedite korrektnoe chislo: ");
                    }
                }
                while (check | (age < 1 | age > 100));
                
                return age;
            }

            //метод для проверки корректности ввода животных и цветов
            static int UserCheck()
            {
                string inputstr = "";
                int start = 0;
                bool check;

                do
                {
                    inputstr = Console.ReadLine();
                    check = !int.TryParse(inputstr, out start) | (inputstr == "");
                    if (!check && (start < 1 | start > 15))
                    {
                        Console.Write("Vvedite korrektnoe chislo: ");
                    }
                }
                while (check | (start < 1 | start > 15));

                return start;
            }


            //Метод для ввода данных о житовных
            static string[] GetPet()
            {
                string[] pets;
                Console.WriteLine("Est' li u vas domashnije zhivotnie? da/net");
                string inputstr = String.Empty;
                do
                {
                    inputstr = Console.ReadLine();

                }
                while (!(inputstr == "net" | inputstr == "da"));

                if (inputstr == "net")
                    pets = new[] { "U vas net domashnih zhivotnih" };
                else
                {
                    Console.Write("Skol'ko u vas dimashnih zhivotnih?");
                    int petnum = UserCheck(); 
                    pets = new string[petnum];
                    for (int i = 0; i < petnum; i++)
                    {
                        Console.Write("Imja vashego {0} zhivotnogo: ", i + 1);
                        pets[i] = Console.ReadLine();
                    }
                }

                return pets;
            }

            //Метод для ввода данных о цветах
            static string[] UserColors()
            {
                string[] favcolors;
                Console.WriteLine("Est' li u vas ljubimije cveta? da/net");
                string inputstr = String.Empty;
                do
                {
                    inputstr = Console.ReadLine();
                }
                while (!(inputstr == "da" | inputstr == "net"));


                if (inputstr == "net")
                {
                    favcolors = new[] { "U vas net ljubimih cvetov" };
                }
                else
                {
                    Console.Write("Skol'ko u vas ljubimih cvetov? ");
                    int flowernum = UserCheck();
                    favcolors = new string[flowernum];
                    for (int i = 0; i < flowernum; i++)
                    {
                        Console.Write("Vash {0} cvet: ", i + 1);
                        favcolors[i] = Console.ReadLine();
                    }
                }
                
                return favcolors;
            }
            
            // Печать данных пользователя
            static void PrintUser((string name, string surname, int age, string[] pets, string[] favcolors) User)
            {
                //Поменяли цвет итоговых данных
                Console.ForegroundColor = ConsoleColor.Green; 
                
                //ФИО + возраст
                Console.WriteLine("Vashe imja: {0} \nVasha familija: {1} \nVash vozrast: {2}", User.surname, User.name, User.age);
                
                //Дом. Животные
                Console.WriteLine("Vashi domashnije zhivotnie: ");
                foreach (string i in User.pets)
                Console.WriteLine(i);
                
                //Цвета
                Console.WriteLine("Vashi ljubimije cveta: ");
                foreach (string i in User.favcolors)
                Console.WriteLine(i);

                //Вернём цвет обратно
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
