using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monterController : MonoBehaviour {
    private Animator anim;
    private Rigidbody2D myBody;
    private int d;
    private BoxCollider2D box;
    public static monterController instance;
    // Use this for initialization
    public GameObject zombie;
    public bool isChange;
    public AudioSource audio;
    public AudioClip eat, fall;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        isChange = false;
        d = 0;
        _MakeInstance();
        
    }


    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            d++;
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(eat);
            }
            if (myBody.velocity.y == 0)
            {
                //Debug.Log("as");
                
                anim.SetTrigger("eat");
            }
            anim.SetTrigger("normal1");
            other.gameObject.tag = "zombie";
            other.gameObject.SetActive(false);
            isChange = true;
        }
        if (other.gameObject.tag == "vc")
        {
            if(myBody.velocity.y == 0)
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                {
                    audio.PlayOneShot(fall);
                }
                anim.SetTrigger("down");
            }
            anim.SetTrigger("normal");
        }
        if (other.gameObject.tag == "die")
        {
            other.gameObject.SetActive(false);
            anim.SetTrigger("die");
            box.isTrigger = true;
            myBody.gravityScale = 0.5f;
            myBody.velocity = new Vector2(0, 7f);
            GameControler.instance._delayEL();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "die" || other.gameObject.tag == "boom")
        {
            if (other.gameObject.tag == "die")
            {
                other.gameObject.SetActive(false);
            }
            box.isTrigger = true;
            anim.SetTrigger("die");
            myBody.gravityScale = 0.5f;
            myBody.velocity = new Vector2(0, 7f);
            GameControler.instance._delayEL();
        }
    }
}
