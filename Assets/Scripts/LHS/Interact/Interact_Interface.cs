using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject interactor, float value = 0);
}