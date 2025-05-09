using UnityEngine;

public class SingletonInherit<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;
   
    private void Awake(){Instance = FindAnyObjectByType<T>();}
}




/*    
        //DontDestroyOnLoad(this);
   
   */   