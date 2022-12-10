using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P1TrainingScript : MonoBehaviour {

	TrainingScript manager;
	ETCJoystick etcJoystick;

	public GameObject joystick;

	public GameObject bajay;

	int sAttackTimer = 100;
	int sAttackTimerMax = 100;
	int sAttack3Timer = 40;
	int sAttack3TimerMax = 40;

	int p1StandUpTimer = 40;
	int p1StandUpTimerMax = 40;
	int p1WalkTimer = 40;
	int p1WalkTimerMax = 40;

	int p1BowEndTimer = 80;
	int p1BowEndTimerMax = 80;

	float p1Z = 0f;
	float maxSpeed = 0.08f;

	float defPoint = 20f;
	float attPoint = 8f;
	float sAtt1Damage = 40f;
	float sAtt2Damage = 80f;
	float sAtt3Damage = 120f;

	bool joystickActive = false;

	//bool facingRight = true;
	bool fight;
	bool chat;

	bool p1MoveUpZ = false;
	bool p1MoveDownZ = false;
	bool p1MoveX = false;

	bool sAttack1 = false;
	bool sAttack2 = false;
	bool sAttack3 = false;
	bool sAttackStart = false;
	bool sAttack3Start = false;

	bool block = false;
	bool dodge = false;
	bool p1MoveBack = false;
	bool p1StandUpStart = false;
	bool p1WalkStart = false;

	public bool hitTextFollowP1 = false;

	bool p1BowEnd = false;

	Animator anim;
	Animator patrickAnim;

	public bool JoystickActive {
		
		get {
			return joystickActive;
		}
		set {
			joystickActive = value;
		}
	}

	public bool P1MoveUpZ {
		
		get {
			return p1MoveUpZ;
		}
		set {
			p1MoveUpZ = value;
		}
	}

	public bool P1MoveDownZ {
		
		get {
			return p1MoveDownZ;
		}
		set {
			p1MoveDownZ = value;
		}
	}

	public bool P1MoveX {
		
		get {
			return p1MoveX;
		}
		set {
			p1MoveX = value;
		}
	}

	public bool SAttack1 {
		
		get {
			return sAttack1;
		}
		set {
			sAttack1 = value;
		}
	}

	public bool SAttack2 {
		
		get {
			return sAttack2;
		}
		set {
			sAttack2 = value;
		}
	}

	public bool SAttack3 {
		
		get {
			return sAttack3;
		}
		set {
			sAttack3 = value;
		}
	}

	public bool SAttack3Start {
		
		get {
			return sAttack3Start;
		}
		set {
			sAttack3Start = value;
		}
	}

	public bool Block {
		
		get {
			return block;
		}
		set {
			block = value;
		}
	}

	public bool Dodge {
		
		get {
			return dodge;
		}
		set {
			dodge = value;
		}
	}

	public int SAttackTimer {
		
		get {
			return sAttackTimer;
		}
		set {
			sAttackTimer = value;
		}
	}

	public int SAttackTimerMax {
		
		get {
			return sAttackTimerMax;
		}
		set {
			sAttackTimerMax = value;
		}
	}

	public int SAttack3Timer {
		
		get {
			return sAttack3Timer;
		}
		set {
			sAttack3Timer = value;
		}
	}
	
	public int SAttack3TimerMax {
		
		get {
			return sAttack3TimerMax;
		}
		set {
			sAttack3TimerMax = value;
		}
	}

	void Awake () {
	
		manager = GameObject.Find("MainController").GetComponent<TrainingScript> ();
		etcJoystick = GameObject.Find ("DynamicJoystick").GetComponent<ETCJoystick> ();

		transform.position = new Vector3 (0, 0, 0);

	}

	void Update () {

		fight = manager.fight;
		chat = manager.chat;

		anim = manager.anim;

		joystick.SetActive (false);

		if (Time.timeScale != 0) {

			if (bajay.transform.position.x < 10f && bajay.transform.position.x > -10f && manager.bajaySound.isPlaying == false) {
				manager.bajaySound.Play ();
			}

			// --- P1 strolling mode & movements ---
			if (transform.position.x < -8f) {
				transform.position = new Vector3 (-8f, transform.position.y, transform.position.z);
			}
		
			if (transform.position.x > 8f) {
				transform.position = new Vector3 (8f, transform.position.y, transform.position.z);
			}
		
			float moveH = Input.GetAxis ("Horizontal");
		
			if (!fight) {
			
				if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
					if (transform.position.z < 2f) {
						p1MoveUpZ = true;
					}
				}
			
				if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
					if (transform.position.z > -2f) {
						p1MoveDownZ = true;
					}
				}
			
				if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
					p1MoveX = true;
					if (!chat) {
						transform.localScale = new Vector3 (1, 1, 1);
					}
				}

				if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
					p1MoveX = true;
					if (!chat) {
						transform.localScale = new Vector3 (-1, 1, 1);
					}
				}
			
				if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
					p1MoveX = false;
					anim.SetBool ("Walk", false);
				}
			
				if (p1MoveUpZ && !chat) {
				
					p1MoveDownZ = false;
					if (transform.position.z < 2f) {
						anim.SetBool ("Walk", true);
						p1Z += 0.04f;
						transform.position = new Vector3 (transform.position.x, transform.position.y, p1Z);
					}
				}
			
				if (p1MoveDownZ && !chat) {
				
					p1MoveUpZ = false;
					if (transform.position.z > -2f) {
						anim.SetBool ("Walk", true);
						p1Z -= 0.04f;
						transform.position = new Vector3 (transform.position.x, transform.position.y, p1Z);
					}
				}
			
				if (transform.position.z > -1.1f && transform.position.z < -1f && p1MoveUpZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -1f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z > -0.1f && transform.position.z < 0f && p1MoveUpZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z > 0.9f && transform.position.z < 1f && p1MoveUpZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z > 2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 2f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z < 1.1f && transform.position.z > 1f && p1MoveDownZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (transform.position.z < 0.1f && transform.position.z > 0f && p1MoveDownZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (transform.position.z < -0.9f && transform.position.z > -1f && p1MoveDownZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -1f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (transform.position.z < -2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -2f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (p1MoveX && !chat) {
					anim.SetBool ("Walk", true);
					transform.position = new Vector3 (transform.position.x + (moveH * maxSpeed), transform.position.y, transform.position.z);
				}

				if (joystickActive && etcJoystick.axisX.axisValue == 0 && p1MoveX) {
					joystickActive = false;
					p1MoveX = false;
					anim.SetBool ("Walk", false);
				}

				if (etcJoystick.axisX.axisValue > 0) {
					transform.localScale = new Vector3 (1, 1, 1);
					anim.SetBool ("Walk", true);
				}

				if (etcJoystick.axisX.axisValue < 0) {
					transform.localScale = new Vector3 (-1, 1, 1);
					anim.SetBool ("Walk", true);
				}

			}

		}

	}

}
