using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    [System.Serializable]
    public class levelMove
    {
        public int move2;
        public int move3;
    }

    public List<levelMove> lvMove;

    public List<GameObject> lv;
    public GameObject panelEW;
    public GameObject panelEL;
    public GameObject panelP;
    public static GameControler instance;
    public Text move;
    public Text move2;
    public Text move3;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject move222;
    public Text lvT;
    public AudioSource audio;
    public AudioClip click, star, moveSound, lose, win;
    public GameObject image;
    float x;
    float xx;
    private Animator anim;
    private Animator anim1;
    public GameObject winP;
    public GameObject loseP;
    public GameObject panelRate;
    public GameObject panelThank;

    // Use this for initialization
    void Start()
    {
        if(levelController.instance.levelplay == 7 || levelController.instance.levelplay == 13 || levelController.instance.levelplay == 20 || levelController.instance.levelplay == 25 || levelController.instance.levelplay == 30)
        {
            if (PlayerPrefs.GetInt("rate") == 0)
            {
                panelRate.SetActive(true);
            }
        }  
        anim = winP.GetComponent<Animator>();
        anim1 = loseP.GetComponent<Animator>();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        x = 0;
        image.transform.localScale = new Vector3(x, 1, 1);
        move.text = "0";
        Time.timeScale = 1;
        _MakeInstance();
        lvT.text = "Level\n" + levelController.instance.levelplay;
        _setMove23(lvMove[levelController.instance.levelplay - 1].move2, lvMove[levelController.instance.levelplay - 1].move3);
        lv[levelController.instance.levelplay - 1].SetActive(true);
        xx = 155 / lvMove[levelController.instance.levelplay - 1].move3;
        float xxx = (517 / lvMove[levelController.instance.levelplay - 1].move3) * lvMove[levelController.instance.levelplay - 1].move2;
        move222.transform.localPosition = new Vector3(-208f + xxx , move222.transform.localPosition.y, move222.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _rateNow()
    {
        PlayerPrefs.SetInt("rate", 1);
        panelRate.SetActive(false);
        panelThank.SetActive(true);
    }

    public void _later()
    {
        panelRate.SetActive(false);
    }

    public void _keep()
    {
        panelThank.SetActive(false);
    }

    public void _nextMove()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(moveSound);
        }
        if (image.transform.localScale.x < 150)
        {
            x += xx;
            image.transform.localScale = new Vector3(x, 1, 1);
            
        }
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void nextI()
    {
        int x = levelController.instance.levelplay + 1;
        PlayerPrefs.SetInt("Level" + x, 1);
        levelController.instance.levelplay = x;
        SceneManager.LoadScene("Main");
    }

    public void _next()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        anim.SetTrigger("out");
        Invoke("nextI", 1f);
    }

    public void replayI()
    {
        SceneManager.LoadScene("Main");
    }


    public void _replay()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        if (panelEW.active == true)
        {
            anim.SetTrigger("out3");
        }
        else if(panelEL.active == true)
        {
            Debug.Log("lose");
            anim1.SetTrigger("out3");
        }
        Invoke("replayI", 0.7f);
    }

    public void _backI()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level");
    }

    public void backWI()
    {
        int x = levelController.instance.levelplay + 1;
        PlayerPrefs.SetInt("Level" + x, 1);
        Time.timeScale = 1;
        _backI();
    }

    public void backW()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        anim.SetTrigger("out2");
        Invoke("backWI", 1f);
    }

    public void backLI()
    {
        Time.timeScale = 1;
        _backI();
    }

    public void back()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        anim1.SetTrigger("out2");
        Invoke("backLI", 1);
    }

    public void _endGL()
    {
        if(PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(lose);
        }
        panelEL.SetActive(true);
        
    }

    void _star1()
    {
        
        star1.SetActive(true);
    }

    void _star2()
    {
        star2.SetActive(true);
    }

    void _star3()
    {
        star3.SetActive(true);
    }

    public void _endGW()
    {
        int x = levelController.instance.levelplay;
        int x1 = levelController.instance.levelplay + 1;
        PlayerPrefs.SetInt("Level" + x1, 1);
        int star1 = PlayerPrefs.GetInt("levelS" + x);
        panelEW.SetActive(true);
        int moveE = int.Parse(move.text);
        int moveE2 = int.Parse(move2.text);
        int moveE3 = int.Parse(move3.text);
        if (moveE < moveE2)
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(star);
            }
            PlayerPrefs.SetInt("levelS" + x, 3);
            Invoke("_star3", 1f);
            Invoke("_star1",1.5f);
            Invoke("_star2", 2f);
        }
        else if(moveE >= moveE2 && moveE < moveE3)
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(star);
            }
            PlayerPrefs.SetInt("levelS" + x, 2);
            Invoke("_star3", 1f);
            Invoke("_star1", 1.5f);
        }
        else if(moveE >= moveE3)
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(star);
            }
            PlayerPrefs.SetInt("levelS" + x, 1);
            Invoke("_star3", 1f);
        }
        if(star1 > PlayerPrefs.GetInt("levelS" + x))
        {
            PlayerPrefs.SetInt("levelS" + x, star1);
        }
    }

    public void _end()
    {
        Time.timeScale = 0;
    }

    public void _delayEW()
    {
        Invoke("_endGW", 0.5f);
        //Invoke("_end", 8f);
    }

    public void _delayEL()
    {
        Invoke("_endGL", 0.5f);
        //Invoke("_end", 5f);
    }

    public void _pause()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        Time.timeScale = 0;
        panelP.SetActive(true);
    }

    public void _continue()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        Invoke("_time", 0.001f);
        panelP.SetActive(false);
        
    }

    public void _time()
    {
        Time.timeScale = 1;
    }

    public void _menuI()
    {
        SceneManager.LoadScene("level");
    }

    public void _menu()
    {
        Time.timeScale = 1;

        _menuI();
    }

    public void _setMove(int mo)
    {
        move.text = "" + mo;
    }

    public void _setMove23(int mo2,int mo3)
    {
        move2.text = "" + mo2;
        move3.text = "" + mo3;
    }
}
