using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*

게임시간 - 2시마다 20분정차 
현실시간 - 3분마다 30초정차 
 
0 -^--- 2 -^--- 4 -^--- 6

 */
public class TrainStation : MonoBehaviour
{
    [Header("Train")]
    public GameObject train;
    public float stopTime = 30;
    [Space(30)]


    [Header("UI")]
    public Text trainDepartTime;
    public Text trainNextArriveTime;
    public Slider goldDemand;


    void Start()
    {

    }


    void FixedUpdate()
    {
        goldDemand.value = GoldDemander.Instance.goldNow / GoldDemander.Instance.goldDemand;
    }

    IEnumerator TrainCycle()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Depart()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Wating()
    {
        yield return new WaitForSeconds(1f);
    }

}
