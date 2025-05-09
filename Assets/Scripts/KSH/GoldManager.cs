using UnityEngine;
using UnityEngine.Events;

public class GoldManager : SingletonInherit<GoldManager>
{
    public float goldNow;
    public float goldDemand;
    public UnityEvent OnDepose;
    public UnityEvent OnFullfill;


    public bool isFullfillDemand()
    {
        if (goldNow >= goldDemand) 
            return true;

        return false;
    }

    
    public void DeposeGold(float amunt=0) 
    {
        goldNow += amunt;

        OnDepose.Invoke();

        if (isFullfillDemand())
            OnFullfill.Invoke();
    }
}
