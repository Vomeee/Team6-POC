using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    //Move 관련
    private CharacterController _controller;
    private Vector2 _moveInput; // WASD 값 (Vector2)
    private Transform _cameraTransform;
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private bool _isSprint = false;



    //점프 관련
    public float jumpHeight = 3.0f;
    public float gravity = -9.81f; // 중력 가속도
    private float _verticalVelocity; // 수직 속도
    private Vector3 _moveDirection; // 이동 방향

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    } // 인풋시스템 vector2 받아옴.

    public void OnSprint(InputValue value)
    {
        bool isPressed = value.isPressed;
        _moveSpeed = isPressed ? 5.0f : 3.0f;
    } // 달리기 사용시, 이동속도 제어

    private void Move() // 카메라 및 인풋에 따른 캐릭터 이동 (WASD) + 중력 작용
    {
        // 카메라 기준 방향 계산
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        // 수직 방향 제거 (y축 = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // WASD → 카메라 기준 방향으로 변환
        Vector3 move = forward * _moveInput.y + right * _moveInput.x;

        // 이동
        _controller.Move(move * _moveSpeed *  Time.deltaTime);
    } 

    private void Jump()
    {
        if (!_controller.isGrounded)
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }
        else if (_verticalVelocity < 0)
        {
            _verticalVelocity = -2f; // 지면에 있을 때 약간의 하향 속도 유지
        }

        _moveDirection.y = _verticalVelocity; // 이동 방향에 수직 속도 적용

        _controller.Move(_moveDirection * Time.deltaTime); // CharacterController의 수직 업데이트.
    } // 중력 작용 코드.

    public void OnJump(InputValue value) // 점프 인풋 시스템 호출 함수.
    {
        if (value.isPressed && _controller.isGrounded) // 점프 입력이 눌렸고, 지면에 있을 때
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity); // 점프 속도 계산: v = sqrt(2 * g * h)

        }

    }

    private void FixedUpdate() // 픽스드 업데이트~  / 여우가 업데이트 했으면? Foxed 업데이트~ ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ
    {
        Move();
        Jump();
    }

}
