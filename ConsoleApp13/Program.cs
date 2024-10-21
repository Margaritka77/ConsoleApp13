using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mode = "";
            Console.WriteLine("С каким файлом будем работать? Введите имя или путь к текстовому файлу.");
            string streamToFile = Console.ReadLine();
            if (!File.Exists(streamToFile))
            {
                StreamWriter sw = new StreamWriter(streamToFile);
                sw.Close();
            }
            while (mode != "0")
            {
                Console.WriteLine("Выберите режим доступа:\n1 - Чтение из файла\n2 - Перезапись файла\n3 - Добавление записей в файл\n0 - Завершение программы");
                mode = Console.ReadLine();
                switch (mode)
                {
                    case "1":
                        StreamReader sr = new StreamReader(streamToFile);
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = sr.ReadLine();
                        }
                        sr.Close();
                        break;
                    case "2":
                        StreamWriter sw = new StreamWriter(streamToFile);
                        string text = "";
                        while (true)
                        {
                            Console.WriteLine("Что бы вы хотели записать в блокнот? Введите \"Завершить\", чтобы завершить работу программы.");
                            text = Console.ReadLine();
                            if (text.ToLower() == "завершить") break;
                            sw.WriteLine(text);
                        }
                        sw.Close();
                        break;
                    case "3":
                        sr = new StreamReader(streamToFile);
                        line = sr.ReadLine();
                        string txt = "";
                        while (line != null)
                        {
                            txt += line + '\n';
                            line = sr.ReadLine();
                        }
                        sr.Close();
                        sw = new StreamWriter(streamToFile);
                        sw.Write(txt);
                        while (true)
                        {
                            Console.WriteLine("Что бы вы хотели записать в блокнот? Введите \"Завершить\", чтобы завершить работу программы.");
                            text = Console.ReadLine();
                            if (text.ToLower() == "завершить") break;
                            sw.WriteLine(text);
                        }
                        sw.Close();
                        break;
                    case "0":
                        break;
                }
            }
        }
    }
}
