using System.Diagnostics;

namespace Tests.Helpers;

public class TimerHelper
{
    private Stopwatch stopWatch; 
    
    public TimerHelper()
    {
        stopWatch = new Stopwatch();
    }

    public void StartTimer()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }

    public string StopTimer()
    {
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

        elapsedTime = ts.TotalSeconds.ToString();
        return elapsedTime;
    }
}
