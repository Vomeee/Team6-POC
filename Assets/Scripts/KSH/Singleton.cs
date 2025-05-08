using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;
   
    private void Awake()
    {
        Instance = FindAnyObjectByType<T>();
    }
}




/*    
        //DontDestroyOnLoad(this);
   
   */   