using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public bool isRepeat;
    public int num;//0�̸� ���ѹݺ� / 1�̻���� ��������
    public UnityEngine.Events.UnityEvent OnTime;

    int num_count;




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

                num_count++;
                if (num_count == num) break;
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
        return f;
    }
    public void SeparateParent() { transform.parent = null; }
    public void DestroyThat(GameObject go) { Destroy(go); }


}

