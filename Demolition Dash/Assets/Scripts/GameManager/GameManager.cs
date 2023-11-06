using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public partial class GameManager : MonoBehaviour
{

    public bool GameStarted { get; set; } = false;
    // void IsActiveMainMenu()
    // {
    //     if (MainMenu.activeSelf == true)
    //     {
    //         GameStarted = false;
    //     }
    // }
    // [SerializeField] PlayerMove playerMove;
    public void GameStart()
    {
        // StartPose();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameStarted = true;


    }
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
        Load();
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


    // void ResumeGame() { Time.timeScale = 0; }
    public void Next()
    {
        if (SceneManager.GetActiveScene().name == "FinishScene")
        {
            GameStarted = false;

            if (LastSceneIndex + 1 == SceneManager.GetSceneByName("FinishScene").buildIndex)
            {
                MainMenu.SetActive(true);
                SceneManager.LoadScene(sceneName: "MainMenuScene");
                GameStarted = false;

            }
            else
            {
                SceneManager.LoadScene(LastSceneIndex + 1);
                // StartPose();
                GameStarted = true;

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
            //Finish Ekranında currentcar playermove ve player side kapatsın ardından spin atan scripti aktif etisn.nexte basılınca tam tersi olsun.
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
    private void OnApplicationQuit()
    {
        Save();
        // Uygulama kapatıldığında yapılması gereken işlemleri burada gerçekleştirin
        // Örneğin, oyun durumunu kaydetmek veya temizlik yapmak için kullanabilirsiniz.
    }
    public void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();

        }
        OnApplicationQuit();
        MapFinished();
        // IsActiveMainMenu();
        CallRestartButton();
        CallNextButton();



    }

}
public partial class GameManager //Shop Manager
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


    // public TextMeshProUGUI text;
    #region ShopManager Part



    //What we want to save
    public int currentCar;
    public int money;

    public bool[] carsUnlocked = Enumerable.Repeat(false, 20).ToArray();
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage Shopdata = (PlayerData_Storage)binaryFormatter.Deserialize(file);
            (currentCar, money, carsUnlocked) = (Shopdata.currentCar, Shopdata.money, Shopdata.carsUnlocked);
            if (Shopdata.carsUnlocked == null)
            {
                Shopdata.carsUnlocked = new bool[20] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

                // Shopdata.carsUnlocked = Enumerable.Repeat(false, 20).ToArray();
                // Shopdata.carsUnlocked[0] = true;
            }
            file.Close();

        }


    }
    public void ResetGame()
    {
        GameManager.Instance.carsUnlocked = new bool[20] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        // carsUnlocked = Enumerable.Repeat(false, 20).ToArray();
        Debug.Log("Oyun resetlendi");
        // Oyuncunun sahip olduğu arabaları ve diğer verileri sıfırla
        currentCar = 0;
        carsUnlocked[0] = true;
        money = 0; // Varsayılan para miktarı

        // Diğer verileri sıfırla (örneğin, başarılar veya puanlar)
        // Save işlemini çağırarak bu sıfırlanan verileri kaydet
        Save();
    }
    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage Shopdata = new()
        {
            currentCar = currentCar,
            money = money,
            carsUnlocked = carsUnlocked
        };



        binaryFormatter.Serialize(file, Shopdata);
        file.Close();

    }
    #endregion


}

[Serializable]
class PlayerData_Storage
{
    public int currentCar;
    public int money;
    public bool[] carsUnlocked;
}