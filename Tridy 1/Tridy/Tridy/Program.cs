using System;
using System.IO;
using System.Collections.Generic;

namespace Tridy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Nedostatek argumentu");
                return;
            }

            string title = args[0];
            bool completed = args[1].Trim().ToLower() == "splneno";

            MyTask task = new MyTask(title, completed, 1);

            var tasks = new Dictionary<int, MyTask>();
            tasks[task.Id] = task;

            string text = TasksToString(tasks);
            File.WriteAllText("task.txt", text);

            // Pro ukázku načtení zpět:
            string[] lines = File.ReadAllLines("task.txt");
            var loadedTasks = LinesToTasks(lines);
        }

        static string TasksToString(Dictionary<int, MyTask> tasks)
        {
            List<string> lines = new List<string>();
            foreach (var task in tasks.Values)
            {
                lines.Add($"{task.Title},{task.Completed},{task.Id}");
            }
            return string.Join(Environment.NewLine, lines);
        }

        static Dictionary<int, MyTask> LinesToTasks(string[] lines)
        {
            Dictionary<int, MyTask> tasks = new Dictionary<int, MyTask>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 3) continue;

                string title = parts[0].Trim();
                bool completed = parts[1].Trim().ToLower() == "true";
                if (!int.TryParse(parts[2].Trim(), out int id)) continue;

                MyTask task = new MyTask(title, completed, id);
                tasks[id] = task;
            }
            return tasks;
        }
    }
}
