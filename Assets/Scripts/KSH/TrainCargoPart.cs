using UnityEngine;

public class TrainCargoPart : MonoBehaviour
{    
    //�÷��̾��� �����۰�ġ��� + �÷�����
    public  void DeposeGold(float amount) { GoldManager.Instance.DeposeGold(amount); }
 
}
