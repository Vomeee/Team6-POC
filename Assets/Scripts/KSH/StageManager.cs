using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : SingletonInherit<StageManager>
{
    public int stageNow =1;




    public void GoShop()
    {
        //�Ҵ緮 �������� 
        GoldManager.Instance.goldMy += GoldManager.Instance.goldPutin;
        GoldManager.Instance.goldPutin = 0;


        //���� ��
        SceneManager.LoadScene(1);        
    }

    public void NextStage() 
    { 
        stageNow++;

        //�ΰ����� 
        //SceneManager.LoadScene(1);
    }
}
