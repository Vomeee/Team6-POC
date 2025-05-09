using UnityEngine;
using UnityEngine.Events;

public class InterActable : MonoBehaviour
{
    public UnityEvent OnInterAct;

    

    public UnityEvent<int, float,GameObject> example;

    void Ex() 
    {
        example.AddListener(func);
        example.Invoke(1, 3, gameObject);
    }
    void func(int i, float f, GameObject g) { }
}
