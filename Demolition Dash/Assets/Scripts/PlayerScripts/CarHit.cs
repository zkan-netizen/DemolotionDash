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

            GateValue = other.GetComponent<GateSpeed>().Gate / 6;
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
            Debug.Log("restart is calling");
            GameManager.Instance.RestartBool = true;
        }
    }
    void ShatterEffectConidition(Collider other)
    {
        if (other.transform.parent.name == "RoadBlockers" && ShatterObject.gameObject != null)
        {
            GameManager.Instance.money += 100;
            ShatterObject.transform.position = other.transform.position;
            ShatterObject.Play();
        }
        else
        {
            ShatterObject = GameObject.Find("ObjectShatterParticle").GetComponent<ParticleSystem>();
        }
    }
    void SpeedEffectConidition()
    {
        if (playerMove.CarSpeed > 12.5f)
        {
            SpeedEffect.SetActive(true);
        }
        else
        {
            SpeedEffect.SetActive(false);
        }
        SpeedEffect.transform.position = new Vector3(transform.position.x - .4f, transform.position.y, transform.position.z);
    }

    private void Update()
    {

        SpeedEffectConidition();
    }
}
