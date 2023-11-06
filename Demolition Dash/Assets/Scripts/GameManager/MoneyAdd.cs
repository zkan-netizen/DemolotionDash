using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAdd : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.money += 100;
            GameManager.Instance.Save();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager.Instance.money -= 100;
            GameManager.Instance.Save();
        }

       
    }
}
