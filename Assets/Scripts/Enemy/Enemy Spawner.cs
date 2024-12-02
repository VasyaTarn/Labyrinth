using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Enemy enemy;

        [SerializeField] private VignetteByDistance vignetteByDistance;

        public void spawnEnemy()
        {
            if (spawnPoints.Length > 0)
            {
                Enemy spawnedEnemy = Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                vignetteByDistance.setEnemy(spawnedEnemy.transform);
            }
        }
    }
}
