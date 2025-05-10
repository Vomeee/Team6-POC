using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction_Detector : MonoBehaviour
{
    private Camera _mainCamera;
    private float _rayDistance = 1.5f;
    private GameObject _InteractUi;

    private LayerMask _InteractionLayerMask; // 상호작용 레이어만 감지
    private LayerMask _EnemyMask;

    private GameObject _currentTarget;

    private void Start()
    {
        _mainCamera = Camera.main.transform.GetComponent<Camera>();
        _InteractionLayerMask = LayerMask.GetMask("Interaction");
        _EnemyMask = LayerMask.GetMask("Enemy");
        _InteractUi = transform.GetComponentInChildren<Interact_UI>(true).gameObject;


    }

    public void OnInteract(InputValue value)
    {
        if (_currentTarget == null)
            return;
        else
            Interaction(_currentTarget);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, _rayDistance, _InteractionLayerMask))
        {

            _currentTarget = hit.collider.gameObject;
            _InteractUi.SetActive(true);

            
        }
        else
        {
            _currentTarget = null;
            _InteractUi.SetActive(false);
        }
    }


    void Interaction(GameObject objects)
    {
        if (objects.TryGetComponent<Trash>(out var trash))
        {

        }

        if (objects.TryGetComponent<Item>(out var item))
        {

        }

        if (objects.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interact(objects);
        }


    }
}
