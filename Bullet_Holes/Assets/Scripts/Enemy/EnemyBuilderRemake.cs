using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace BulletHoles
{
    public class EnemyBuilderRemake {
        GameObject enemyPrefab;
        SplineContainer spline;
        GameObject weaponPrefab;
        float speed;

        public EnemyBuilderRemake SetBasePrefab(GameObject prefab){
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilderRemake SetSpline(SplineContainer spline){
            this.spline = spline;
            return this;
        }

        public EnemyBuilderRemake SetWeaponPrefab(GameObject prefab){
            weaponPrefab = prefab;
            return this;
        }

        public EnemyBuilderRemake SetSpeed(float speed){
            this.speed = speed;
            return this;
        }

        public GameObject Build() {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;

            instance.transform.position = spline.EvaluatePosition(0f);
            //Enemy enemy = instance.GetComponent<Enemy>();

            return instance;
        }
    }
}
