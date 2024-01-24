using UnityEngine;

namespace Project.Enemies
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "Enemies/Spawner Data", order = 1)]
    public class SpawnerData : ScriptableObject
    {
        [Header("Spawn Interval")]
        [SerializeField] private Vector2 _firstSpawnInterval;
        [SerializeField] private Vector2 _randomSpawnInterval;

        [Header("Spawn Range")]
        [SerializeField] private float _horizontalSpawnRange = 5f;
        [SerializeField] private float _verticalSpawnRange = 2f;

        [Header("Spawn Height")]
        [SerializeField] private float _spawnHeight = 25f;


        public Vector2 FirstSpawnInterval => _firstSpawnInterval;
        public Vector2 RandomSpawnInterval => _randomSpawnInterval;
        public float HorizontalSpawnRange => _horizontalSpawnRange;
        public float VerticalSpawnRange => _verticalSpawnRange;
        public float SpawnHeight => _spawnHeight;
    }
}