using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        interactor.SetActive(false);
    }
}
