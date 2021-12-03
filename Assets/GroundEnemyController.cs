using System;
using UnityEngine;

public class GroundEnemyController : EnemyController
{
  // Start is called before the first frame update

  private void Start()
  {
    Tag = "GroundEnemy";
    CurrentTime = 0;
    Position = GameConfig.StartingPoint[Tag];
    Velocity = GameConfig.Velocity[Tag];
  }
}