using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{
  bool hasPackage;
  [SerializeField] float destroyDelay = 0;
  [SerializeField] Color32 carColorWithPackage = new Color32(0, 230, 64, 100);
  [SerializeField] Color32 carColorNoPackage = new Color32(30, 144, 255, 100);

  SpriteRenderer spriteRenderer;

  Driver driver;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    driver = GetComponent<Driver>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("C R A S H!!");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Package" && !hasPackage)
    {
      Debug.Log("Picked up package");
      hasPackage = true;
      spriteRenderer.color = carColorWithPackage;
      Destroy(other.gameObject, destroyDelay);
    }
    if (other.tag == "DeliveryPoint" && hasPackage == true)
    {
      Debug.Log("Package delivered");
      hasPackage = false;
      spriteRenderer.color = carColorNoPackage;

    }

    if (other.tag == "Booster" && driver.moveSpeed < driver.maxSpeed)
    {
      driver.moveSpeed += 5;
    }

    if (other.tag == "Slower" && driver.moveSpeed > driver.minSpeed)
    {
      driver.moveSpeed -= 5;
    }
  }
}
