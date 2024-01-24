using Project.UI;
using System;
using UnityEngine;

namespace Project.Player
{
    public class PlayerFlow : MonoBehaviour
    {
        [SerializeField] private PlayerMotion _motion;
        [SerializeField] private PlayerView _view;

        public event Action OnDeath;

        public void Init(JoystickController joystickController)
        {
            _motion.Init(joystickController);

        }
        public void Die()
        {
            OnDeath?.Invoke();
            _view.Explosion();
            gameObject.SetActive(false);
        }
    }
}
