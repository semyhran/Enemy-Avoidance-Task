using UnityEngine;

namespace Project.Enemies
{
    public abstract class AbstractSpawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private SpawnerData _spawnerData;
        [SerializeField] protected T _prefab;

        public void RunSpawner()
        {
            InvokeRepeating(nameof(Spawn), 
                Random.Range(_spawnerData.FirstSpawnInterval.x, _spawnerData.FirstSpawnInterval.y), 
                Random.Range(_spawnerData.RandomSpawnInterval.x, _spawnerData.RandomSpawnInterval.y));
        }

        private void Spawn()
        {
            var spawnPoint = new Vector3(Random.Range(-_spawnerData.HorizontalSpawnRange, _spawnerData.HorizontalSpawnRange), _spawnerData.SpawnHeight, Random.Range(-_spawnerData.VerticalSpawnRange, _spawnerData.VerticalSpawnRange));

            float randomRotationY = Random.Range(0f, 360f);

            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationY, 0f);

            var spawnedObject = Instantiate(_prefab, spawnPoint, randomRotation);

            InitializeObject(spawnedObject);
        }

        protected virtual void InitializeObject(T spawnedObject) { }

        private void OnDrawGizmos()
        {
            if (_spawnerData == null)
                return;

            Gizmos.color = Color.blue;

            Gizmos.DrawWireCube(transform.position, new Vector3(_spawnerData.HorizontalSpawnRange * 2, 1, _spawnerData.VerticalSpawnRange * 2));
        }

        public virtual void Stop()
        {
            CancelInvoke(nameof(Spawn));
        }
    }
}
