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


    //���� ���� ��� / �̵�����? 
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

            //����
            velocityNow += accel * delta;
            
            //�ִ�����
            if (velocityNow >= velocityMax)
                velocityNow = velocityMax;

            //�̵�
            transform.position += transform.forward * velocityNow * delta;

            //�ִ�Ÿ�
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

            //����
            velocityNow -= accel * delta;

            //�ִ�����
            if (velocityNow <=0 )
                velocityNow = 0;

            //�̵�
            transform.position += transform.forward * velocityNow * delta;

            //�ִ�Ÿ�
            if (Vector3.Distance(trainStation.transform.position, transform.position) > distanceMax)
            {
                velocityNow = 0;
                transform.position = trainStation.transform.position - transform.forward * distanceMax;
                break;
            }
        }
    }
}
