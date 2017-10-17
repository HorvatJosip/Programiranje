using System;

namespace Zadatak3_Ishodi56
{
    class WrongTaskDateTimeException : Exception
    {
        public override string Message => $"The specified date & time is in the past.";
    }

    enum TaskCategory
    {
        Family, Hobby, Job
    }

    class Task
    {
        public int ID { get; }
        public string Name { get; }
        public DateTime StartTime { get; }
        public TaskCategory Category { get; }

        public int MinutesUntilStart { get => (int)(StartTime - DateTime.Now).TotalMinutes; }

        public Task(int id, string name, DateTime dateTime, TaskCategory category)
        {
            ID = id;
            Name = name;
            StartTime = dateTime;
            Category = category;
        }

        //iz teksta zadatka: "Naziv: Nazvati dragu, godišnjica je danas, ID: 1, počinje za 13 minuta"
        //s obzirom da nigdje nemamo tekst kao gore "Nazvati...", zamijenit ćemo ga s kategorijom
        public override string ToString()
        {
            return $"{Name}: {Category}, ID: {ID}, starts in {MinutesUntilStart} minutes";
        }

        //format koji koristimo kada zapisujemo u datoteku (ovo sam izabrao radi jednostavnosti, svatko može imat neki svoj format)
        public string ToFileString()
        {
            return $"{Name}, {Category}, {ID}, {StartTime}";
        }
    }
}
