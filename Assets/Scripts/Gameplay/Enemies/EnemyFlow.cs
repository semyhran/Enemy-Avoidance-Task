using UnityEngine;

namespace Project.Enemies
{
    public class EnemyFlow : Enemy
    {
        [SerializeField] private EnemyMotion _enemyMotion;


        public void Init(Transform playerTransform)
        {
            _enemyMotion.Init(playerTransform);
        }

        public override void Stop()
        {
            base.Stop();
            _rigidbody.isKinematic = true;
            _enemyMotion.SetActive(false);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

        protected override void GroundCollision()
        {
            _enemyMotion.SetActive(true);
        }
    }
}

