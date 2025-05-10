using UnityEngine;

public class TrainCargoPart : MonoBehaviour, IInteractable
{
    //플레이어의 아이템가치계산 + 올려놓기
    public void DeposeGold(float amount) { GoldManager.Instance.DeposeGold(amount); }

    public void Interact(GameObject interactor, float value)
    {
        value = 50;
        GoldManager.Instance.DeposeGold(value);
    }

}
