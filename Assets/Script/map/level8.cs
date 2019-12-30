using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level8 : MonoBehaviour {
    public GameObject zombie;
    public GameObject player;
    public GameObject bomb;
    private Rigidbody2D myBody;
    private Rigidbody2D myBody1;
    private Rigidbody2D myBody2;
    Vector3 mousePos1;
    Vector3 mousePos2;
    public static level8 instance;
    public GameObject panelEW;
    public GameObject panelEL;
    bool left;
    bool right;
    int d;
    public GameObject lv;
    public List<GameObject> lv8;
    int dem;
    int move;
    bool change;
    bool win;
    public GameObject tut;
    public static bool first = false;
    int demT = 0;
    int demT2 = 0;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("tut3") == 0)
        {
            tut.SetActive(true);
            PlayerPrefs.SetInt("tut3", 1);
        }
        win = false;
        change = false;
        move = 0;
        myBody = zombie.GetComponent<Rigidbody2D>();
        myBody1 = player.GetComponent<Rigidbody2D>();
        myBody2 = bomb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (tut.active == false)
        {
            if (demT < 20)
            {
                demT++;
            }
        }
        if (GameControler.instance.panelRate.active == false)
        {
            if (demT2 < 20)
            {
                demT2++;
            }
        }
        if (Time.timeScale != 0 && win == false && tut.active == false && GameControler.instance.panelRate.active == false && demT == 20 && demT2 == 20)
        {
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
                    bomb.transform.Rotate(new Vector3(0, 0, 90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                    myBody2.velocity = new Vector2(0, -2f);
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
                    bomb.transform.Rotate(new Vector3(0, 0, -90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                    myBody2.velocity = new Vector2(0, -2f);
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
                    mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    {
                        if (myBody.velocity.y == 0 && myBody1.velocity.y == 0 )
                        {
                            if (mousePos1.y < 0)
                            {
                                if (mousePos2.x < mousePos1.x - 0.3f)
                                {
                                    _left();
                                }
                                else if (mousePos2.x - 0.3f > mousePos1.x)
                                {
                                    _right();
                                }
                            }
                            else
                            {
                                if (mousePos2.x < mousePos1.x - 0.3f)
                                {
                                    _right();
                                }
                                else if (mousePos2.x - 0.3f > mousePos1.x)
                                {
                                    _left();
                                }
                            }
                        }
                           
                    }
                }
            }
            _check();
            if(change == false)
            {
                if (player.GetComponent<playerController>().isChange == true)
                {
                    GameObject zb = Instantiate(zombie, player.transform.position, Quaternion.identity);
                    player = zb;
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
    }

    void _check()
    {
        for (int i = 0; i < 2; i++)
        {
            if (lv8[i].gameObject.tag == "zombie") dem++;
        }
        if (dem == 2)
        {
            GameControler.instance._delayEW();
            win = true;
        }
        else
        {
            dem = 0;
        }
    }
}
