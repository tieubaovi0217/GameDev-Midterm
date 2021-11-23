using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject mainTab;
    public GameObject tutorialTab;
    public GameObject optionsTab;
    private GameObject thisTab;
    public GameObject highScore;
    // Start is called before the first frame update
    void Start()
    {
        thisTab = mainTab;
        mainTab.SetActive(true);
        optionsTab.SetActive(false);
        tutorialTab.SetActive(false);
        highScore.GetComponent<TextMeshProUGUI>().text = ((int)PlayerPrefs.GetInt("HighScore", 0)).ToString();
    }

    public void changeTab(string tabName)
    {
        thisTab.SetActive(false);
        switch (tabName.ToLower()) {
            case "maintab":
                thisTab = mainTab;
                break;                
            case "optionstab":
                thisTab = optionsTab;
                break;
            case "tutorialtab":
                thisTab = tutorialTab;
                break;
        }
        thisTab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame ()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
