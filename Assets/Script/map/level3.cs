using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3 : MonoBehaviour {

    float z;
    int d;
    bool left;
    bool right;
    public GameObject player1;
    public GameObject player2;
    public GameObject zombie;
    private Rigidbody2D myBody;
    private Rigidbody2D myBody1;
    private Rigidbody2D myBody2;
    Vector3 mousePos1;
    Vector3 mousePos2;
    public static bool first = false;
    public static level3 instance;
    public GameObject panelEW;
    public GameObject panelEL;
    public List<GameObject> lv3;
    public GameObject lv;
    int dem = 0;
    int move;
    bool change1, change2;
    bool win;
    public GameObject tut;
    int demT = 0;


    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("tut2") == 0)
        {
            tut.SetActive(true);
            PlayerPrefs.SetInt("tut2", 1);
        }
        win = false;
        change1 = change2 = false;
        move = 0;
        _MakeInstance();
        d = 0;
        myBody = zombie.GetComponent<Rigidbody2D>();
        myBody1 = player1.GetComponent<Rigidbody2D>();
        myBody2 = player2.GetComponent<Rigidbody2D>();
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ok()
    {
        tut.SetActive(false);
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

    void _check()
    {
        for (int i = 0; i < 3; i++)
        {
            if (lv3[i].gameObject.tag == "zombie") dem++;
        }
        if (dem == 3)
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
    void Update()
    {
        if (tut.active == false)
        {
            if (demT < 20)
            {
                demT++;
            }
        }
        if (Time.timeScale != 0 && win == false && tut.active == false && demT == 20)
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
                    player1.transform.Rotate(new Vector3(0, 0, 90));
                    player2.transform.Rotate(new Vector3(0, 0, 90));
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
                    player1.transform.Rotate(new Vector3(0, 0, -90));
                    player2.transform.Rotate(new Vector3(0, 0, -90));
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
                    first = false;     
                    {
                        if(myBody.velocity.y == 0 && myBody1.velocity.y == 0 && myBody2.velocity.y == 0)
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
            if (change1 == false)
            {
                if (player1.GetComponent<playerController>().isChange == true)
                {
                    GameObject zb = Instantiate(zombie, player1.transform.position, Quaternion.identity);
                    player1 = zb;
                    Transform pa = lv.transform;
                    zb.transform.SetParent(pa);
                    zombie.GetComponent<monterController>().isChange = false;
                    change1 = true;
                }
            }
            if (change2 == false)
            {
                if (player2.GetComponent<playerController>().isChange == true)
                {
                    GameObject zb = Instantiate(zombie, player2.transform.position, Quaternion.identity);
                    player2 = zb;
                    Transform pa = lv.transform;
                    zb.transform.SetParent(pa);
                    zombie.GetComponent<monterController>().isChange = false;
                    change2 = true;
                }
            }
            if (player1.gameObject.tag == "zombie")
            {
                if (change2 == false)
                {
                    if (player2.GetComponent<playerController>().isChange == true)
                    {
                        Debug.Log("zo");
                        GameObject zb = Instantiate(zombie, player2.transform.position, Quaternion.identity);
                        player2 = zb;
                        Transform pa = lv.transform;
                        zb.transform.SetParent(pa);
                        change2 = true;
                    }
                }

            }
            if (player2.gameObject.tag == "zombie")
            {
                if (change1 == false)
                {
                    if (player1.GetComponent<playerController>().isChange == true)
                    {
                        Debug.Log("zo");
                        GameObject zb = Instantiate(zombie, player1.transform.position, Quaternion.identity);
                        player1 = zb;
                        Transform pa = lv.transform;
                        zb.transform.SetParent(pa);
                        change1 = true;
                    }
                }

            }
        }

    }

    }


