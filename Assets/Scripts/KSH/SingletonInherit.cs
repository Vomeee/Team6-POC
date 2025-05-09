using UnityEngine;

public class SingletonInherit<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]
    public bool donDestroy;
    [Space(30)]


    public static T Instance;
   
    private void Awake()
    {
        Instance = FindAnyObjectByType<T>();
        
        if(donDestroy)DontDestroyOnLoad(this);
    }

}




/*    
        //
   
   */   