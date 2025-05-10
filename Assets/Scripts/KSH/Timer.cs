using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public bool isRepeat;
    public int num;//0이면 무한반복 / 1이상부터 개수적용
    public UnityEngine.Events.UnityEvent OnTime;

    int numCount;




    void Start()    {        StartCoroutine(Act());    }
    void OnDisable()    {        StopAllCoroutines();    }
    IEnumerator Act()
    {
        if (isRepeat)
        {
            for (; ; )
            {
                yield return new WaitForSeconds(GetTime());
                OnTime.Invoke();

                numCount++;
                if (numCount == num) break;
            }
        }
        else
        {
            yield return new WaitForSeconds(GetTime());
            OnTime.Invoke();
        }
    }


    float GetTime() 
    {
        float f = time;
        //if (isRnd != 0) f = Random.RandomRange(isRnd, time);
        return time;
    }
    public void SeparateParent() { transform.parent = null; }
    public void DestroyThat(GameObject go) { Destroy(go); }
}

