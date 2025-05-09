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


        //���� ��� UI 
        trainDepartTime.text = worldTime.GetHourDisplay() + " : " + worldTime.GetMinuteByGameTime(stopTime);


        //���� ���� UI 
        trainNextArriveTime.text = worldTime.FloatToTimerUI(worldTime.GetHour() + 2) + " : " + "00";


        //�����ð� ���� ��� 
        Invoke(nameof(TrainDepart), stopTime);


        //�������� ��ٸ� 
        yield return new WaitForSeconds(nextArrival);


        //2ȸ������ ����
        OnArrive.Invoke();


        //���ѹݺ�
        StartCoroutine(TrainCycle());
    }
    void TrainDepart() { OnDepart.Invoke(); }
}

/*

���ӽð� - 2�ø��� 20������ 
���ǽð� - 3�и��� 30������ 
 
0 -^--- 2 -^--- 4 -^--- 6





 Debug.Log(WorldTime.Instance.GetMinute());
 */