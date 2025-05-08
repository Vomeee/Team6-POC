using UnityEngine;

public class WorldTimer : Singleton<WorldTimer>
{
    public float timeScaleRealToGame= 40; //2시간7200초 3분180초 
    public float timer = 0f;



    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime * timeScaleRealToGame;
        int hour = (int)timer / 3600;
        int minutes = (int)timer / 60 % 60;
    }

    public float GetHour() { return (int)timer / 3600; }
    public float GetMinute() { return (int)timer / 60 % 60; }
}
