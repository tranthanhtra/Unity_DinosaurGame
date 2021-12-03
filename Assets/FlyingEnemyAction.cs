using UnityEngine;

public class FlyingEnemyAction : MonoBehaviour
{
  public Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (rb.position.x < -10)
    {
      gameObject.SetActive(false);
      EventManager.Instance.ActiveEnemies.Remove(rb.gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.name == "Character")
    {
      Time.timeScale = 0;
      EventManager.Instance.GameOver();
      // gameObject.SetActive(false);
    }
    
  }
}