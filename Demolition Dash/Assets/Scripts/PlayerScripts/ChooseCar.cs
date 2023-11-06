using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    public GameObject[] Choosen;
    private void Start()
    {

    }
    private void Update()
    {
       
        if (GameManager.Instance.carsUnlocked[GameManager.Instance.currentCar] == true)
        {
            Choosen[GameManager.Instance.currentCar].gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.carsUnlocked[0] = true;
            Choosen[0].gameObject.SetActive(true);
        }

    }
}
