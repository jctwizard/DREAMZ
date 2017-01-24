using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YOUR_MOVEMENT : MonoBehaviour 
{
	const int LEFT = 0;
	const int RIGHT = 1;

	public string moveAxis = "Horizontal";
	public string jumpKey = "Jump";
	public string fireKey = "Fire1";
	public string upActionKey = "Up";
	public string downActionKey = "Down";

	public float maxHorizontalSpeed = 1.0f;
	public float maxVerticalSpeed = 1.0f;
	public float horizontalAcceleration = 0.1f;
	public float jumpAcceleration = 10.0f;

	public GameObject projectile;
	public Transform projectileSpawn;
	public float fireSpeed = 2.0f;

	private int facing = RIGHT;

	public bool grounded = false;
	private Rigidbody2D rigidbodyRef;

	private float movementInput = 0.0f;
	private bool jumpPressed = false;
	private bool firePressed = false;

	private GameObject currentProjectile;
	private bool blowing = false;

	public GameObject error;

	private bool atDoor = false;

	void Start () 
	{
		rigidbodyRef = GetComponent<Rigidbody2D>();	
	}

	void Update () 
	{
		firePressed = Input.GetButtonDown(fireKey);
		movementInput = Input.GetAxis(moveAxis);
		jumpPressed = Input.GetButtonDown(jumpKey);

		if (blowing)
		{
			if (Input.GetButtonUp(fireKey))
			{
				blowing = false;
				currentProjectile.GetComponent<PROJECTILE_MOVEMENT>().scaling = false;
				currentProjectile.transform.parent = null;

				if (facing == LEFT)
				{
					currentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(-fireSpeed, 0, 0);
				}
				else
				{
					currentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(fireSpeed, 0, 0);
				}
			}
			else
			{
				movementInput *= 0.5f;
			}
		}

		if (movementInput > 0 && rigidbodyRef.velocity.x <= 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
			rigidbodyRef.velocity = new Vector3(0, rigidbodyRef.velocity.y, 0);
			facing = RIGHT;
		}
		if (movementInput < 0 && rigidbodyRef.velocity.x >= 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
			rigidbodyRef.velocity = new Vector3(0, rigidbodyRef.velocity.y, 0);
			facing = LEFT;
		}

		rigidbodyRef.velocity = new Vector3(movementInput * maxHorizontalSpeed, rigidbodyRef.velocity.y, 0);

		/*if (rigidbodyRef.velocity.x > maxHorizontalSpeed)
		{
			rigidbodyRef.velocity = new Vector3(maxHorizontalSpeed, rigidbodyRef.velocity.y, 0);
		}
		else if (rigidbodyRef.velocity.x < -maxHorizontalSpeed)
		{
			rigidbodyRef.velocity = new Vector3(-maxHorizontalSpeed, rigidbodyRef.velocity.y, 0);
		}
		else
		{
			rigidbodyRef.AddForce(new Vector2(movementInput * horizontalAcceleration * Time.fixedDeltaTime, 0.0f));
		}*/

		if (grounded)
		{
			if (jumpPressed)
			{
				rigidbodyRef.AddForce(new Vector2(0.0f, jumpAcceleration));
				grounded = false;
			}
		}
		else if (rigidbodyRef.velocity.y < -maxVerticalSpeed)
		{
			rigidbodyRef.velocity = new Vector3(rigidbodyRef.velocity.x, -maxVerticalSpeed, 0);
		}

		if (firePressed)
		{
			currentProjectile = Instantiate(projectile) as GameObject;
			blowing = true;
			currentProjectile.transform.SetParent(projectileSpawn, false);

			if (facing == LEFT)
			{
				currentProjectile.transform.localScale = new Vector3(-1, 1, 1);
			}
		}

		if (Input.GetButtonDown(upActionKey) || Input.GetButtonDown(downActionKey) && atDoor)
		{
			error.SetActive(true);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Vector3 collisionPosition = collision.contacts[0].point;

			if (collisionPosition.y < transform.position.y)
			{
				grounded = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Door")
		{
			atDoor = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Door")
		{
			atDoor = false;
		}
	}
}
