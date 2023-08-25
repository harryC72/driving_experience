using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

  public Transform canonLeft;

  public Transform canonRight;
  public GameObject bulletPrefab;

  void Shoot()
  {
    Instantiate(bulletPrefab, canonLeft.position, canonLeft.rotation);

    Instantiate(bulletPrefab, canonRight.position, canonRight.rotation);

  }



  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      Shoot();
    }

  }
}
