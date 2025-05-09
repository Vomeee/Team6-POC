using UnityEngine;

public class GoldDemander : SingletonInherit<GoldDemander>
{
    public float goldNow;
    public float goldDemand;


    public bool isFullfillDemand()
    {
        if (goldNow >= goldDemand) 
            return true;

        return false;
    }

    public void DeposeGold(float amunt=0) { }
}
