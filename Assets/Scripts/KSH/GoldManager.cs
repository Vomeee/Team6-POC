using UnityEngine;
using UnityEngine.Events;


public class GoldManager : SingletonInherit<GoldManager>
{
    [Header("Variable")]
    public float goldPutin;
    public float goldDemand;
    public float goldMy;
    [Space(30)]


    [Header("Event")]
    public UnityEvent OnPutin;
    public UnityEvent OnUse;
    public UnityEvent OnFullfill;






    //상점구매 
    public void UseGold(float amunt=0)
    {
        goldMy -= amunt;
        OnUse.Invoke();
    }
    
    //기차에서 넣기 
    public void PutinGold(float amunt=0) 
    {
        goldPutin += amunt;

        OnPutin.Invoke();

        if (isFullfillDemand())
            OnFullfill.Invoke();
    }
     bool isFullfillDemand()
    {
        if (goldPutin >= goldDemand) 
            return true;

        return false;
    }
}
