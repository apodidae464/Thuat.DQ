using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string sceneName;
    public Text text;
    public GameObject endGameMenu;
    public Text topPoint;
    public Text score;
    int point = 0;
    int highestPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        highestPoint = PlayerPrefs.GetInt("Hightest_point");
        topPoint.text = "Top point: " + highestPoint;
        endGameMenu.SetActive(false);
        point = 0;
        AudioMgr.instance.PlayBMG2();

        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + point;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void StartGame()
    {
        AudioMgr.instance.playSfx(AudioMgr.MUSIC.BUTTON_CLICK);
        SceneManager.LoadScene(sceneName);
        AudioMgr.instance.PlayBMG();
    }


    public void Restart()
    {
        AudioMgr.instance.playSfx(AudioMgr.MUSIC.BUTTON_CLICK);

        if (point > highestPoint)
        {
            PlayerPrefs.SetInt("Hightest_point", point);
        }
        SceneManager.LoadScene(sceneName);
        AudioMgr.instance.PlayBMG();
    }

    public void Quit()
    {
        if (point > highestPoint)
        {
            PlayerPrefs.SetInt("Hightest_point", point);
        }
        Application.Quit();
    }
    public void OpenRestartMenu()
    {
        score.text = "" + point;
        endGameMenu.SetActive(true);
    }

    public void addPoint()
    {
        point++;
    }
}
