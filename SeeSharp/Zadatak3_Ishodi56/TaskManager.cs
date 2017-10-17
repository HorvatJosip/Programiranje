using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadatak3_Ishodi56
{
    class TaskManagerEventArgs : EventArgs
    {
        public List<Task> ImportantTasks { get; set; }
    }

    delegate void ImportantTaskFoundEventHandler(TaskManagerEventArgs e);

    static class TaskManager
    {
        public static event ImportantTaskFoundEventHandler ImportantTaskFound;

        private static List<Task> _tasks = new List<Task>();

        public static void LoadTasks(string filePath)
        {
            List<string> errors = new List<string>();

            try
            {
                using(var streamReader = new StreamReader(filePath))
                {
                    int lineCounter = 1;
                    string line;
                    while((line = streamReader.ReadLine()) != null)
                    {
                        //ovdje ide kod koji čita i organizira što je zapisano u file-u
                        //ovisi o našem formatiranju zadataka, što je moguće na bilo koji način
                        //ja ću koristiti format koji sam zapisao u funkciji ToFileString() u klasi Task
                        var contents = line.Split(','); //dat će mi polje sa vrijednostima koje su bile odvojene zarezima

                        //moj format zahtjeva:
                        //  da bude isključivo 4 vrijednosti po liniji (odvojenih zarezima)
                        //  da bude prvo naziv (string) pa tip zadatka (TaskCategory) pa ID zadatka (int)
                        //     i na kraju kad počinje zadatak (DateTime)
                        if(contents.Length == 4) //4 vrijednosti po liniji!
                        {
                            string name = contents[0]; //prvo mora biti ime, ovo nemremo provjeravati

                            //nakon toga ide kategorija, koja mora biti u našoj listi kategorija za zadatke - TaskCategory
                            if(Enum.TryParse(contents[1], out TaskCategory taskCategory))
                            {
                                //nakon toga ide identifikator zadatka - ID koji mora biti cijeli broj
                                if(int.TryParse(contents[2], out int id))
                                {
                                    //nakon toga treba biti napisan jedan od mnogih načina zapisa datuma i vremena
                                    if(DateTime.TryParse(contents[3], out DateTime taskStartTime))
                                    {
                                        //zadnje što moramo provjeriti je da je u budućnosti jer samo njih pratimo
                                        if (Utilities.DateTimeInFuture(taskStartTime))
                                        {
                                            _tasks.Add(new Task(id, name, taskStartTime, taskCategory));
                                        }
                                        else
                                        {
                                            //throw new WrongTaskDateTimeException();
                                            errors.Add($"The date & time on line {lineCounter} is in the past, so it won't be added to the Task List.");
                                        }
                                    }
                                    else
                                    {
                                        errors.Add($"Fourth (and last) value on line {lineCounter} must be in date & time format (for example: {DateTime.Now}).");
                                    }
                                }
                                else
                                {
                                    errors.Add($"Third value on line {lineCounter} must be an integer that represents the ID of the task.");
                                }
                            }
                            else
                            {
                                errors.Add($"Second value on line {lineCounter} must have some of the following values: {Enum.GetNames(typeof(TaskCategory))}.");
                            }
                        }
                        else
                        {
                            errors.Add($"There needs to be 4 values, separated by comas on line {lineCounter}.");
                        }

                        lineCounter++;
                    }
                }

                if (errors.Count > 0) Menu.Print("Errors while loading tasks from " + filePath, errors.ToArray());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void SaveTasks(string filePath)
        {
            try
            {
                RemoveUnwantedTasks(); //dodano iako se ne traži u zadatku
                File.WriteAllLines(filePath, _tasks.Select(task => task.ToFileString()));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void PrintTasks()
        {
            Menu.Print("Tasks", _tasks.Select(task => task.ToString()).ToArray());
        }

        public static void PrintTasks(TaskCategory category)
        {
            Menu.Print("Tasks with category " + category.ToString(),
                _tasks.Where(task => task.Category == category).Select(task => task.ToString()).ToArray());
        }

        public static void PrintTasks(int taskID)
        {
            Menu.Print("Task with id " + taskID,
                _tasks.Where(task => task.ID == taskID).Select(task => task.ToString()).ToArray());
        }

        public static void CreateNewTask()
        {
            Console.Clear();

            Console.Write("Enter task name: ");
            string name = Console.ReadLine();

            _tasks.Add(new Task(
                Utilities.AskForInt("Enter task ID"),
                name,
                Utilities.AskForDateTime("Enter task starting date & time"),
                Utilities.AskForTaskCategory()
                ));
        }

        public static void CheckTasks()
        {
            RemoveUnwantedTasks(); //dodano iako se ne traži u zadatku

            ImportantTaskFound(new TaskManagerEventArgs()
            {
                ImportantTasks = _tasks.Where(task => task.MinutesUntilStart <= 15).ToList()
            });
        }

        //ne piše u zadatku, ali da se držimo toga da moraju biti samo u budućnosti, trebali bi maknuti sve koji nisu
        private static void RemoveUnwantedTasks()
        {
            
            for (int i = _tasks.Count - 1; i >= 0; i--) //obrnuti for jer, kad se prespajaju veze, ne preskačemo elemente nakon brisanja
            {
                if (!Utilities.DateTimeInFuture(_tasks[i].StartTime))
                {
                    _tasks.RemoveAt(i);
                }
            }

        }
    }
}
