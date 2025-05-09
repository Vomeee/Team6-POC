using UnityEngine;
using UnityEngine.Events;

public class Train : MonoBehaviour
{
    TrainStation trainStation;



    void Start()
    {
        trainStation = GetComponentInParent<TrainStation>();

        trainStation.OnDepart.AddListener(Depart);
        trainStation.OnArrive.AddListener(Arrive);
    }

    void Arrive() { gameObject.SetActive(true); }
    void Depart() { gameObject.SetActive(false); }

}
