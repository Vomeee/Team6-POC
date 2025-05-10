using System;
using UnityEngine;

public class TemporaryFirstPersonController : MonoBehaviour
{

    //public static Action<GameObject> OnLevorHit;

    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;

    [Header("Look Settings")]
    public float mouseSensitivity = 100f;

    [SerializeField] private Transform _playerCamera;
    private float _xRotation = 0f;
    [SerializeField] private float _interactionDistance = 5f;
    [SerializeField] private Camera _mainCamera;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMouseLook();
        UpdateMovement();
        HandleInteraction();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _playerCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void UpdateMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move.normalized * _moveSpeed * Time.deltaTime;
    }
    private void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance))
            {
                if (hit.collider.CompareTag("Levor"))
                {
                    Debug.DrawLine(hit.point, hit.point + Vector3.up * 0.1f, Color.green, 1f);
                    Debug.Log("Levor object in range!");
                    //OnLevorHit?.Invoke(hit.collider.gameObject);
                    // 여기에 추가 액션(ex. UI 알림 등)을 구현 가능
                }
            }
        }
    }
}
