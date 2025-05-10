using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Jump : MonoBehaviour
{
    private CharacterController _controller;
    public float jumpHeight = 3.0f;
    public float gravity = -9.81f; // 중력 가속도
    private float _verticalVelocity; // 수직 속도
    private Vector3 _moveDirection; // 이동 방향

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    public void OnJump(InputValue value) // 점프 인풋 시스템 호출 함수.
    {
        if (value.isPressed && _controller.isGrounded) // 점프 입력이 눌렸고, 지면에 있을 때
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity); // 점프 속도 계산: v = sqrt(2 * g * h)
            
        }

    }

    void Update()
    {
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
        }
        
    }

}
