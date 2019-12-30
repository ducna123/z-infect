using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    float z;
    int d;
    bool left;
    bool right;
    public GameObject player;
    public GameObject zombie;
    private Rigidbody2D myBody;
    private Rigidbody2D myBody1;
    Vector3 mousePos1;
    Vector3 mousePos2;
    public bool first = true;
    public static Map instance;
    public GameObject panelEW;
    public GameObject panelEL;
    public int time;
    public List<GameObject> lv1;
    public GameObject lv;
    int dem = 0;
    int move = 0;
    bool change;
    bool win;
    public GameObject tut;
    public GameObject tut2;
    static bool firstT = false;
    int demT = 0;

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.GetInt("tut1") == 0)
        {
            tut.SetActive(true);
            PlayerPrefs.SetInt("tut1", 1);
        }
        win = false;
        change = false;
        dem = 0;
        time = 1;
        move = 0;
        _MakeInstance();
        d = 0;
        myBody = zombie.GetComponent<Rigidbody2D>();
        myBody1 = player.GetComponent<Rigidbody2D>();
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void _check()
    {
        for(int i = 0;i < 2; i++)
        {
            if (lv1[i].gameObject.tag == "zombie")
            {
                dem++;
            }
        }
        if(dem == 2)
        {
            
            GameControler.instance._delayEW();
            win = true;
        }
        else
        {
            dem = 0;
        }
    }


    // Update is called once per frame
    void Update () {
        if (tut2.active == false && tut.active == false)
        {
            if (demT < 20)
            {
                demT++;
            }
        }
        if (Time.timeScale != 0 && win == false && tut.active == false && demT == 20 && tut2.active == false)
        {
            _check();
            if (left == true)
            {
                transform.Rotate(new Vector3(0, 0, -6f));
                d++;
                if (d == 15)
                {
                    left = false;
                    d = 0;
                    zombie.transform.Rotate(new Vector3(0, 0, 90));
                    player.transform.Rotate(new Vector3(0, 0, 90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                }
            }
            else if (right == true)
            {
                transform.Rotate(new Vector3(0, 0, 6f));
                d++;
                if (d == 15)
                {
                    right = false;
                    d = 0;
                    zombie.transform.Rotate(new Vector3(0, 0, -90));
                    player.transform.Rotate(new Vector3(0, 0, -90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                }
            }
            if (d == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mousePos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    if(myBody.velocity.y == 0 && myBody1.velocity.y == 0)
                    {
                        mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        first = false;
                        {
                            if (mousePos1.y < 0)
                            {
                                if (mousePos2.x < mousePos1.x-0.3f)
                                {
                                    _left();
                                }
                                else if (mousePos2.x- 0.3f > mousePos1.x)
                                {
                                    _right();
                                }
                            }
                            else
                            {
                                if (mousePos2.x < mousePos1.x- 0.3f)
                                {
                                    _right();
                                }
                                else if (mousePos2.x- 0.3f > mousePos1.x)
                                {
                                    _left();
                                }
                            }
                        }
                    }
                    
                }
            }
            if(change == false)
            {
                if (player.GetComponent<playerController>().isChange == true)
                {
                    GameObject zb = Instantiate(zombie, player.transform.position, Quaternion.identity);
                    player = zb;
                    lv1[1] = zb;
                    Transform pa = lv.transform;
                    zb.transform.SetParent(pa);
                    change = true;
                }
            }
        }
        
    }

    public void _left()
    {
        move++;
        GameControler.instance._setMove(move);
        GameControler.instance._nextMove();
        if (left == false)
        {
            left = true;
        }        
    }

    public void _right()
    {
        move++;
        GameControler.instance._setMove(move);
        GameControler.instance._nextMove();
        if (right == false)
        {
            right = true;
        }
    }

    public void ok()
    {
        tut.SetActive(false);
        tut2.SetActive(true);
    }

    public void ok2()
    {
        tut2.SetActive(false);
    }

}
