
using UnityEngine;

public class CarHolderRotate : MonoBehaviour
{
    //  public GameObject CarShopManager;
    // void CheckCarShopUI()
    // {
    //     if (CarShopManager.activeSelf)
    //     {
    //         canRotate = true;
    //     }
    //     else
    //     {
    //         canRotate = false;
    //     }
    // }
    void RotateCars()
    {

        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);
            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, -screenTouch.deltaPosition.x / 10, 0f);
            }

        }
    }
    void Update()
    {
        RotateCars();
    }
}






