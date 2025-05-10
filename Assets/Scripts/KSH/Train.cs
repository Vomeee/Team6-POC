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


    //���� ���� ��� / �̵�����? 
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

            //����
            velocityNow += accel * delta;

            //�ִ�����
            if (velocityNow >= velocityMax)
                velocityNow = velocityMax;

            //�̵�
            transform.position += transform.forward * velocityNow * delta;

            //�ִ�Ÿ�
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


            //�̵�
            if (Vector3.Distance(trainStation.transform.position, transform.position) > stopDistance)
            { 
                transform.position += transform.forward * velocityNow * delta;
            }
            //���ӽ���
            else if (Vector3.Distance(trainStation.transform.position, transform.position) <= stopDistance)
            {
                transform.position = Vector3.Lerp(transform.position, trainStation.transform.position, 3 * delta);
            }
            //���� 
            else if (Vector3.Distance(trainStation.transform.position, transform.position) < 0.1f)
            {
                transform.position = trainStation.transform.position;
                break;
            }
        }
    }
}
