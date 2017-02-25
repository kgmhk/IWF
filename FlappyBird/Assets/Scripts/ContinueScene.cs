using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScene : MonoBehaviour {

    void OnMouseDown()
    {
        print("button click : ");
        GameManager.manager.continueGame = true;
        GameManager.manager.end = false;
    }
}
