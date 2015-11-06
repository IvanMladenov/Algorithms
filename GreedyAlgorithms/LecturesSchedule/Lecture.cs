namespace LecturesSchedule
{
    public class Lecture
    {
        public Lecture(string lectureName, int startTime, int endTime)
        {
            this.LectureName = lectureName;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public int EndTime { get; set; }

        public int StartTime { get; set; }

        public string LectureName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1} -> {2}", this.StartTime, this.EndTime, this.LectureName);
        }
    }
}
