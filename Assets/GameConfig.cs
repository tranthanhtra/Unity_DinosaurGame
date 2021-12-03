using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{
  //key: tag name; value: starting point of the object
  public static readonly Dictionary<string, Vector3> StartingPoint = new Dictionary<string, Vector3>()
  {
    {"GroundEnemy", new Vector3(10f,-1.5f, 0f)},
    {"FlyingEnemy", new Vector3(10f,0f, 0f)},
    {"Bullet", new Vector3(0f,0f, 0f)}
  };
  
  public static readonly Dictionary<string, Vector2> Velocity = new Dictionary<string, Vector2>()
  {
    {"GroundEnemy", new Vector2(-7f,0f)},
    {"FlyingEnemy", new Vector2(-10f,0f)},
    {"Bullet", new Vector2(-1.7f,0f)}
  };
  
  public static readonly Dictionary<string, int> PoolSize = new Dictionary<string, int>()
  {
    {"GroundEnemy", 5},
    {"FlyingEnemy", 5},
    {"Bullet", 5}
  };

  public const float CharacterMass = 10f;

  public const float JumpForce = 4000f;
}