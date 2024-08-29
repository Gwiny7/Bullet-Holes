using UnityEngine;

namespace BulletHoles
{
    [CreateAssetMenu(fileName ="EnemyType", menuName = "BulletHoles/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}
