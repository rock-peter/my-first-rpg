using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 이동 속도 설정
    public float moveSpeed = 5f;

    private Vector2 movement;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
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

        // 실제 이동 적용
        if (movement.magnitude > 0)
        {
            transform.position += (Vector3)movement * moveSpeed * Time.deltaTime;
        }

        // 애니메이션 제어
        if (animator != null)
        {
            // 이동 방향과 속도를 Animator에 전달
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.magnitude);

            // isWalking 파라미터로 걷기/대기 애니메이션 전환 (기존 방식 유지)
            animator.SetBool("isWalking", movement.magnitude > 0);
        }

        // 디버그 로그로 입력 확인 (처음 몇 번만)
        if (movement.magnitude > 0 && Time.frameCount < 100 && Time.frameCount % 30 == 0)
        {
            Debug.Log($"[Player] 입력 감지됨: X={movement.x}, Y={movement.y}, 위치: {transform.position}");
        }
    }

}
