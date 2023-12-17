using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class myownmovemnts : MonoBehaviour
    {
        public Animator animator;
        private float horizontal;
        private float Speed = 8f;
        private float jumpingpower = 10f; // Adjusted jumping power
        private bool isFacingRight = true;
        private bool isGroundedVar;
        private Rigidbody2D rb;
        private float groundCheckRadius = 0.2f;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        // Update is called once per frame
        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal") * Speed;

            // Set the "Speed" parameter in the Animator
            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                // Trigger the "Jump" animation
                animator.SetTrigger("Jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
            }

            Flip();
        }

        private void FixedUpdate()
        {
            // Use rb.AddForce to apply horizontal movement
            rb.AddForce(new Vector2(horizontal * Speed, 0f));

            // Limit the horizontal velocity to the Speed
            float limitedSpeed = Mathf.Clamp(rb.velocity.x, -Speed, Speed);
            rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);

            // If not moving horizontally, set "Speed" to 0 to transition to idle
            if (Mathf.Abs(horizontal) < 0.01f)
            {
                animator.SetFloat("Speed", 0f);
            }
        }

        private bool isGrounded()
        {
            // Use Physics2D.OverlapCircle to check if the player is grounded
            isGroundedVar = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            return isGroundedVar;
        }

        private void Flip()
        {
            if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        // This function is called by Animation Events to return to the "Idle" state
        public void ReturnToIdle()
        {
            // Trigger the "Idle" animation
            animator.SetTrigger("Idle");
        }
    }
}