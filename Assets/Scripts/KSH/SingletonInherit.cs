using UnityEngine;
using UnityEngine.Serialization;

public class SingletonInherit<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]


    public bool dontDestroy;
    bool isFirst;

    [Space(30)]


    public static T Instance;


    private void Awake()
    {
        var t = FindObjectsOfType<T>();
        if (t.Length == 1)
            isFirst = true;


        //√π Ω√¿€«— ΩÃ±€≈Ê¿Ã ∏ﬁ¿Œ 
        if (isFirst)
        {
            Instance = FindAnyObjectByType<T>();

            if (dontDestroy)
            {
                transform.parent = null;
                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}




/*    
        //
   
   */   