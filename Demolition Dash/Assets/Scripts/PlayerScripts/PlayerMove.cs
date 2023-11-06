
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
  [SerializeField] private GameObject _SpeedEffect;
  public float CarSpeed { get; set; } = 5;
  private void Movement()
  {
    //if (GameManager.Instance.GameStarted == true)

    transform.Translate(-CarSpeed * Time.deltaTime, 0, 0);

    _SpeedEffect.transform.parent = this.transform;

  }
  public void ChangeCarYPosition(float newY)
  {
    if (GameManager.Instance.MainMenu.activeSelf == false)
    {
      Transform carTransform = transform;
      Vector3 carPosition = carTransform.position;
      carPosition.y = newY;


      carTransform.position = carPosition;
    }
    else
    {
      transform.position = new Vector3(0, 0, 0);
    }
  }

  private void Update()
  {
    Movement();
    ChangeCarYPosition(1);
    // ManageScript();
  }
}
