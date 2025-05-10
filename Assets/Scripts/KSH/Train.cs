using System.Collections;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Variable")]
    public float accel=10;
    public float velocityMax=10;
    public float distanceMax=10;
    public float velocityNow;

    [Space(30)]

    TrainStation trainStation;


    void Start()
    {
        trainStation = GetComponentInParent<TrainStation>();

        trainStation.OnArrive.AddListener(Arrive);
        trainStation.OnDepart.AddListener(Depart);
    }


    //열차 도착 출발 / 이동관련? 
    void Arrive()
    {
        StopAllCoroutines();
        StartCoroutine(C_Arrive());
    }
    void Depart()
    {
        StopAllCoroutines();
        StartCoroutine(C_Depart());
    }

    IEnumerator C_Depart()
    {
        var delta = Time.deltaTime;
        for (; ; )
        {
            yield return new WaitForSeconds(delta);

            //가속
            velocityNow += accel * delta;
            
            //최대제한
            if (velocityNow >= velocityMax)
                velocityNow = velocityMax;

            //이동
            transform.position += transform.forward * velocityNow * delta;

            //최대거리
            if(Vector3.Distance(trainStation.transform.position, transform.position) >distanceMax)
            {
                velocityNow = 0;
                transform.position = trainStation.transform.position -transform.forward * distanceMax;
                break;
            }
        }
    }
    IEnumerator C_Arrive()
    {
        var delta = Time.deltaTime;
        velocityNow = velocityMax;
        var originPos = trainStation.transform.position - transform.forward * distanceMax;
        for (; ; )
        {
            yield return new WaitForSeconds(delta);

            //가속
            velocityNow -= accel * delta;

            //최대제한
            if (velocityNow <=0 )
                velocityNow = 0;

            //이동
            transform.position += transform.forward * velocityNow * delta;

            //최대거리
            if (Vector3.Distance(trainStation.transform.position, transform.position) > distanceMax)
            {
                velocityNow = 0;
                transform.position = trainStation.transform.position - transform.forward * distanceMax;
                break;
            }
        }
    }
}
