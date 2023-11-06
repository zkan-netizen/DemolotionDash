using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MoneyCounter : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private void Awake()
    {
        moneyText = GetComponent<TextMeshProUGUI>();

    }
    private void Update()
    {
        moneyText.text = GameManager.Instance.money + "$";
    }

}
