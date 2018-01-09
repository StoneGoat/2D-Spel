using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {
	public float Exp;

	public Text CurrentLVL;
	public Text LVLProgress;

	public int LvL;

	public static bool RageUnlock;


	// Use this for initialization
	void Start () {
		RageUnlock = false;
		PlayerController.xp = 0;
		LvL = 1;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController.xp = Exp;
		Exp = PlayerController.xp;
		Levels ();
	}
	void Levels ()
	{
		if (LvL == 1) {
			if (Exp >= 25) {

				LvL++;
			}
		}
		if (LvL == 2) {
			if (Exp >= 55) {

				LvL++;
			}
		}
		if (LvL == 3) {
			if (Exp >= 90) {

				LvL++;
			}
		}
		if (LvL == 4) {
			if (Exp >= 130) {

				LvL++;
			}
		}
		if (LvL == 5) {
			if (Exp >= 175) {
				RageUnlock = true;
				LvL++;
			}
		}
		if (LvL == 6) {
			if (Exp >= 225) {
				RageUnlock = true;
				LvL++;
			}
		}
		if (LvL == 7) {
			if (Exp >= 285) {
				RageUnlock = true;
				LvL++;
			}
		}
		if (LvL == 8) {
			if (Exp >= 355) {
				RageUnlock = true;
				LvL++;
			}
		}
		if (LvL == 9) {
			if (Exp >= 435) {
				RageUnlock = true;
				LvL++;
			}
		}
		if (LvL == 10) {
			if (Exp >= 525) {
				RageUnlock = true;
			}
		}
	}
}
