using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    CanvasManager _canvasManager;
     
    public float duration;
    public float weight;


    public void Interact(GameObject interactor, float value)
    {
        _canvasManager = FindAnyObjectByType<CanvasManager>();
        if(_canvasManager._slider.value < 100)
        {
            _canvasManager._slider.value += weight;
            interactor.SetActive(false);
        }
    }
}
