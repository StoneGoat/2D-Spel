using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	public static float xp;

	static public float speed = 0;
	public float jumpspeed = 1;

	public float FrameHealth = 5000;
	public float Health;
	public float HealthTimer;

	public float Damage = 10;
	public float HitTimer;

	private float moveX;

	public bool grounded;

	public float RageTimer = 0;
	public static bool rage;
	public bool ragemultiplier;

	public static bool left;
	public static bool right;

	public bool TimerTime;
	public bool Hit;

	public bool DJumpCheck;
	public bool TJumpCheck;
	public bool JumpCheckOne;
	public bool JumpCheckTwo;
	public bool JumpCheckThree;
	public bool TJumpBoost;
	public bool NGJump;

	public bool EnterDoor1Check;
	public bool DoorCheck1;

	public Text Door1Text;
	public Text Ragetext;

	// Use this for initialization
	void Start () {
		left = false;
		right = true;

		rage = false;
		ragemultiplier = false;
		RageTimer = 10000;

		speed = 10;

		JumpCheckOne = false;
		JumpCheckTwo = false;
		JumpCheckThree = false;
		TJumpBoost = false;
		DJumpCheck = false;
		TJumpCheck = false;

		DoorCheck1 = false;
		Door1Text.text = "";

		Hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Jump ();
		DoubleJump ();
		TripleJump ();
		CheckforPlayerLeftOrRight ();
		DoorTexts ();
		Door1 ();
		HealthControl ();
		Rage ();
		HitCheck ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			grounded = true;
			DJumpCheck = false;
			JumpCheckOne = false;
			JumpCheckTwo = false;
			JumpCheckThree = false;
			TJumpCheck = false;
			NGJump = false;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			grounded = false;
		}
	
	}
	void Jump()
	{
		if (Input.GetButtonDown ("Jump") && grounded == true) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpspeed;
			JumpCheckOne = true;
		}
		if (Input.GetButtonUp ("Jump") && JumpCheckOne == true) {
			DJumpCheck = true;
			JumpCheckOne = false;
		}
	}
	void DoubleJump()
	{
		if (Input.GetButtonDown ("Jump") && (DJumpCheck == true | (grounded == false && NGJump == false))) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpspeed;
				JumpCheckTwo = true;
			if (grounded == false) {
				NGJump = true;
			}
		}
		if (Input.GetButtonUp ("Jump") && JumpCheckTwo == true) {
			TJumpCheck = true;
			DJumpCheck = false;
			JumpCheckTwo = false;
		}
	}
		
	void TripleJump()
	{
		if (Input.GetButtonDown ("Jump") && TJumpCheck == true && TJumpBoost == true) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpspeed;
				JumpCheckThree = true;
		}
		if (Input.GetButtonUp ("Jump") && JumpCheckThree == true) {
			TJumpCheck = false;
			JumpCheckThree = false;
			TJumpBoost = false;
		}
	}

	void Move ()
	{
		moveX = Input.GetAxis ("Horizontal");	
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void CheckforPlayerLeftOrRight()
	{
		if ((Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) && right == true) {
			left = true;
			transform.Rotate(new Vector3(0,180,348));
			right = false;
		}
		if ((Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) && left == true) {
			right = true;
			transform.Rotate(new Vector3(0,180,348));
			left = false;
		}
	}
	void DoorTexts()
	{
		if (((this.gameObject.transform.position.x < 12) && (this.gameObject.transform.position.x > 10)) && ((this.gameObject.transform.position.y < 1) && (this.gameObject.transform.position.y > -1 && DoorCheck1 == false)))
			{	
			Door1Text.text = "Press Z to Enter";
			EnterDoor1Check = true;
		}
			else 
			{
				EnterDoor1Check = false;
				Door1Text.text = "";
			}
	}
	void Door1()
	{
		if (EnterDoor1Check = true && Input.GetKey(KeyCode.Z) && DoorCheck1 == false) {
			this.transform.position = new Vector2 (100, 50);
			DoorCheck1 = true;
		}
	}
	void HealthControl()
	{
		Health = FrameHealth / 50;
		if (FrameHealth >= 5000) {
			FrameHealth = 5000;
		}
		if (FrameHealth < 5000 && rage == false) {
			HealthTimer++;
		}
		if (FrameHealth < 2500 && rage == true) {
			HealthTimer++;
		}
		if (HealthTimer >= 500 && rage == false) {
			FrameHealth++;
			if (HealthTimer >= 1000) {
				FrameHealth = FrameHealth + 0.5f;
				if (HealthTimer >= 1500) {
					FrameHealth = FrameHealth + 0.5f;
					if (HealthTimer >= 2000) {
						FrameHealth = FrameHealth + 0.5f;
						if (HealthTimer >= 2500) {
							FrameHealth = FrameHealth + 0.5f;
						}
					}
				}
			}
		}
		if (HealthTimer >= 500 && rage == true) {
			FrameHealth++;
			if (HealthTimer >= 1000) {
				FrameHealth = FrameHealth + 0.5f;
				if (HealthTimer >= 1500) {
					FrameHealth = FrameHealth + 0.5f;
					if (HealthTimer >= 2000) {
						FrameHealth = FrameHealth + 0.5f;
					}
				}
			}
		}
		if ((FrameHealth == 5000 && rage == false) | (FrameHealth == 2500 && rage == true) | (Hit == true)) {
			TimerTime = false;
		} else if (FrameHealth < 5000 && rage == false) {
			TimerTime = true;
		} else if (FrameHealth < 2500 && rage == true) {
			TimerTime = true;
		}
		if (TimerTime == false) {
			HealthTimer = 0;
		}
	}
	void HitCheck()
	{
		if (Hit == true) {
			HitTimer++;
		}
		if (HitTimer >= 500) {
			Hit = false;
			HitTimer = 0;
		}
	}
	void Rage()
	{
		if (Experience.RageUnlock == true) {
			if (RageTimer >= 120) {
				RageTimer = 120;
			}
			if (RageTimer == 0 && Input.GetKey (KeyCode.X) && rage == false) {
				rage = true;
				RageTimer = 10;
			}
			if (RageTimer >= 0) {
				Ragetext.text = RageTimer.ToString ("0") + " s";
				RageTimer = RageTimer - Time.deltaTime;
			}
			if (RageTimer <= 0) {
				RageTimer = 0;
				Ragetext.text = "Rage Available";
			}
			if (rage == true) {
				TJumpBoost = true;
				if (RageTimer == 0) {
					rage = false;
					RageTimer = 120;
				}
			}
			if (rage == true && ragemultiplier == false) {
				speed = speed * 2;
				jumpspeed = jumpspeed * 1.5f;
				Damage = Damage / 4;
				FrameHealth = FrameHealth / 2;
				ragemultiplier = true;
			}
			if (rage == false && ragemultiplier == true) {
				speed = speed / 2;
				jumpspeed = jumpspeed / 1.5f;
				Damage = Damage * 4;
				ragemultiplier = false;
				HealthTimer = 500;
			}
		} else {
			Ragetext.text = "LvL 5 Required for Rage";
		}
	}
}
