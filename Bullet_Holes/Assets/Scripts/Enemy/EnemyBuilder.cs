using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace BulletHoles
{
    public partial class EnemyBuilder
    {
        GameObject enemyPrefab;
        SplineContainer spline;
        GameObject weaponPrefab;
        float speed;

        public EnemyBuilder SetBasePrefab(GameObject prefab){
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline){
            this.spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject prefab){
            weaponPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpeed(float speed){
            this.speed = speed;
            return this;
        }

        public GameObject Build() {
            GameObject instance = GameObject.Instantiate(enemyPrefab, spline.transform);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.NegativeXAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.NegativeZAxis;
            splineAnimate.MaxSpeed = speed;

            instance.transform.position = (Vector3)spline.EvaluatePosition(0f);

            return instance;
        }
    }
}
