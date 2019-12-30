using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {
    public AudioSource audio;
    public AudioClip click,nen;
    public static button instance;
    public Button sound;
    public Button music;
    public GameObject panelSetting;

    private void Start()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            sound.image.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                sound.image.color = new Color(1, 1, 1, 0.5f);
            }
        }
        if (PlayerPrefs.GetInt("music") == 1)
        {
            audio.Play();
            music.image.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                audio.Stop();
                music.image.color = new Color(1, 1, 1, 0.5f);
            }
        }
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        _MakeSingleInstance();
        _FirstTime();
    }

    public void _startI()
    {
        SceneManager.LoadScene("level");
    }


    public void _start()
    {
        Invoke("_startI",0.1f);
    }  

    public void _sound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        if(PlayerPrefs.GetInt("sound") == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            sound.image.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                PlayerPrefs.SetInt("sound", 1);
                sound.image.color = new Color(1, 1, 1, 1f);
            }
        }

    }

    public void _music()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        if (PlayerPrefs.GetInt("music") == 1)
        {
            audio.Stop();
            PlayerPrefs.SetInt("music", 0);
            music.image.color = new Color(1, 1, 1, 0.5f);
        }
        else if (PlayerPrefs.GetInt("music") == 0)
        {
            audio.Play();

            PlayerPrefs.SetInt("music", 1);
            music.image.color = new Color(1, 1, 1, 1f);
        }
    }

    public void _Setting()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        panelSetting.SetActive(true);
    }

    public void _OUT()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        panelSetting.SetActive(false);
    }

    void _MakeSingleInstance()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    void _FirstTime()
    {
        if (!PlayerPrefs.HasKey("_FirstTime"))
        {
            
            PlayerPrefs.SetInt("tut1", 0);
            PlayerPrefs.SetInt("tut2", 0);
            PlayerPrefs.SetInt("tut3", 0);
            PlayerPrefs.SetInt("tut4", 0);
            PlayerPrefs.SetInt("rate", 0);
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.SetInt("music", 1);
            PlayerPrefs.SetInt("_FirstTime", 0);
        }
    }

}
