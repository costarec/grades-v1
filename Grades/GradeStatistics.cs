namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = float.MinValue;  // begin comparison pt.
            LowestGrade = float.MaxValue;   // begin comparison pt.
        }
        public float AverageGrade;
        public float LowestGrade;
        public float HighestGrade;



    }
}