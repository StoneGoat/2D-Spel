using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Transform Player;
	//public float SBulletPos;
	//public float BulletPos;
	public bool BulletToFarAway;
	public float Lifetime;

	// Use this for initialization
	void Start () {
		// SBulletPos = transform.position.x;
		Lifetime = 3;
	}
	
	// Update is called once per frame
	void Update () {
		Lifetime = Lifetime - Time.deltaTime;
		if (Lifetime <= 0) {
		//BulletPos = transform.position.x;
		//if ((BulletPos >= SBulletPos + 100) | (BulletPos <= SBulletPos - 100)) {
			DestroyObject (this.gameObject);

		}
	}
}
