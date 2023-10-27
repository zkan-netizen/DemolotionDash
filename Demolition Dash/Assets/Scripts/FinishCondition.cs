using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class FinishCondition : MonoBehaviour
{
    #region  Deviation Part
    [Header("Deviation Settings")]
    public Vector3 Pose1;
    public Vector3 Pose2;

    #endregion
    //----------------------------------------
    #region Rotate Part
    [Header("Rotate Settings")]
    public GameObject SecondCamera;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private Vector3 RotateDirection;
    public bool CanFinish = false;
    #endregion

    void Rotater()
    {
        if (CanFinish == true)
        {
            // RotateDirection = new Vector3(transform.position.x, 5);
            transform.Rotate(RotateDirection * RotateSpeed * Time.deltaTime);
            // SecondCamera.gameObject.SetActive(true);
            // Character rotate and finish condition .
        }


    }
    void DeviationSpin()
    {
        
        transform.position =
               Vector3
                   .Lerp(Pose1,
                   Pose2,
                   (Mathf.Sin(1 * Time.time) + 1.0f) / 2.0f);
    }
    private void Update()
    {
        DeviationSpin();
        Rotater();

    }
}
