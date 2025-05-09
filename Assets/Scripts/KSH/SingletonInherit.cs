using UnityEngine;

public class SingletonInherit<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]
    public bool donDestroy;
    bool isFirst;

    [Space(30)]


    public static T Instance;


    private void Awake()
    {
        var t = FindObjectsOfType<T>(); Debug.Log(t.Length);
        if (t.Length == 1)
            isFirst = true;


        //√π Ω√¿€«— ΩÃ±€≈Ê¿Ã ∏ﬁ¿Œ 
        if (isFirst)
        {
            Instance = FindAnyObjectByType<T>();

            if (donDestroy)
                DontDestroyOnLoad(this);
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