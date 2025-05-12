using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Slider _slider; 
    void Start()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
