using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float CarSpeed { get; set; } = 5;
  private void Movement()
  {
    transform.Translate(-CarSpeed * Time.deltaTime, 0, 0);
    // switch (CarSpeed)
    // {
    //   case < 0:
    //     CarSpeed = 0;
    //     this.GetComponent<Collider>().isTrigger=false;
    //     break;
    //  Burası araç hızı 0ın altına düşerse vesaire ne olacağını belirlemek için
    // }
    if (CarSpeed <= 0)
    {
      CarSpeed = 0;

    }
  }
  private void Update()
  {
    Movement();
  }
}
