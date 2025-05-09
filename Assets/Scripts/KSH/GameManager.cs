using UnityEngine;

public class GameManager : SingletonInherit<GameManager>
{
    public StageManager stageManager;
    public GoldManager goldManager; 
    public WorldTime worldTime;

    private void Start()
    {
        stageManager = StageManager.Instance;
        goldManager = GoldManager.Instance;
        worldTime = WorldTime.Instance;
    }

}
