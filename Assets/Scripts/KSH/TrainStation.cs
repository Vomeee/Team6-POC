using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrainStation : MonoBehaviour
{
    [Header("Train")]
    public GameObject train;
    [Range(0, 59)] public float stopMinute = 20; //���ӽð����� �д��� 
    float nextArrival = 120; //���ӽð����� 2�ð�
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


        //UI ������߽ð�
        trainDepartTime.text = worldTime.GetHourDisplay() + " : " + stopMinute.ToString();


        //UI ���������ð� 
        float timer = nextArrival * 60 ; 
        trainNextArriveTime.text = worldTime.GetHour() + (int)timer / 3600 + " : " + worldTime.FloatToTimerUI( (int)timer / 60 % 60);


        //�����ð� ���� ��� 
        StartCoroutine(TrainDepartTimer());


        //�������� ��ٸ� 
        var hour = worldTime.GetHour() + 2;
        for (; ; )
        {
            if(worldTime.GetHour() == hour)
                break;

            yield return new WaitForSeconds(1);
        }


        //2ȸ������ �����̺�Ʈ
        OnArrive.Invoke();


        //���ѹݺ�
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
1�� 40��  
1�� 20�� 
���ǽð� - 3�и��� 30������  
���ӽð� - 2�ø��� 20������ 

 
0 -^--- 2 -^--- 4 -^--- 6



        //Invoke(nameof(TrainDepart), stopMinute * 60 / worldTime.timeScaleRealToGame);
        // yield return new WaitForSeconds(nextArrival * 60 / worldTime.timeScaleRealToGame);
 Debug.Log(WorldTime.Instance.GetMinute());
 */