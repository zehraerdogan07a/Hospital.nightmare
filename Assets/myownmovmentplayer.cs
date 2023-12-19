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
        private Rigidbody2D rb;
        private float groundCheckRadius = 0.2f;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            // Set the "Speed" parameter in the Animator
            animator.SetFloat("Speed", Mathf.Abs(horizontal));


            Flip();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);



            // Limit the horizontal velocity to the Speed
            float limitedSpeed = Mathf.Clamp(rb.velocity.x, -Speed, Speed);
            rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);

            // If not moving horizontally, set "Speed" to 0 to transition to idle
            if (Mathf.Abs(horizontal) < 0.0f)
            {
                animator.SetFloat("Speed", 0f);
            }

        }

        private bool isGrounded()
        {
            // Use Physics2D.OverlapCircle to check if the player is grounded
            return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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