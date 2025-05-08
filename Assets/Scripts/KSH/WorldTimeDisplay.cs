using UnityEngine;

public class WorldTimeDisplay : MonoBehaviour
{
    public TextMesh textMesh; 


    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }


    void FixedUpdate()
    {
        var worldTime = WorldTimer.Instance;
        textMesh.text = worldTime.GetHour().ToString() + " : " + worldTime.GetMinute().ToString();
    }
}
