using UnityEngine;

public class WorldTime : SingletonInherit<WorldTime>
{
    [Header("Variable")]
    public float timeScaleRealToGame= 40; //2시간7200초 3분180초 
    public float timer = 0f;
    public float startHour=9;


    void Start()
    {
        timer = startHour * 3600;// * timeScaleRealToGame ;
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime * timeScaleRealToGame;
        int hour = (int)timer / 3600;
        int minutes = (int)timer / 60 % 60;
    }

    public int GetHour() { return (int)timer / 3600; }
    public int GetMinute() { return (int)timer / 60 % 60; }


    public int GetMinuteByGameTime(float realSecond) { return (int)(realSecond * timeScaleRealToGame / 60 % 60); }




    public string GetHourDisplay()
    {
        var worldTime = WorldTime.Instance;

        int hour = worldTime.GetHour();
        string hourstring = worldTime.GetHour().ToString();
        if (hour < 10)
            hourstring = "0" + worldTime.GetHour().ToString();

        return hourstring;
    }
    public string GetMinuteDisplay()
    {
        var worldTime = WorldTime.Instance;

        int minuite = worldTime.GetMinute();
        string minuitestring = worldTime.GetMinute().ToString();
        if (minuite < 10)
            minuitestring = "0" + worldTime.GetMinute().ToString();


        return minuitestring;
    }
    public string FloatToTimerUI(float value)
    {
        string output = value.ToString();
        if (value < 10)
            output = "0" + value.ToString();

        return output;
    }
}

