using System.Collections;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Variable")]
    public float accel = 10;
    public float velocityMax = 10;
    public float distanceMax = 10;
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
        gameObject.active = true;
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
        velocityNow = 0;

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
            if (Vector3.Distance(trainStation.transform.position, transform.position) > distanceMax)
            {
                velocityNow = 0;
                transform.position = trainStation.transform.position - transform.forward * distanceMax;
                gameObject.active = false;
                break;
            }
        }
    }
    IEnumerator C_Arrive()
    {
        var delta = Time.deltaTime;
        velocityNow = velocityMax;
        var originPos = trainStation.transform.position - transform.forward * distanceMax;
        var stopDistance = 5.0f;


        for (;;)
        {
            yield return new WaitForSeconds(delta);


            //이동
            if (Vector3.Distance(trainStation.transform.position, transform.position) > stopDistance)
            { 
                transform.position += transform.forward * velocityNow * delta;
            }
            //감속시작
            else if (Vector3.Distance(trainStation.transform.position, transform.position) <= stopDistance)
            {
                transform.position = Vector3.Lerp(transform.position, trainStation.transform.position, 3 * delta);
            }
            //정지 
            else if (Vector3.Distance(trainStation.transform.position, transform.position) < 0.1f)
            {
                transform.position = trainStation.transform.position;
                break;
            }
        }
    }
}
