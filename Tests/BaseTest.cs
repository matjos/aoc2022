using Tests.Helpers;

namespace Tests;

public class BaseTest
{
    protected TimerHelper timer;

    public BaseTest()
    {
        timer = new TimerHelper();
    }
}
