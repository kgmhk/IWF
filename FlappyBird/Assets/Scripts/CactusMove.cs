using UnityEngine;
using System.Collections;

public class CactusMove : MonoBehaviour {

	public float cactusSpeed;

	void Update () {
		transform.Translate (Vector3.left * cactusSpeed * Time.deltaTime);

		if (this.transform.position.x < -6f){
			Destroy(this.gameObject);
		}
	}

	void OnEnable (){
		this.transform.position = new Vector3 (6f, Random.Range (-1, 1.5f), 0);
	}
}
