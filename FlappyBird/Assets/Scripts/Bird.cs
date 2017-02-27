using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float jumpPower = 4f;
	public GameObject imageBird;
	public Vector3 lookDirection;
	public static Bird bird;

	void Awake (){
		bird = this;
	}

	void Update () {
		if (GameManager.manager.end == false){
			if (Input.GetMouseButtonDown(0) && GameManager.manager.start && !GameManager.manager.end && this.transform.position.y < 5f) {
                print("clock Jump");
				GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
				GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
				GetComponent<AudioSource>().Play();
			}
		}
		if (GameManager.manager.ready == false) {
				lookDirection.z = GetComponent<Rigidbody>().velocity.y * 10f + 20f;
		}
		Quaternion R = Quaternion.Euler (lookDirection);
		imageBird.transform.rotation = Quaternion.RotateTowards (imageBird.transform.rotation, R, 5f);

	}
	void OnTriggerEnter(Collider Target){
		if (Target.tag == "Cactus") {
			GetComponent<Rigidbody>().velocity = new Vector3 (0, -3, 0);
			lookDirection = new Vector3(0, 0, -90);
			GameManager.manager.GameOver();
		}
		else if (Target.tag == "Goal"){
			GameManager.manager.GetScore();
		}
	}


}
