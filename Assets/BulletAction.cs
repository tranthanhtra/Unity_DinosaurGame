using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
  public Rigidbody2D rb;

  public ParticleSystem explosion;
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.name == "FlyingEnemy(Clone)")
    {
      EventManager.Instance.OnHitBullet();
      other.gameObject.SetActive(false);
      Destroy(gameObject);

      var instance = Instantiate(explosion, rb.position, Quaternion.identity);
      
      Destroy(instance.gameObject, explosion.main.duration);
    }
  }

  private void OnBecameInvisible()
  {
    if (gameObject.CompareTag("Bullet"))
    {
      Destroy(gameObject);
      return;
    }

    rb.velocity = new Vector2(0, 0);
  }
}