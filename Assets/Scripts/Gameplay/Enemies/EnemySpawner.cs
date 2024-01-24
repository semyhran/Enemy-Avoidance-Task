using System.Collections.Generic;
using UnityEngine;

namespace Project.Enemies
{
    public class EnemySpawner : AbstractSpawner<EnemyFlow>
    {
        private List<EnemyFlow> _enemyFlows = new List<EnemyFlow>();
        private Transform _playerTransform;


        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        protected override void InitializeObject(EnemyFlow spawnedObject)
        {
            spawnedObject.Init(_playerTransform);
            _enemyFlows.Add(spawnedObject);
        }

        public override void Stop()
        {
            base.Stop();

            _enemyFlows.ForEach(it => it.Stop());
        }
    }
}

