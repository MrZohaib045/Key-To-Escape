using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class joystickcontroller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;  // Reference to the Rigidbody
    [SerializeField] private Animator animator;  // Reference to the Animator
    [SerializeField] private float speed = 5f;  // Movement speed

    private bool alive = true;  // Variable to check if the player is alive
    private bool move = true;  // Variable to check if movement is allowed

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && move)
        {
            if (alive)
            {
                // Get the mouse input and calculate the movement direction
                Vector3 direction = Vector3.forward * Input.GetAxis("Mouse Y") + Vector3.right * Input.GetAxis("Mouse X");

                // Move the player forward
                rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
                rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;

                // If the direction is not zero, rotate the player toward the movement direction
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 8.5f * Time.deltaTime);
                }

                // Set the run animation
                animator.SetBool("isRun", true);
            }
        }
        else
        {
            // If not moving, reset the animation
            animator.SetBool("isRun", false);
        }
    }

    public void onclick()
    {
        animator.SetBool("Attack", true);
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attack", false);
    }

    public void powerattack()
    {
        animator.SetBool("jumpAttack", true);
        StartCoroutine(ResetjumpAttack());
    }

    IEnumerator ResetjumpAttack()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("jumpAttack", false);
    }
}
