using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public bool stop;
    private Rigidbody2D myBody;
    public static playerController instance;
    public Sprite monter;
    private Animator anim;
    public GameObject zombie;
    public bool isChange;
    private BoxCollider2D box;
    public AudioSource audio;
    public AudioClip fall;
    // Use this for initialization

    private void Awake()
    {
        myBody = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        box = this.gameObject.GetComponent<BoxCollider2D>();
    }

    void Start () {
        isChange = false;
        _MakeInstance();
        
        stop = true;
	}

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        _MakeInstance();
        if(isChange == true)
        {
            this.gameObject.tag = "zombie";
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "zombie")
        {
            myBody.velocity = new Vector2(0, 0);
            isChange = true;
        }
        if (other.gameObject.tag == "vc")
        {
            if(isChange == false)
            {
                if (myBody.velocity.y == 0)
                {
                    if (PlayerPrefs.GetInt("sound") == 1)
                    {
                        audio.PlayOneShot(fall);
                    }
                    anim.SetTrigger("down");
                }
                anim.SetTrigger("normal");
            }
        }
        if (other.gameObject.tag == "die")
        {
            other.gameObject.SetActive(false);
            anim.SetTrigger("die");
            box.isTrigger = true;
            myBody.gravityScale = 0.5f;
            myBody.velocity = new Vector2(0,7f);
            GameControler.instance._delayEL();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "die" || other.gameObject.tag == "boom") 
        {
            if(other.gameObject.tag == "die")
            {
                other.gameObject.SetActive(false);
            }
            anim.SetTrigger("die");
            box.isTrigger = true;
            myBody.gravityScale = 0.5f;
            myBody.velocity = new Vector2(0,7f);
            GameControler.instance._delayEL();
        }
    }
}
