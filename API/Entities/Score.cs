namespace API.Entities
{
    public class Score
    {
        public int Id { get; set; }

        public double Grades { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }

    }
}
