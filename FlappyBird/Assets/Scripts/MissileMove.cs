using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour {

    public float missileSpeed;

    void Update()
    {
        transform.Translate(Vector3.left * missileSpeed * Time.deltaTime);

        if (this.transform.position.x < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnEnable()
    {
        this.transform.position = new Vector3(6f, Random.Range(-1, 1.5f), 0);
    }
}
