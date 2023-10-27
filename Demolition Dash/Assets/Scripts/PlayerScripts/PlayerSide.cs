using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSide : MonoBehaviour
{
    public float Sidespeed;

    private int RoadState { get; set; } = 0;

    [SerializeField]
    private bool Left;

    [SerializeField]
    private bool Right;

    // void Moveright()
    // {
    //     if (state < 1) state++;
    // }

    // void Moveleft()
    // {
    //     if (state > -1) state--;
    // }

    public void DragLeftRight()
    {
        if (Input.touchCount > 0)
        {
            Touch touched = Input.GetTouch(0);

            if (touched.deltaPosition.x > 30.0f)
            {
                Right = true;
                Left = false;
            }
            if (touched.deltaPosition.x < -30.0f)
            {
                Right = false;
                Left = true;
            }
            //------------------------------------------
            if (Right == true)
            {
                if (RoadState < 1) RoadState++;
            }
            if (Left == true)
            {
                if (RoadState > -1) RoadState--;
            }
            //-------------------------------------------
            Vector3 z =
                new Vector3(transform.position.x,
                    transform.position.y,
                 RoadState * 1.5f);

            //-------------------------------------------
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    z,
                    Sidespeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        DragLeftRight();
    }
}

