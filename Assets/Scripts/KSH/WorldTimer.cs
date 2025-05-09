using UnityEngine;

public class WorldTimer : SingletonInherit<WorldTimer>
{
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
}
