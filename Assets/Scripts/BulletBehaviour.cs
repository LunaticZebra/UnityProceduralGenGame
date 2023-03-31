using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GameStateManager.DecraseNumberOfEnemies();
            Destroy(col.gameObject);
            GameStateManager.CheckIfLevelFinished();
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
