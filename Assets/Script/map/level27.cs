using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level27 : MonoBehaviour {
    public GameObject zombie;
    public GameObject player;
    public GameObject barb1;
    public GameObject barb2;
    public GameObject brick1;
    public GameObject brick2;
    private Rigidbody2D myBody;
    private Rigidbody2D myBody1;
    private Rigidbody2D myBody2;
    private Rigidbody2D myBody3;
    private Rigidbody2D myBody4;
    private Rigidbody2D myBody5;
    bool left, right;
    int dem, d;
    public GameObject lv;
    public List<GameObject> lv27;
    Vector3 mousePos1;
    Vector3 mousePos2;
    int move;
    bool change;
    bool win;

    // Use this for initialization
    void Start () {
        move = 0;
        win = false;
        change = false;
        myBody = zombie.GetComponent<Rigidbody2D>();
        myBody1 = player.GetComponent<Rigidbody2D>();
        myBody2 = barb1.GetComponent<Rigidbody2D>();
        myBody3 = barb2.GetComponent<Rigidbody2D>();
        myBody4 = brick1.GetComponent<Rigidbody2D>();
        myBody5 = brick2.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale != 0 && win ==  false)
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
                    brick1.transform.Rotate(new Vector3(0, 0, 90));
                    brick2.transform.Rotate(new Vector3(0, 0, 90));
                    barb1.transform.Rotate(new Vector3(0, 0, 90));
                    barb2.transform.Rotate(new Vector3(0, 0, 90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                    myBody2.velocity = new Vector2(0, -2f);
                    myBody3.velocity = new Vector2(0, -2f);
                    myBody4.velocity = new Vector2(0, -2f);
                    myBody5.velocity = new Vector2(0, -2f);
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
                    brick1.transform.Rotate(new Vector3(0, 0, -90));
                    brick2.transform.Rotate(new Vector3(0, 0, -90));
                    barb1.transform.Rotate(new Vector3(0, 0, -90));
                    barb2.transform.Rotate(new Vector3(0, 0, -90));
                    myBody.velocity = new Vector2(0, -2f);
                    myBody1.velocity = new Vector2(0, -2f);
                    myBody2.velocity = new Vector2(0, -2f);
                    myBody3.velocity = new Vector2(0, -2f);
                    myBody4.velocity = new Vector2(0, -2f);
                    myBody5.velocity = new Vector2(0, -2f);
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
                        if (myBody.velocity.y == 0 && myBody1.velocity.y == 0  && myBody4.velocity.y == 0 && myBody5.velocity.y == 0)
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
            
            _check();
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
        for (int i = 0; i < 2; i++)
        {
            if (lv27[i].gameObject.tag == "zombie") dem++;
        }
        Debug.Log(dem);
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
