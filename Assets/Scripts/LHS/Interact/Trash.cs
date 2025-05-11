using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor, float value)
    {
        interactor.SetActive(false);
    }
}
