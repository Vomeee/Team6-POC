using UnityEngine;

public class Interaction_Detector : MonoBehaviour
{
    private Camera _mainCamera;
    private float _rayDistance = 3f;

    private LayerMask _itemLayerMask; // 아이템 레이어만 감지
    private LayerMask _sellLayerMask; // 판매 레이어만 감지
    private LayerMask _InteractionLayerMask; // 상호작용 레이어만 감지
    private LayerMask _EnemyMask;


    private void Start()
    {
        _mainCamera = Camera.main.transform.GetComponent<Camera>();
        _itemLayerMask = LayerMask.GetMask("item");
        _sellLayerMask = LayerMask.GetMask("Sell");
        _InteractionLayerMask = LayerMask.GetMask("Interaction");
        _EnemyMask = LayerMask.GetMask("Enemy");


    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance, _sellLayerMask))
        {
            /*sellUIPanel.SetActive(true);
            currentItem = hit.collider.gameObject;*/
        }
        else
        {
            /*sellUIPanel.SetActive(false);
            currentItem = null;*/
        }



        if (Physics.Raycast(ray, out hit, _rayDistance, _itemLayerMask))
        {
            /*itemUIPanel.SetActive(true);
            currentItem = hit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                AddToInventory(currentItem);
            }*/
        }
        else
        {
           /* itemUIPanel.SetActive(false);
            currentItem = null;*/
        }

        if (Physics.Raycast(ray, out hit, _rayDistance, _InteractionLayerMask))
        {
            /*itemUIPanel.SetActive(true);
            currentItem = hit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                AddToInventory(currentItem);
            }*/
        }
        else
        {
            /* itemUIPanel.SetActive(false);
             currentItem = null;*/
        }
    }

    void Add_Inventory(GameObject item)
    {
        // 여기에 인벤토리 추가 로직
        Debug.Log("인벤토리에 추가됨: " + item.name);
        Destroy(item); // 또는 item.SetActive(false);
    }
    void Out_Inventory(GameObject item)
    {
        // 여기에 인벤토리 추가 로직
        Debug.Log("인벤토리에 추가됨: " + item.name);
        Destroy(item); // 또는 item.SetActive(false);
    }

    void Sell_Inventory(GameObject item)
    {
        // 여기에 인벤토리 추가 로직
        Debug.Log("인벤토리에 추가됨: " + item.name);
        Destroy(item); // 또는 item.SetActive(false);
    }

    void Interaction(GameObject item)
    {
        // 여기에 인벤토리 추가 로직
        Debug.Log("인벤토리에 추가됨: " + item.name);
        Destroy(item); // 또는 item.SetActive(false);
    }
}
