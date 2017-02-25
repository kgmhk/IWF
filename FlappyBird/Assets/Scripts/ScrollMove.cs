using UnityEngine;
using System.Collections;

public class ScrollMove : MonoBehaviour {

	public float scrollSpeed;
	float targetOffset;

	void Update () {
		targetOffset += Time.deltaTime * scrollSpeed;
		this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (-targetOffset, 0);
	}
}
