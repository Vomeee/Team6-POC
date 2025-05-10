using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldTime : SingletonInherit<WorldTime>
{
    [Header("Variable")]
    public float timer = 0f;
    public float timeScaleRealToGame= 40; // 3초 120초 
    public float startHour=9;

    public float test = 10;


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
    
    //테스트용
    void Update()
    {
        Time.timeScale = test;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GoldManager.Instance.DeposeGold(30);

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //
    }


    public int GetHour() { return (int)timer / 3600; }
    public int GetMinute() { return (int)timer / 60 % 60; }


    public int GetMinuteByGameTime(float realSecond) { return (int)(realSecond * timeScaleRealToGame / 60 % 60); }
    public int GetHourByGameTime(float realSecond) { return (int)(realSecond * timeScaleRealToGame / 60 % 60); }



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


/*
스테이지->상점->다음스테이지     scene or 좌표이동
열차 출발 도착 시 이동관련 / 방위주 실내맵에서 / 단순연출 페이드인아웃
철문 바닥 천장 / 점멸류  


 */