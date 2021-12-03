using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : EnemyController
{
    // Start is called before the first frame update
    private void Start()
    {
        Tag = "FlyingEnemy";
        CurrentTime = 0;
        Position = GameConfig.StartingPoint[Tag];
        Velocity = GameConfig.Velocity[Tag];
    }

}
