using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
    public static bomb instance;
    public bool isPut;
    public GameObject boom;
    private Animator anim;
    private BoxCollider2D box;
    private Rigidbody2D rigi;
    int d;
    public AudioSource audio;
    public AudioClip boooom;

    // Use this for initialization
    void Start () {
        _MakeInstance();
        d = 0;
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
        if (isPut == true)
        {
            d++;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(worldPoint, new Vector3(0,0,1) * 100, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, new Vector3(0,0,1),10) ;
            if (hit.collider!=null &&hit.collider.gameObject.tag == "bomb")
            {
                if(PlayerPrefs.GetInt("sound") == 1)
                {
                    audio.PlayOneShot(boooom);
                }
                anim = hit.collider.gameObject.GetComponent<Animator>();
                box = hit.collider.gameObject.GetComponent<BoxCollider2D>();
                rigi = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                isPut = true;
                Vector3 target = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, hit.collider.gameObject.transform.position.z);
                GameObject bom = Instantiate(boom, target, Quaternion.identity);
                anim.SetTrigger("booom");
                box.isTrigger = true;
                rigi.gravityScale = 0;
                
            }

        }
    }

}
