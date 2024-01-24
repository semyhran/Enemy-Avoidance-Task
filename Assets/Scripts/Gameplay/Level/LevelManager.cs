using Project.Enemies;
using Project.Player;
using Project.UI;
using UnityEngine;

namespace Project.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private MineSpawner _mineSpawner;
        [SerializeField] private UIManager _uiManger;
        [SerializeField] private Timer _timer;
        [SerializeField] private LevelLoader _levelLoader;

        private PlayerFlow _player;


        private void Awake()
        {
            _player = _playerSpawner.Spawn();
            _player.Init(_uiManger.Joystick);
            _enemySpawner.Init(_player.transform);
            _player.OnDeath += GameOver;
            _uiManger.OnStartGame += StartGame;
            _uiManger.OnRestartGame += RestartLevel;
        }

        private void StartGame()
        {
            _enemySpawner.RunSpawner();
            _mineSpawner.RunSpawner();
            _timer.StartTimer();
        }

        private void GameOver()
        {
            _player.OnDeath -= GameOver;
            _enemySpawner.Stop();
            _mineSpawner.Stop();
            _timer.StopTimer();
            _uiManger.GameOver(_timer.GetElapsedTime());
            
        }

        private void RestartLevel()
        {
            _levelLoader.LoadLevel(0);
        }
    }
}


