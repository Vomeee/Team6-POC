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
    //�̵����� 
    void Arrive() { gameObject.SetActive(true); }
    void Depart() { gameObject.SetActive(false); }
}
