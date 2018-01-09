using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public Rigidbody2D bullet;
	public Transform Player;

	private bool ShootAvailable;
	public bool left;
	public bool right;

	public float bulletspeed;
	public float BulletTimer;
	public float RandomBullet;

	// Use this for initialization
	void Start () {
		ShootAvailable = true;
		right = true;
		left = false;
		BulletTimer = 0;
		RandomBullet = 0;
	}
	
	// Update is called once per frame
	void Update () {
		bulletspeed = PlayerController.speed * 1.5f;
		ShootBullet ();
		RandomBullet = Random.Range (-10, 10);
	}

	void ShootBullet () {
		if (Input.GetKey(KeyCode.M))
		{
			if (ShootAvailable == true && PlayerController.rage == false) {
				if (PlayerController.right == true) {
					Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (Player.position.x + 1, Player.position.y, Player.position.z), Quaternion.Euler (new Vector3 (0, 0, 1))) as Rigidbody2D;
					bulletInstance.velocity = Vector2.right * bulletspeed;
					ShootAvailable = false;
				} else if (PlayerController.left == true) {
					Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (Player.position.x - 1, Player.position.y, Player.position.z), Quaternion.Euler (new Vector3 (0, 0, 1))) as Rigidbody2D;
					bulletInstance.velocity = Vector2.left * bulletspeed;
					ShootAvailable = false;
				}
			}
			if (ShootAvailable == true && PlayerController.rage == true) {
				if (PlayerController.right == true) {
					Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (Player.position.x + 1, Player.position.y, Player.position.z), Quaternion.Euler (new Vector3 (0, 0, 1))) as Rigidbody2D;
					bulletInstance.velocity = new Vector3 (1 * bulletspeed, 1 * RandomBullet);
					ShootAvailable = false;
				} else if (PlayerController.left == true) {
					Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (Player.position.x - 1, Player.position.y, Player.position.z), Quaternion.Euler (new Vector3 (0, 0, 1))) as Rigidbody2D;
					bulletInstance.velocity = new Vector3 (-1 * bulletspeed, 1 * RandomBullet);
					ShootAvailable = false;
				}
			}
		}
		if (ShootAvailable == false) {
			BulletTimer = BulletTimer + 1;
			if (PlayerController.rage == true) {
				BulletTimer = BulletTimer + 1;
			}
		}
		if (BulletTimer >= 25 && PlayerController.rage == false) {
			ShootAvailable = true;
			BulletTimer = 0;
		}
		if (BulletTimer >= 2 && PlayerController.rage == true) {
			ShootAvailable = true;
			BulletTimer = 0;
		}
	}
}
