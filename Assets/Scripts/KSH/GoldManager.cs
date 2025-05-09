using UnityEngine;
using UnityEngine.Events;

public class GoldManager : SingletonInherit<GoldManager>
{
    [Header("Variable")]
    public float goldNow;
    public float goldDemand;
    [Space(30)]

    [Header("Event")]
    public UnityEvent OnDepose;
    public UnityEvent OnUse;
    public UnityEvent OnFullfill;


    public bool isFullfillDemand()
    {
        if (goldNow >= goldDemand) 
            return true;

        return false;
    }


    //�������� 
    public void UseGold(float amunt=0)
    {
        goldNow -= amunt;
        OnUse.Invoke();
    }
    
    //�������� �ֱ� 
    public void DeposeGold(float amunt=0) 
    {
        goldNow += amunt;

        OnDepose.Invoke();

        if (isFullfillDemand())
            OnFullfill.Invoke();
    }
}
