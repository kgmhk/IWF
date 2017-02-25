using UnityEngine;
using System.Collections;

public class ReplayScene : MonoBehaviour {

	void OnMouseDown(){
        print("replaybutton clock:");
        GameManager.manager.ready = true;
        GameManager.manager.end = false;
        Application.LoadLevel (0);
    }
}
