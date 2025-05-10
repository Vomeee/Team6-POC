using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainControlPart : MonoBehaviour, IInteractable
{
    public bool canEnter;//탑승가능여부
    public bool isEnter; //탑승 여부 
    public GameObject door;

    void Start()
    {
        GoldManager.Instance.OnFullfill.AddListener(CheckEnter); // 할당량달성시  비활성되도 호출됨
    }
            
    public void EnterTrain() 
    { 
        if(canEnter)
            isEnter = true;        

        //케릭터 이동?
        /*특정위치 고정 */
    }
    void CheckEnter()
    {
        canEnter = true;
        door.active = true;
    }

    public void Interact(GameObject interactor, float value = 0)
    {
        StageManager.Instance.GoShop();
    }
}




/*
        if (GoldManager.Instance.isFullfillDemand())
            canEnter = true;
        else
            canEnter = false; 
 
       // GetComponentInParent<TrainStation>().OnArrive.AddListener(CheckEnter);// 달성이후 기차도착 시  
 */