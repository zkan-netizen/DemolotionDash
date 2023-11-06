using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CarSelection : MonoBehaviour
{
    #region Singleton Part
    public static CarSelection Instance;

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

    [Header("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] public TextMeshProUGUI priceText;
    [Header("Car Attributes")]
    [SerializeField] private int[] carPrices;
    [SerializeField] private int currentCar;
    public bool CallSelector;

    private void Start()
    {


        currentCar = GameManager.Instance.currentCar;
        SelectCar(currentCar);

    }
    public void CarSelector()
    {

        if (GameManager.Instance.carsUnlocked[currentCar] == false)
        {
            currentCar = 0;
            // Araba kilidi kapalıysa ilk araca geri dön
        }

    }

    private void UpdateUI()
    {
        if (GameManager.Instance.carsUnlocked[currentCar])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = carPrices[currentCar] + "$";
            // Check if we have enough money
        }
    }
 public void MakeUsuablePlayButton()
    {
        if (buy.gameObject.activeInHierarchy)
        {
            buy.interactable = GameManager.Instance.money >= carPrices[currentCar];
        }
    }


    void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);

        }
        UpdateUI();
    }
    public void ChangeCar(int _change)
    {
        currentCar += _change;
        if (currentCar > transform.childCount - 1)
        {
            currentCar = 0;

        }

        else if (currentCar < 0)
        {
            currentCar = transform.childCount - 1;

        }

        GameManager.Instance.currentCar = currentCar;
        GameManager.Instance.Save();
        SelectCar(currentCar);
    }
    public void BuyCar()
    {
        GameManager.Instance.money -= carPrices[currentCar];
        GameManager.Instance.carsUnlocked[currentCar] = true;
        GameManager.Instance.Save();
        UpdateUI();
    }


    private void Update()
    {
      MakeUsuablePlayButton();
    }
}
