using System;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Female);

            // make a new gradebook
            GradeBook book = new GradeBook();
            // register an event delegate

            book.NameChanged += OnNameChanged;

            // trigger the event
            book.Name = "The Grade Book";
            book.NameChanged += OnNameChanged;
            synth.Speak("Welcome to: " + book.Name);


            //book.NameChanged = null;
            //book.NameChanged = new NameChangedDelegate(OnNameChanged2);

            // trigger it again
            book.Name = "Chuck's Grade Book";
            synth.Speak("Welcome to: " + book.Name);


            book.AddGrade(91);      // int can convert to float safely
            book.AddGrade(89.5f);   // double can't convert to float safely
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);


        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine(
                $"Changing name from {args.ExistingName} to {args.NewName}");
        }

        public static void WriteResult(string description, float result)
        {
            // format string
            //Console.WriteLine("{0}: {1}", description, result);
            Console.WriteLine("{0}: {1:F2}", description, result);
            Console.WriteLine($"{description}: {result:F2}");
        }
        public static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        public static void TalkToUser()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Greetings Professor Falken. Shall we play a game?");
            synth.SelectVoiceByHints(VoiceGender.Female);
            synth.Speak("How about Global Thermonuclear War?");

            string confirm = "no";
            do
            {
                synth.Speak("First, let me get a good callback number for you: ");

                string callbackNumber = Console.ReadLine();
                synth.Speak(callbackNumber + ", is this correct?");
                confirm = Console.ReadLine();
            } while (confirm != "yes");
            synth.Speak("Thank you. Terminating the program now.");
        }

        public static void MoreGradeBookFun()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Chucks GradeBook";
            Console.WriteLine(g2.Name);

            //correct and incorrect use of DateTime vars
            DateTime date = new DateTime(2002, 8, 22);
            DateTime date2 = date.AddDays(1);

            Console.WriteLine(date);
            Console.WriteLine(date2);

            date = date.AddDays(1);
            Console.WriteLine(date);
        }

    }
}
