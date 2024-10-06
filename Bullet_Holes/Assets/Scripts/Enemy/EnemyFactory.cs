using UnityEngine;
using UnityEngine.Splines;

namespace BulletHoles
{
    public class EnemyFactory {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline, FixedSpawner spawner){
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.speed)
                .SetSpawner(spawner);

            return builder.Build();
        }
    }
}
