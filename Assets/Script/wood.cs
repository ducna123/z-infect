using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour {
    private Animator amin;
    bool boooom;
    int time;
	// Use this for initialization
	void Start () {
        time = 0;
        boooom = false;
        amin = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(boooom == true)
        {
            time++;
        }
        if(time == 40)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "boom")
        {
            if (bomb.instance.isPut == true)
            {
                boooom = true;
                amin.SetTrigger("boom");
                //this.gameObject.SetActive(false);
                //other.gameObject.SetActive(false);
            }
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "boom")
        {
            Debug.Log("boom");
            if (bomb.instance.isPut == true)
            {
                this.gameObject.SetActive(false);
                //other.gameObject.SetActive(false);
            }
        }
    }
    */

}
