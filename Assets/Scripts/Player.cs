using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 이동 속도 설정
    public float moveSpeed = 5f;

    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 새로운 Input System 사용하여 방향키 입력 받기
        movement = Vector2.zero;

        // Keyboard를 사용한 입력 처리
        if (Keyboard.current != null)
        {
            bool isWKeyPressed = Keyboard.current.wKey.isPressed;
            bool isUpKeyPressd = Keyboard.current.upArrowKey.isPressed;

            bool isSKeyPressed = Keyboard.current.sKey.isPressed;
            bool isDownKeyPressd = Keyboard.current.downArrowKey.isPressed;

            bool isAKeyPressed = Keyboard.current.aKey.isPressed;
            bool isLeftKeyPressed = Keyboard.current.leftArrowKey.isPressed;

            bool isDKeyPressed = Keyboard.current.dKey.isPressed;
            bool isRightKeyPressed = Keyboard.current.rightArrowKey.isPressed;

            if (isWKeyPressed || isUpKeyPressd)
                movement.y = 1f;
            if (isSKeyPressed || isDownKeyPressd)
                movement.y = -1f;
            if (isAKeyPressed || isLeftKeyPressed)
                movement.x = -1f;
            if (isDKeyPressed || isRightKeyPressed)
                movement.x = 1f;
        }

        // 대각선 이동 시 속도 정규화
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // 디버그 로그로 입력 확인 (처음 몇 번만)
        if (movement.magnitude > 0 && Time.frameCount < 100 && Time.frameCount % 30 == 0)
        {
            Debug.Log($"[Player] 입력 감지됨: X={movement.x}, Y={movement.y}, 위치: {transform.position}");
        }
    }

}
