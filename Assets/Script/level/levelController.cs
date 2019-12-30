using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour {
    [System.Serializable]
    public class level
    {
        public string levelText;
        public int Unlocked;
        public bool isInteractable;
    }
    public static levelController instance;
    public List<level> lv;
    public Transform pa;
    public Button Button;
    public int levelplay;
    public AudioSource audio;
    public AudioClip click;
    public GameObject panelnoti;
    

    public void Start()
    {
        _getLevel();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        Time.timeScale = 1;
        //PlayerPrefs.DeleteAll();
        _MakeInstance();
        FillList();
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void FillList()
    {
        PlayerPrefs.SetInt("Level1", 1);
        foreach (var leve in lv)
        {
            Button newBT = Instantiate(Button) as Button;
            levelButton bt = newBT.GetComponent<levelButton>();
            bt.levelText.text = leve.levelText;
            //bt.transform.localScale = new Vector3(1, 1, 1);
            if (PlayerPrefs.GetInt("Level" + bt.levelText.text) == 1)
            {
                leve.Unlocked = 1;
                bt.GetComponent<Button>().onClick.AddListener(() => loadLevel(int.Parse(bt.levelText.text.ToString())));
            }
            else
            {
                bt.GetComponent<Button>().onClick.AddListener(() => loadLevel(int.Parse(bt.levelText.text.ToString())));
            }
            bt.unlocked = leve.Unlocked;
            //bt.GetComponent<Button>().interactable = leve.isInteractable;
            newBT.transform.SetParent(pa);
            newBT.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        SaveAll();
    }

    void SaveAll()
    {
        {
            GameObject[] allBT = GameObject.FindGameObjectsWithTag("lvBT");
            foreach (GameObject bts in allBT)
            {
                levelButton btn = bts.GetComponent<levelButton>();
                PlayerPrefs.SetInt("Level" + btn.levelText.text, btn.unlocked);
            }
        }
    }

    void loadLevel(int index)
    {
        if(PlayerPrefs.GetInt("Level" + index) == 1)
        {
            levelplay = index;
            SceneManager.LoadScene("Main");
        }
        else
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(click);
            }
            panelnoti.SetActive(true);
        }
    }

    public void _backI()
    {
        SceneManager.LoadScene("menu");
    }

    public void _back()
    {
        Invoke("_backI", 0f);
    }
   
    public void _ok()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        panelnoti.SetActive(false);
    }

    public void _getLevel()
    {
        int starPass, levelPass;
        starPass = levelPass = 0;
        for(int i = 1; i <= 30; i++)
        {
            if(PlayerPrefs.GetInt("Level" + i) == 1)
            {
                levelPass++;
                starPass += PlayerPrefs.GetInt("levelS" + i);
            }
            
        }
        Debug.Log(starPass);
        Debug.Log(levelPass-1);
    }


}
