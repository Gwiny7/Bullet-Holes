using UnityEngine;
using UnityEngine.Splines;

namespace BulletHoles
{
    public class EnemyFactoryRemake {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline){
            EnemyBuilderRemake builder = new EnemyBuilderRemake()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.speed);

            return builder.Build();
        }
    }
}