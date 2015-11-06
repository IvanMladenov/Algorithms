namespace LecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    class LecturesProgram
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(':');
            int numberOflectures = int.Parse(firstLine[1]);
            Lecture[] lectures = new Lecture[numberOflectures];
            for (int i = 0; i < numberOflectures; i++)
            {
                string[] current = Console.ReadLine().Split(':');
                string[] splitetInterval = Regex.Split(current[1], "[^0-9]+");
                Lecture currentLecture = new Lecture(current[0], int.Parse(splitetInterval[1]), int.Parse(splitetInterval[2]));
                lectures[i] = currentLecture;
            }

            var ordered = lectures.OrderBy(x => x.EndTime);
            int startTime = 0;
            var schedule = new List<Lecture>();
            foreach (var lecture in ordered)
            {
                if (lecture.StartTime >= startTime)
                {
                    schedule.Add(lecture);
                    startTime = lecture.EndTime;
                }
            }

            Console.WriteLine("Lectures ({0}):", schedule.Count);
            Console.WriteLine(string.Join("\n", schedule));
        }
    }
}
