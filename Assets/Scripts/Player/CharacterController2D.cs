#pragma warning disable CS0649
using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
	public class CharacterController2D : MonoBehaviour
	{
		[SerializeField] private float jumpForce = 400f;
		[SerializeField] private float moveSpeed = 5f;
		[SerializeField, Range(1f, 2f)] private float runSpeed = 1.1f;
		[SerializeField, Range(0f, 1f)] private float crouchSpeed = 0.36f;
		[SerializeField, Range(0f, 0.3f)] private float movementSmoothing = 0.05f;

		[SerializeField] private LayerMask whatIsGround;

		[SerializeField] private Transform groundCheck;
		[SerializeField] private Transform ceilingCheck;
		[SerializeField] private Collider2D crouchDisableCollider;

		[HideInInspector] public UnityEvent OnLandEvent = new UnityEvent();

		private bool hasJumped = false;
		private bool grounded = false;
		private bool facingRight = true;
		private bool wasCrouching = false;
		private Vector2 velocity = Vector2.zero;
		
		private Rigidbody2D rb;
		private PlayerAnimatorController anim;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
			anim = GetComponentInChildren<PlayerAnimatorController>();
		}

		private void FixedUpdate()
		{
			bool wasGrounded = grounded;
			
			Collider2D[] cols = new Collider2D[1];
			int size = Physics2D.OverlapCircleNonAlloc(groundCheck.position, 0.1f, cols, whatIsGround);
			grounded = size > 0;
			
			if (grounded && !wasGrounded)
			{
				if (!hasJumped)
					OnLandEvent.Invoke();

				hasJumped = false;
			}
		}
		
		public void Move(float move, bool run, bool crouch, bool jump)
		{
			Collider2D[] cols = new Collider2D[1];
			int size = Physics2D.OverlapCircleNonAlloc(ceilingCheck.position, 0.1f, cols, whatIsGround);
			if (wasCrouching && size > 0)
			{
				crouch = true;
			}

			crouchDisableCollider.enabled = !crouch;
			if (crouch)
			{
				if (!wasCrouching)
					wasCrouching = true;

				move *= crouchSpeed;
			}
			else
			{
				if (run)
					move *= runSpeed;

				if (wasCrouching)
					wasCrouching = false;
			}

			Vector2 vel = rb.velocity;
			Vector2 targetVelocity = new Vector2(move * moveSpeed, vel.y);

			vel = Vector2.SmoothDamp(vel, targetVelocity, ref velocity, movementSmoothing);
			rb.velocity = vel;
			anim.Move(vel);

			if (move > 0 && !facingRight || move < 0 && facingRight)
				Flip();
			
			if (grounded && jump)
			{
				grounded = false;
				hasJumped = true;
				rb.AddForce(new Vector2(0f, jumpForce));
			}
		}
		
		private void Flip()
		{
			facingRight = !facingRight;

			Transform t = transform;
			Vector2 scale = t.localScale;
			t.localScale = scale.With(x: -scale.x);
		}
	}
}
