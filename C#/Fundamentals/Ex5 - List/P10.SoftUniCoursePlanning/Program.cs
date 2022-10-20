using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> scheduleLessons = Console.ReadLine()
                                           .Split(", ")
                                           .ToList();

            string command;

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] cmdArgs = command.Split(':');
                string currCmd = cmdArgs[0];
                string lessonTitle = cmdArgs[1];

                bool lessonExists = scheduleLessons.Contains(lessonTitle);

                if (currCmd == "Add")
                {
                    if (!lessonExists)
                    {
                        scheduleLessons.Add(lessonTitle);
                    }
                }
                else if (currCmd == "Insert")
                {
                    int index = int.Parse(cmdArgs[2]);

                    if (!lessonExists)
                    {
                        scheduleLessons.Insert(index, lessonTitle);
                    }
                }
                else if (currCmd == "Remove")
                {
                    if (lessonExists)
                    {
                        if (scheduleLessons.Contains(lessonTitle + "-Exercise"))
                        {
                            scheduleLessons.Remove(lessonTitle + "-Exercise");
                        }
                        scheduleLessons.Remove(lessonTitle);                     
                    }
                }
                else if (currCmd == "Swap")
                {
                    string secondLessonTitle = cmdArgs[2];

                    if (lessonExists && scheduleLessons.Contains(secondLessonTitle))
                    {
                        int indexA = scheduleLessons.FindIndex(x => x == lessonTitle);
                        int indexB = scheduleLessons.FindIndex(x => x == secondLessonTitle);

                        Swap(scheduleLessons, indexA, indexB);

                        if (scheduleLessons.Contains(lessonTitle + "-Exercise"))
                        {
                            int indexExercise = scheduleLessons.FindIndex(x => x == lessonTitle + "-Exercise");
                            scheduleLessons.RemoveAt(indexExercise);
                            scheduleLessons.Insert(indexB + 1, lessonTitle + "-Exercise");
                        }

                        if (scheduleLessons.Contains(secondLessonTitle + "-Exercise"))
                        {
                            int indexExercise = scheduleLessons.FindIndex(x => x == secondLessonTitle + "-Exercise");
                            scheduleLessons.RemoveAt(indexExercise);
                            scheduleLessons.Insert(indexA + 1, secondLessonTitle + "-Exercise");
                        }
                    }
                }
                else if (currCmd == "Exercise")
                {
                    if (lessonExists && !scheduleLessons.Contains(lessonTitle + "-Exercise"))
                    {
                        int lessonIndex = scheduleLessons.FindIndex(x => x == lessonTitle);
                        scheduleLessons.Insert(lessonIndex + 1, lessonTitle + "-Exercise");
                    }
                    else if (!lessonExists)
                    {
                        scheduleLessons.Add(lessonTitle);
                        scheduleLessons.Add(lessonTitle + "-Exercise");
                    }
                }
            }

            for (int i = 1; i <= scheduleLessons.Count; i++)
            {
                Console.WriteLine($"{i}.{scheduleLessons[i - 1]}");
            }
        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
