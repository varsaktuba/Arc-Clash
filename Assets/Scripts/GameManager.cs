using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI, gamewinUI, startUI;
    [SerializeField] TextMeshProUGUI scoreText;
    public static int scoreValue;

    public GameObject canon;
    public GameObject cursor;
   

    void Start()
    {
        PlayerPrefs.SetInt("CURRENTSCENE", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        scoreValue = 0;

    }
    void Update()
    {
        if (BossHealth.instance.isDead)
        {
           
            canon.SetActive(true);
            cursor.SetActive(true);
           

        }
    }

    public void ScoreText(int value)
    {
        scoreValue += value;
        scoreText.text = "Total Score: " + scoreValue;
    }
    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }


    public void WinGame()
    {

        gamewinUI.SetActive(true);

    }

    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");

    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
