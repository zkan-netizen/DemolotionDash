using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameManager : MonoBehaviour
{
    #region Singleton Part
    public static GameManager Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {

            Destroy(gameObject);

        }
    }
    #endregion

    public GameObject MainMenu;
    public float CountDown = 2;
    public bool FinishMovie;
    public bool NextBool;
    public GameObject NextButton;
    public bool RestartBool;
    public GameObject RestartButton;
    public int LastSceneIndex { get; set; }
    public void GameStart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    void ResumeGame() { Time.timeScale = 0; }
    public void Next()
    {
        if (SceneManager.GetActiveScene().name == "FinishScene")
        {
            if (LastSceneIndex + 1 == SceneManager.GetSceneByName("FinishScene").buildIndex)
            {
                MainMenu.SetActive(true);
                SceneManager.LoadScene(sceneName: "MainMenuScene");

            }
            else
            {
                SceneManager.LoadScene(LastSceneIndex + 1);
            }

        }






    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        NextButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void MapFinished()
    {
        if (CountDown > 0 && FinishMovie == true)
        {
            CountDown -= Time.deltaTime;
        }
        if (CountDown <= 0)
        {
            CountDown = 2;
            NextBool = true;
            FinishMovie = false;
            SceneManager.LoadScene("FinishScene");

        }
    }
    void CallNextButton()
    {
        if (NextBool == true)
        {
            NextButton.gameObject.SetActive(true);
        }
        if (NextButton.activeSelf)
        {
            NextBool = false;
        }
    }
    //---------------------------------------------------------------------------------

    void CallRestartButton()
    {
        if (RestartBool == true)
        {
            RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (RestartButton.activeSelf)
        {

            RestartBool = false;
        }

    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        Debug.Log(LastSceneIndex);

        MapFinished();

        CallRestartButton();
        CallNextButton();
    }

}
public partial class GameManager
{
    #region  Graiphic Settings
    public void LowGraphic()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void MediumGraphic()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void HighGraphic()
    {
        QualitySettings.SetQualityLevel(5);
    }
    public void VeryHighGraphic()
    {
        QualitySettings.SetQualityLevel(6);
    }
    #endregion
}