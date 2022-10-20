using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaka
{
    class paradocs
    {
        static void Main(string[] args)
        {
            int position = 0;
            List<Note> notes = new List<Note>();
            DateTime dateTime = DateTime.Now;
            while (true)
            {
 
                
                Menu(dateTime);
                Zametks(notes, dateTime);
                Console.SetCursorPosition(0, position);


                ConsoleKeyInfo k = Console.ReadKey();
                if (k.Key == ConsoleKey.DownArrow || k.Key == ConsoleKey.UpArrow)
                {
                    position = Pereclich(k, position);
                }
              
                if ((k.Key == ConsoleKey.LeftArrow || k.Key == ConsoleKey.RightArrow) && position == 0)
                {
                    dateTime = RenameData(dateTime, k);
                }
               
                if (k.Key == ConsoleKey.Enter && position == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите название заметки");
                    string name = Console.ReadLine();
                    DateTime time = dateTime;
                    
                    Console.WriteLine("Введите содержимое заметки");
                    string bank = Console.ReadLine();
                    
                    notes.Add(new Note( name, bank, time ));
                    Console.Clear();
                }

                if (k.Key == ConsoleKey.Enter && position == 2)
                {
                    Info(notes, dateTime, position);
                }

            }
            static int Pereclich(ConsoleKeyInfo key, int position)
            {
                int prePosition = 0;

                if (key.Key == ConsoleKey.UpArrow) 
                {
                    if (position == 0)
                    {
                        position = 0;
                        prePosition = 0;
                    }

                    else
                    {
                        prePosition = position;
                        position--;
                    }
                }

                else if (key.Key == ConsoleKey.DownArrow) 
                {
                    prePosition = position;
                    position++;
                }

                Console.SetCursorPosition(0, prePosition);
                Console.Write("  ");
                Console.SetCursorPosition(0, position);
                Console.Write("->");

                return position;
            }
            
            static void Menu(DateTime dateTime)
            {
                Console.SetCursorPosition(3, 0);
                Console.WriteLine($"Дата: {dateTime}");
                Console.SetCursorPosition(3, 1);
                Console.WriteLine("Создать новую заметку");

            }
            static void Zametks(List<Note> list, DateTime date)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].time == date)
                    {
                        Console.WriteLine(i+1+"." + list[i].name);
                    }
                    else
                    {
                        for (int g = 0; g < 50; g++)
                        {
                            Console.Write("  ");
                        }
                        
                    }
                }


            }
            static DateTime RenameData(DateTime RenameDate, ConsoleKeyInfo key)
            {
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    RenameDate = RenameDate.AddDays(-1);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    RenameDate = RenameDate.AddDays(1);
                }
                return RenameDate;
            }

            static void Info(List<Note> notes, DateTime dateTime, int position)
            {
                List<Note> infoNotes = new List<Note>();

                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(0, 1 + position + i);

                    for (int j = 0; j < 60; j++)
                    {
                        Console.Write("  ");
                    }
                }

                for (int i = 0; i < notes.Count; i++)
                {
                    if (notes[i].time == dateTime)
                    {
                        infoNotes.Add(notes[i]);
                    }
                }

                Console.SetCursorPosition(2, position + 1);
                Console.WriteLine("Название: " + infoNotes[position - 2].name);
                Console.SetCursorPosition(2, position + 2);
                Console.WriteLine("Дата: " + infoNotes[position - 2].time);
                Console.SetCursorPosition(2, position + 3);
                Console.WriteLine("Содержание: " + infoNotes[position - 2].bank);
            }
        }   
    }
}