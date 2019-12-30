using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour {
    int d;
	// Use this for initialization
	void Start () {
        d = 0;
	}
	
	// Update is called once per frame
	void Update () {
        d++;
        if(d == 15)
        {
            Destroy(this.gameObject);
        }
    }
}
