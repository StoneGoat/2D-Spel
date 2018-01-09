using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet1 : MonoBehaviour {
	public Text AchievePet1;

	private Rigidbody2D rb;

	public float Speed;

	public bool PickedUp;
	public bool PlayerLeft;
	public bool PlayerRight;
	public bool ResetPos;
	public bool RPosCheck;
	public bool PlayerClose;
	public bool PlayerFarAway;

	public Transform Player;
	public Transform Pet;

	public float smoothing = 5f;

	// Use this for initialization
	void Start () {
		PickedUp = false;
		Speed = 1;
		AchievePet1.text = "";

		PlayerRight = true;
		PlayerLeft = false;
		ResetPos = false;
		PlayerClose = false;
		RPosCheck = false;
	}

	// Update is called once per frame
	void Update () {
		CheckforPlayerLeftOrRight ();
		PickUp ();
	}

	void CheckforPlayerLeftOrRight()
	{

		if ((Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) && PlayerRight == true) {
			PlayerLeft = true;
			transform.Rotate(new Vector3(0,180,0));
			PlayerRight = false;
			if (RPosCheck == true && PickedUp == true) {
				ResetPos = true;
				if (ResetPos == true) {
					Vector3 PetPosR = new Vector3 (Player.position.x + 3, Player.position.y, 0);
					transform.position = PetPosR;
					ResetPos = false;
				}
				RPosCheck = false;
			}
		}
		if ((Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) && PlayerLeft == true) {
			PlayerRight = true;
			transform.Rotate(new Vector3(0,180,0));
			PlayerLeft = false;
			if (RPosCheck == false && PickedUp == true) {
				ResetPos = true;
				if (ResetPos == true) {
					Vector3 PetPosL = new Vector3 (Player.position.x - 3, Player.position.y, 0);
					transform.position = PetPosL;
					ResetPos = false;
				}
				RPosCheck = true;
			}
		}
	}
	void PickUp()
	{
		if (PlayerFarAway == true && PlayerLeft == true) {
			Vector3 PetPosL = new Vector3 (Player.position.x + 3, Player.position.y, 0);
			transform.position = PetPosL;
		} else if (PlayerFarAway == true && PlayerRight == true) {
			Vector3 PetPosR = new Vector3 (Player.position.x - 3, Player.position.y, 0);
			transform.position = PetPosR;
		}
		if (PickedUp == true && ResetPos == false && PlayerClose == false) {
			transform.position = Vector3.Lerp (transform.position, Player.position, smoothing * Time.deltaTime);
		}

		if (((Pet.position.x >= Player.position.x - 3) && (Pet.position.x <= Player.position.x + 3)) && ((Pet.position.y >= Player.position.y - 3) && (Pet.position.y <= Player.position.y + 3)) && PickedUp == false) {
			PickedUp = true;
			Vector3 PetPosL = new Vector3 (Player.position.x - 3, Player.position.y, 0);
			transform.position = PetPosL;
			RPosCheck = true;
			PlayerRight = true;
		} 

		if (((Pet.position.x >= Player.position.x - 2) && (Pet.position.x <= Player.position.x + 2)) && ((Pet.position.y >= Player.position.y - 1) && (Pet.position.y <= Player.position.y + 1))) {
			PlayerClose = true;
		} else {
			PlayerClose = false;
		}
		if (((Pet.position.x >= Player.position.x + 10) | (Pet.position.x <= Player.position.x - 10)) && PickedUp == true) {
			PlayerFarAway = true;
		} else {
			PlayerFarAway = false;
		}
	}
}
