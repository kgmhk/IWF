using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : MonoBehaviour {

	void OnMouseDown()
    {
        GameManager.manager.ready = true;
    }
}
