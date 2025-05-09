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
        var worldTime = WorldTimer.Instance;


        int hour = worldTime.GetHour();
        string hourstring = worldTime.GetHour().ToString();
        if (hour <10)
            hourstring= "0" + worldTime.GetHour().ToString();


        int minuite = worldTime.GetMinute();
        string minuitestring = worldTime.GetMinute().ToString();
        if (minuite < 10)
            minuitestring = "0" + worldTime.GetMinute().ToString();



        _text.text = hourstring + " : " + minuitestring;
    }
}
