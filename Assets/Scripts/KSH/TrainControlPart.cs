using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainControlPart : MonoBehaviour, IInteractable
{
    public bool canEnter;//ž�°��ɿ���
    public bool isEnter; //ž�� ���� 
    public GameObject door;

    void Start()
    {
        GoldManager.Instance.OnFullfill.AddListener(CheckEnter); // �Ҵ緮�޼���  ��Ȱ���ǵ� ȣ���
    }
            
    public void EnterTrain() 
    { 
        if(canEnter)
            isEnter = true;        

        //�ɸ��� �̵�?
        /*Ư����ġ ���� */
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
 
       // GetComponentInParent<TrainStation>().OnArrive.AddListener(CheckEnter);// �޼����� �������� ��  
 */