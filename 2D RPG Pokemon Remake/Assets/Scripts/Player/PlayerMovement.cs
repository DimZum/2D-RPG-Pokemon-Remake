using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Transform movePoint;

    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start() {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(transform.position, movePoint.position) == 0) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement != Vector2.zero) {
                if (movement.x != 0) {
                    animator.SetFloat("Horizontal", movement.normalized.x);
                    animator.SetFloat("Vertical", 0);
                }

                if (movement.y != 0) {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", movement.normalized.y);
                }

            }

            //animator.SetFloat("Horizontal", movement.normalized.x);
            //animator.SetFloat("Vertical", movement.normalized.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate() {
        if (Vector3.Distance(transform.position, movePoint.position) == 0) {
            // Check for horizontal movement
            if (Mathf.Abs(movement.x) == 1f) {
                movePoint.position += new Vector3(movement.x, 0, 0);
            }

            // Check for vertical movement
            else if (Mathf.Abs(movement.y) == 1f) {
                movePoint.position += new Vector3(0, movement.y, 0);
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        }
    }
}