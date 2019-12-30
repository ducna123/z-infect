using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelButton : MonoBehaviour {
    int d = 0;
    public Text levelText;
    public int unlocked;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private void Start()
    {

        int x = int.Parse(levelText.text.ToString());
            if (PlayerPrefs.GetInt("levelS" + x) == 3)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("levelS" + x) == 2)
            {
                star1.SetActive(true);
                star3.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("levelS" + x) == 1)
            {
                star1.SetActive(true);
            }
     
    }

}
