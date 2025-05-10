using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrainStation : MonoBehaviour
{
    [Header("Train")]
    public GameObject train;
    [Range(0, 59)] public float stopMinute = 20; //게임시간기준 분단위 
    float nextArrival = 120; //게임시간기준 2시간
    [Space(30)]


    [Header("Event")]
    public UnityEvent OnArrive;
    public UnityEvent OnDepart;
    [Space(30)]


    [Header("UI")]
    public Text trainDepartTime;
    public Text trainNextArriveTime;
    public Slider goldDemand;


    void Start()
    {
        StartCoroutine(TrainCycle());
    }


    void FixedUpdate()
    {
        goldDemand.value = GoldManager.Instance.goldNow / GoldManager.Instance.goldDemand;
    }

    IEnumerator TrainCycle()
    {
        var worldTime = WorldTime.Instance;


        //UI 열차출발시간
        trainDepartTime.text = worldTime.GetHourDisplay() + " : " + stopMinute.ToString();


        //UI 다음도착시간 
        float timer = nextArrival * 60 ; 
        trainNextArriveTime.text = worldTime.GetHour() + (int)timer / 3600 + " : " + worldTime.FloatToTimerUI( (int)timer / 60 % 60);


        //정차시간 이후 출발 
        StartCoroutine(TrainDepartTimer());


        //다음기차 기다림 
        var hour = worldTime.GetHour() + 2;
        for (; ; )
        {
            if(worldTime.GetHour() == hour)
                break;

            yield return new WaitForSeconds(1);
        }


        //2회차부터 도착이벤트
        OnArrive.Invoke();


        //무한반복
        StartCoroutine(TrainCycle());
    }
    IEnumerator TrainDepartTimer()
    {
        for (; ; )
        {
            if (WorldTime.Instance.GetMinute() == stopMinute)
                break;

            yield return new WaitForSeconds(0.5f);
        }

        OnDepart.Invoke();
    }
}
/*
1초 40초  
1초 20초 
현실시간 - 3분마다 30초정차  
게임시간 - 2시마다 20분정차 

 
0 -^--- 2 -^--- 4 -^--- 6



        //Invoke(nameof(TrainDepart), stopMinute * 60 / worldTime.timeScaleRealToGame);
        // yield return new WaitForSeconds(nextArrival * 60 / worldTime.timeScaleRealToGame);
 Debug.Log(WorldTime.Instance.GetMinute());
 */