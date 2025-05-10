using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : SingletonInherit<StageManager>
{
    public int stageNow =1;




    public void GoShop()
    {
        //ÇÒ´ç·® ³»µ·À¸·Î 
        GoldManager.Instance.goldMy += GoldManager.Instance.goldPutin;
        GoldManager.Instance.goldPutin = 0;


        //»óÁ¡ ¾À
        SceneManager.LoadScene(1);        
    }

    public void NextStage() 
    { 
        stageNow++;

        //ÀÎ°×À¸·Î 
        //SceneManager.LoadScene(1);
    }
}
