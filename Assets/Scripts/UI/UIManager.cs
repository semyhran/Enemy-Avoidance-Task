using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI 
{
    public class UIManager : MonoBehaviour
    {
        public event Action OnStartGame;
        public event Action OnRestartGame;

        [SerializeField] private GameObject _tapToStartUI;
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private JoystickController _joystick;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public JoystickController Joystick => _joystick;

        private bool _gameStarted = false;


        private void Awake()
        {
            _restartButton.onClick.AddListener(() => RestartGame());
            _exitButton.onClick.AddListener(() => Application.Quit());

        }

        private void Start()
        {
            ShowTapToStartUI(true);
            SetJoystickActive(false);
        }
        void Update()
        {
            // Check for user input (tap or touch)
            if (!_gameStarted && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
            {

                ShowTapToStartUI(false);
                SetJoystickActive(true);
                OnStartGame?.Invoke();
                _gameStarted = true;
            }
        }

        private void ShowTapToStartUI(bool show)
        {
            if (_tapToStartUI != null)
            {
                _tapToStartUI.SetActive(show);
            }
        }

        private void SetJoystickActive(bool active)
        {
            if (_joystick != null)
            {
                _joystick.SetActive(active);
            }
        }

        public void GameOver(float elapsedTime)
        {
            string time = GetFormattedElapsedTime(elapsedTime);
            _timerText.text = "You Lasted " + time;
            _gameOverUI.SetActive(true);
        }
        public string GetFormattedElapsedTime(float elapsedTime)
        {
            int hours = (int)(elapsedTime / 3600);
            int minutes = (int)((elapsedTime % 3600) / 60);
            int seconds = (int)(elapsedTime % 60);

            if (hours > 0)
            {
                return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds) + " hours";
            }
            else if (minutes > 0)
            {
                return string.Format("{0:D2}:{1:D2}", minutes, seconds) + " minutes";
            }
            else
            {
                return seconds + " seconds";
            }
        }


        private void RestartGame()
        {
            OnRestartGame?.Invoke();
        }

    }
}


