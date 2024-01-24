using UnityEngine;

namespace Project.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private PlayerFlow _playerPrefab;


        public PlayerFlow Spawn()
        {
            PlayerFlow playerFlow = Instantiate(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation, _playerSpawnPoint);
            return playerFlow;
        }
    }
}


