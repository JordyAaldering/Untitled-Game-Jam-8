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

		[SerializeField] private bool airControl;
		[SerializeField] private LayerMask whatIsGround;

		[SerializeField] private Transform groundCheck;
		[SerializeField] private Transform ceilingCheck;
		[SerializeField] private Collider2D crouchDisableCollider;

		[System.Serializable]
		public class BoolEvent : UnityEvent<bool> { }
		
		[Header("Events"), Space]
		public UnityEvent OnLandEvent;
		public BoolEvent OnCrouchEvent;

		private bool grounded = false;
		private bool facingRight = true;
		private bool wasCrouching = false;
		
		private Rigidbody2D rb;
		private Vector3 velocity;
		private PlayerAnimatorController anim;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
			anim = GetComponentInChildren<PlayerAnimatorController>();

			if (OnLandEvent == null)
				OnLandEvent = new UnityEvent();

			if (OnCrouchEvent == null)
				OnCrouchEvent = new BoolEvent();
		}

		private void FixedUpdate()
		{
			bool wasGrounded = grounded;
			grounded = false;

			Collider2D[] cols = new Collider2D[1];
			int size = Physics2D.OverlapCircleNonAlloc(groundCheck.position, 0.2f, cols, whatIsGround);
			if (size > 0)
			{
				grounded = true;
				if (!wasGrounded)
				{
					OnLandEvent.Invoke();
				}
			}
		}
		
		public void Move(float move, bool run, bool crouch, bool jump)
		{
			Collider2D[] cols = new Collider2D[1];
			int size = Physics2D.OverlapCircleNonAlloc(ceilingCheck.position, 0.2f, cols, whatIsGround);
			if (wasCrouching && size > 0)
			{
				crouch = true;
			}

			if (grounded || airControl)
			{
				if (crouch)
				{
					if (!wasCrouching)
					{
						wasCrouching = true;
						OnCrouchEvent.Invoke(true);
					}

					move *= crouchSpeed;

					if (crouchDisableCollider != null)
						crouchDisableCollider.enabled = false;
				}
				else
				{
					if (run)
					{
						move *= runSpeed;
					}

					if (crouchDisableCollider != null)
						crouchDisableCollider.enabled = true;

					if (wasCrouching)
					{
						wasCrouching = false;
						OnCrouchEvent.Invoke(false);
					}
				}

				Vector2 vel = rb.velocity;
				Vector2 targetVelocity = new Vector2(move * moveSpeed, vel.y);

				vel = Vector3.SmoothDamp(vel, targetVelocity, ref velocity, movementSmoothing);
				rb.velocity = vel;
				anim.Move(vel);

				if (move > 0 && !facingRight || move < 0 && facingRight)
				{
					Flip();
				}
			}

			if (grounded && jump)
			{
				grounded = false;
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
