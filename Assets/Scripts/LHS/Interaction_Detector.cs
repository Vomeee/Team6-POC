using UnityEngine;

public class Interaction_Detector : MonoBehaviour
{
    private Camera _mainCamera;
    private float _rayDistance = 1.5f;
    private GameObject _InteractUi;

    private LayerMask _InteractionLayerMask; // 상호작용 레이어만 감지
    private LayerMask _EnemyMask;


    private void Start()
    {
        _mainCamera = Camera.main.transform.GetComponent<Camera>();
        _InteractionLayerMask = LayerMask.GetMask("Interaction");
        _EnemyMask = LayerMask.GetMask("Enemy");
        _InteractUi = transform.GetComponentInChildren<Interact_UI>(true).gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance, _InteractionLayerMask))
        {
            Interaction(hit.collider.gameObject);



            _InteractUi.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
        else
        {
            _InteractUi.SetActive(false);
             
        }
    }


    void Interaction(GameObject item)
    {
        //item.GetComponent<interaction>().interact;
        
        
    }
}
