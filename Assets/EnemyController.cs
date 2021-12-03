using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public ObjectPool enemyPool;

  protected int TimeTillNextEnemy;
  protected float CurrentTime;
  protected Vector2 Velocity;
  protected Vector3 Position;
  protected string Tag;

  // Update is called once per frame
  protected void FixedUpdate()
  {
    if (EventManager.Instance.start)
    {
      CurrentTime += Time.deltaTime;
      if (CurrentTime > TimeTillNextEnemy || TimeTillNextEnemy == 0)
      {
        InstantiateObject(Position, Velocity);
      }
    }
    
  }

  private void InstantiateObject(Vector3 position, Vector2 velocity)
  {
    var newEnemy = ObjectPool.Instance.GetObject(Tag, position, Quaternion.identity);

    if (newEnemy != null)
    {
      EventManager.Instance.ActiveEnemies.Add(newEnemy);
      var rb = newEnemy.GetComponent<Rigidbody2D>();
      rb.position = new Vector2(position.x, position.y);
      newEnemy.SetActive(true);
      TimeTillNextEnemy = Random.Range(1,5);
      CurrentTime = 0;
      newEnemy.tag = Tag;
      rb.velocity = velocity;
      return;
    }

    Debug.Log("cant find a new enemy");
  }
}