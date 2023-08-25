using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
  public float bulletSpeed = 1000f;
  public Rigidbody2D rb;




  void Start()
  {


  }

  private void Update()
  {
    rb.transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
  }

}
