using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        // this is a default ctor - a ctor that takes 0 params
        public GradeBook()
        {
            name = "Empty Grade Book";
            grades = new List<float>();
        }
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            // then calculate the stats
            stats.HighestGrade = 0;

            float sum = 0;
            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count; 

            return stats;
        }

        // members that do work - behavior related methods
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = name;
                        args.NewName = value;

                        // send notification that the name is changing
                        NameChanged(this, args);
                    }
                    name = value;
                }
            }
        }

        public event NameChangedDelegate NameChanged;
        private string name;

        // fields - using field initializer syntax
        private List<float> grades;

    }
}
