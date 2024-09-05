namespace BulletHoles
{
    public class Enemy : Plane{
        protected override void Die()
        {
            GameManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
