using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrainStation : MonoBehaviour
{
    [Header("Train")]
    public GameObject train;
    public float stopTime = 30;
    public float nextArrival = 180;
    public UnityEvent OnArrive;
    public UnityEvent OnDepart;
    [Space(30)]


    [Header("UI")]
    public Text trainDepartTime;
    public Text trainNextArriveTime;
    public Slider goldDemand;

    public float test = 10;


    void Start()
    {
        StartCoroutine(TrainCycle());
    }


    void FixedUpdate()
    {
        Time.timeScale = test;
        goldDemand.value = GoldDemander.Instance.goldNow / GoldDemander.Instance.goldDemand;
    }

    IEnumerator TrainCycle()
    {
        var worldTime = WorldTime.Instance;


        //열차 출발 UI 
        trainDepartTime.text = worldTime.GetHourDisplay() + " : " + worldTime.GetMinuteByGameTime(stopTime);


        //열차 도착 UI 
        trainNextArriveTime.text = worldTime.FloatToTimerUI(worldTime.GetHour() + 2) + " : " + "00";


        //정차시간 이후 출발 
        Invoke(nameof(TrainDepart), stopTime);


        //다음기차 기다림 
        yield return new WaitForSeconds(nextArrival);


        //2회차부터 도착
        OnArrive.Invoke();


        //무한반복
        StartCoroutine(TrainCycle());
    }
    void TrainDepart() { OnDepart.Invoke(); }
}

/*

게임시간 - 2시마다 20분정차 
현실시간 - 3분마다 30초정차 
 
0 -^--- 2 -^--- 4 -^--- 6





 Debug.Log(WorldTime.Instance.GetMinute());
 */