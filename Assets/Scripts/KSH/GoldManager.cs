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


    //상점구매 
    public void UseGold(float amunt=0)
    {
        goldNow -= amunt;
        OnUse.Invoke();
    }
    
    //기차에서 넣기 
    public void DeposeGold(float amunt=0) 
    {
        goldNow += amunt;

        OnDepose.Invoke();

        if (isFullfillDemand())
            OnFullfill.Invoke();
    }
}
