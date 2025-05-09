using UnityEngine;

public class Train : MonoBehaviour
{
    TrainStation trainStation;


    void Start()
    {
        trainStation = GetComponentInParent<TrainStation>();

        trainStation.OnArrive.AddListener(Arrive);
        trainStation.OnDepart.AddListener(Depart);
    }
    //이동관련 
    void Arrive() { gameObject.SetActive(true); }
    void Depart() { gameObject.SetActive(false); }
}
