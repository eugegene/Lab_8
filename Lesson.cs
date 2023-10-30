namespace Lab1_Petrenko_program
{
    public class Lesson
    {
        private DateTime lessonDate;
        private int lessonNumber;
        private string subject;
        private LessonType type;
        private bool isNumerator;
        private bool isRemedial;

        public Lesson(DateTime lessonDate, int lessonNumber, string subject, LessonType type, bool isNumerator, bool isRemedial)
        {
            this.lessonDate = lessonDate;
            this.lessonNumber = lessonNumber;
            this.subject = subject;
            this.type = type;
            this.isNumerator = isNumerator;
            this.isRemedial = isRemedial;
            TotalHours = lessonDuration(type);
        }

        public DateTime LessonDate
        {
            get { return lessonDate; }
            set { lessonDate = value; }
        }

        public int LessonNumber
        {
            get { return lessonNumber; }
            set { lessonNumber = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public LessonType Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool IsNumerator
        {
            get { return isNumerator; }
            set { isNumerator = value; }
        }

        public bool IsRemedial
        {
            get { return isRemedial; }
        }

        public double TotalHours { get; private set; }

        private double lessonDuration(LessonType type)
        {
            if (type == LessonType.Online)
            {
                return 1.5;
            }
            else
            {
                return 2;
            }
        }
    }

    public enum LessonType
    {
        Online,
        InPerson,
        Hybrid
    }
}