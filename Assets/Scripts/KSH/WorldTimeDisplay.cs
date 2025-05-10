using UnityEngine;
using UnityEngine.UI;


public class WorldTimeDisplay : MonoBehaviour
{
     Text _text; 


    void Start()
    {
        _text = GetComponentInChildren<Text>();
    }


    void FixedUpdate()
    {
        var worldTime = WorldTime.Instance;
        _text.text = worldTime.GetHourDisplay() + " : " + worldTime.GetMinuteDisplay();
    }
}
