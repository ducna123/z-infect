﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level10 : MonoBehaviour {
    public GameObject zombie;
    public GameObject player1;
    public GameObject player2;
    public GameObject brick1;
    public GameObject brick2;
    public GameObject brick3;
    public GameObject brick4;
    public GameObject bomb1;
    public GameObject bomb2;
    private Rigidbody2D myBody;
    private Rigidbody2D myBody1;
    private Rigidbody2D myBody2;
    private Rigidbody2D myBody3;
    private Rigidbody2D myBody4;
    private Rigidbody2D myBody5;
    private Rigidbody2D myBody6;
    private Rigidbody2D myBody7;
    private Rigidbody2D myBody8;
    bool left, right;
    int dem, d;
    public GameObject lv;
    public List<GameObject> lv10;
    Vector3 mousePos1;
    Vector3 mousePos2;
    bool change1, change2;
    int move;
    bool win;
    // Use this for initialization
    void Start () {
        win = false;
        move = 0;
        myBody = zombie.GetComponent<Rigidbody2D>();
        myBody1 = player1.GetComponent<Rigidbody2D>();
        myBody2 = player2.GetComponent<Rigidbody2D>();
        myBody3 = brick1.GetComponent<Rigidbody2D>();
        myBody4 = brick2.GetComponent<Rigidbody2D>();
        myBody5 = bomb1.GetComponent<Rigidbody2D>();
        myBody6 = bomb2.GetComponent<Rigidbody2D>();
        myBody7 = brick3.GetComponent<Rigidbody2D>();
        myBody8 = brick4.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale != 0 && win == false)
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
                    player1.transform.Rotate(new Vector3(0, 0, 90));
                    player2.transform.Rotate(new Vector3(0, 0, 90));
                    bomb1.transform.Rotate(new Vector3(0, 0, 90));
                    bomb2.transform.Rotate(new Vector3(0, 0, 90));
                    brick1.transform.Rotate(new Vector3(0, 0, 90));
                    brick2.transform.Rotate(new Vector3(0, 0, 90));
                    brick3.transform.Rotate(new Vector3(0, 0, 90));
                    brick4.transform.Rotate(new Vector3(0, 0, 90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                    myBody2.velocity = new Vector2(0, -2f);
                    myBody3.velocity = new Vector2(0, -2f);
                    myBody4.velocity = new Vector2(0, -2f);
                    myBody7.velocity = new Vector2(0, -2f);
                    myBody8.velocity = new Vector2(0, -2f);
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
                    bomb1.transform.Rotate(new Vector3(0, 0, -90));
                    bomb2.transform.Rotate(new Vector3(0, 0, -90));
                    brick1.transform.Rotate(new Vector3(0, 0, -90));
                    brick2.transform.Rotate(new Vector3(0, 0, -90));
                    brick3.transform.Rotate(new Vector3(0, 0, -90));
                    brick4.transform.Rotate(new Vector3(0, 0, -90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                    myBody2.velocity = new Vector2(0, -2f);
                    myBody3.velocity = new Vector2(0, -2f);
                    myBody4.velocity = new Vector2(0, -2f);
                    myBody7.velocity = new Vector2(0, -2f);
                    myBody8.velocity = new Vector2(0, -2f);
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
                        if (myBody.velocity.y == 0 && myBody1.velocity.y == 0 && myBody2.velocity.y == 0 && myBody3.velocity.y == 0 && myBody4.velocity.y == 0  && myBody7.velocity.y == 0 && myBody8.velocity.y == 0)
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
                if(change2 == false)
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
                if(change1 == false)
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
            if (lv10[i].gameObject.tag == "zombie") dem++;
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

}
