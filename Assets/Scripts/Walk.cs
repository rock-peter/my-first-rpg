using UnityEngine;
using UnityEngine.InputSystem;

public class Walk : MonoBehaviour
{
  public float moveSpeed = 5f;
  public Animator animator;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Vector2 movement = Vector2.zero;

    // Keyboard를 사용한 입력 처리
    if (Keyboard.current != null)
    {
      /**
       * wasPressedThisFrame: 한 번 누름
       * isPressed: 계속 누름
       * wasReleasedThisFrame: 누르고 땜
      **/
      // Up Key
      if (Keyboard.current.wKey.wasPressedThisFrame ||
          Keyboard.current.wKey.wasReleasedThisFrame ||
          Keyboard.current.upArrowKey.wasPressedThisFrame ||
          Keyboard.current.upArrowKey.wasReleasedThisFrame)
      {
        animator.SetInteger("walkingStatus", 0);
        animator.SetBool("isWalking", false);
      }

      else if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
      {
        movement.y = 1f;
        animator.SetInteger("walkingStatus", 0);
        animator.SetBool("isWalking", true);
      }
      // Down Key
      else if (Keyboard.current.sKey.wasPressedThisFrame ||
         Keyboard.current.sKey.wasReleasedThisFrame ||
         Keyboard.current.downArrowKey.wasPressedThisFrame ||
         Keyboard.current.downArrowKey.wasReleasedThisFrame)
      {
        animator.SetInteger("walkingStatus", 2);
        animator.SetBool("isWalking", false);
      }

      else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
      {
        movement.y = -1f;
        animator.SetInteger("state", 2);
        animator.SetBool("isWalking", true);
      }

      // Left Key
      else if (Keyboard.current.aKey.wasPressedThisFrame ||
        Keyboard.current.aKey.wasReleasedThisFrame ||
        Keyboard.current.leftArrowKey.wasPressedThisFrame ||
        Keyboard.current.leftArrowKey.wasReleasedThisFrame)
      {
        animator.SetInteger("walkingStatus", 3);
        animator.SetBool("isWalking", false);
      }

      else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
      {
        movement.x = -1f;
        animator.SetInteger("walkingStatus", 3);
        animator.SetBool("isWalking", true);
      }

      // Right Key
      else if (Keyboard.current.dKey.wasPressedThisFrame ||
           Keyboard.current.dKey.wasReleasedThisFrame ||
           Keyboard.current.rightArrowKey.wasPressedThisFrame ||
           Keyboard.current.rightArrowKey.wasReleasedThisFrame)
      {
        animator.SetInteger("walkingStatus", 1);
        animator.SetBool("isWalking", false);
      }

      else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
      {
        movement.x = 1f;
        animator.SetInteger("walkingStatus", 1);
        animator.SetBool("isWalking", true);
      }

      else
      {
        animator.SetBool("isWalking", false);
      }
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
  }
}
