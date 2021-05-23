namespace _01.Chronometer
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch = new Stopwatch();
        public Chronometer()
        {
            this.Laps = new List<string>();
        }

        public string GetTime => Time();

        public List<string> Laps { get; }

        public string Lap()
        {

            string lap = Time();
            this.Laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            this.stopwatch.Restart();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        private  string Time ()
        {
            long totalMiliseconds = this.stopwatch.ElapsedMilliseconds;
            long totalSeconds = totalMiliseconds / 1000;
            long totalMinutes = totalSeconds / 60;

            string miliSeconds = (totalMiliseconds % 1000).ToString().PadLeft(4, '0');
            string seconds = (totalSeconds % 60).ToString().PadLeft(2, '0'); ;
            string minutes = (totalMinutes % 60).ToString().PadLeft(2, '0'); ;
            string hours = (totalMinutes / 60).ToString().PadLeft(2, '0'); ;

            return $"{hours}:{minutes}:{seconds}.{miliSeconds}";
        }
    }
}
