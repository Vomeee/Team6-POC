using UnityEngine;

public class TrainControlPart : MonoBehaviour
{
    public bool canEnter;//탑승가능여부
    public bool isEnter; //탑승 했냐 


    void Start()
    {
        GoldDemander.Instance.OnFullfill.AddListener(CheckEnter); // 할당량달성시 
        GetComponentInParent<TrainStation>().OnArrive.AddListener(CheckEnter);// 달성이후 기차도착 시 
    }
       
    

    public void EnterTrain() 
    { 
        isEnter = true;

        //케릭터 이동?
    }






    void CheckEnter()
    {
        if (GoldDemander.Instance.isFullfillDemand())
            canEnter = true;
        else
            canEnter = false;


        if (canEnter)
            DoorOpen();
    }
    void DoorOpen() { transform.localScale = new Vector3(1, 0.2f, 1); }
}
