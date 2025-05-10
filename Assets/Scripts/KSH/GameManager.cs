using UnityEngine;


public class GameManager : SingletonInherit<GameManager>
{
    public StageManager stageManager;
    public GoldManager goldManager; 
    public WorldTime worldTime;
    //사운드 UI 오브젝트풀링 데이터 리소스  


    private void Start()
    {
        stageManager = StageManager.Instance;
        goldManager = GoldManager.Instance;
        worldTime = WorldTime.Instance;
    }

}
