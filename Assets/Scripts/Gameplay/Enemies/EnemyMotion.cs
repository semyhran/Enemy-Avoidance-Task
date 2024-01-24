using UnityEngine;
using UnityEngine.AI;

namespace Project.Enemies
{
    public class EnemyMotion : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private Transform _playerTransform;


        public void Init(Transform transform)
        {
            _playerTransform = transform;
        }

        public void SetActive(bool status)
        {
            _navMeshAgent.enabled = status;
        }

        void Update()
        {
            if (_playerTransform != null && NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 0.01f, NavMesh.AllAreas) && _navMeshAgent.enabled)
            {
                _navMeshAgent.SetDestination(_playerTransform.position);
            }
        }
    }
}


