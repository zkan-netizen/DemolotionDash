using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CarHit : MonoBehaviour
{


    [SerializeField] private ParticleSystem ShatterObject;
    [SerializeField] private GameObject SpeedEffect;
    private float GateValue { get; set; }
    [SerializeField] PlayerMove playerMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate") && other.GetComponent<GateSpeed>() != null)
        {

            GateValue = other.GetComponent<GateSpeed>().Gate / 4;
            ShatterEffectConidition(other);
            playerMove.CarSpeed += GateValue;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            GameManager.Instance.FinishMovie = true;
            playerMove.CarSpeed = 2;
            GameManager.Instance.LastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
        if (playerMove.CarSpeed <= 0)
        {
            GameManager.Instance.RestartBool = true;
        }
    }
    void ShatterEffectConidition(Collider other)
    {
        if (other.transform.parent.name == "RoadBlockers" && ShatterObject.gameObject != null)
        {
            ShatterObject.transform.position = other.transform.position;
            ShatterObject.Play();
        }
    }
    void SpeedEffectConidition()
    {
        if (playerMove.CarSpeed > 15)
        {
            SpeedEffect.SetActive(true);
        }
        else
        {
            SpeedEffect.SetActive(false);
        }
    }

    private void Update()
    {

        SpeedEffectConidition();
    }
}
