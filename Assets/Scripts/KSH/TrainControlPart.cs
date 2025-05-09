using UnityEngine;

public class TrainControlPart : MonoBehaviour
{
    public bool canEnter;//ž�°��ɿ���
    public bool isEnter; //ž�� �߳� 


    void Start()
    {
        GoldManager.Instance.OnFullfill.AddListener(CheckEnter); // �Ҵ緮�޼��� 
        GetComponentInParent<TrainStation>().OnArrive.AddListener(CheckEnter);// �޼����� �������� �� 
    }
       
    

    public void EnterTrain() 
    { 
        isEnter = true;

        //�ɸ��� �̵�?
    }






    void CheckEnter()
    {
        if (GoldManager.Instance.isFullfillDemand())
            canEnter = true;
        else
            canEnter = false;


        if (canEnter)
            DoorOpen();
    }
    void DoorOpen() { transform.localScale = new Vector3(1, 0.2f, 1); }
}
