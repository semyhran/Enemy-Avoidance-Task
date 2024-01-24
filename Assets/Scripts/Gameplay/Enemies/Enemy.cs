using Project.Player;
using UnityEngine;

namespace Project.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected Rigidbody _rigidbody;

        private bool _onGround = false;
        private bool _stopped = false;


        protected virtual void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out PlayerFlow player))
            {
                player.Die();
                gameObject.SetActive(false);
            }

            if (!_stopped && !_onGround)
            {
                GroundCollision();
                _onGround = true;
            }
        }

        protected abstract void GroundCollision();

        public virtual void Stop()
        {
            _stopped = true;
        }
    }
}

