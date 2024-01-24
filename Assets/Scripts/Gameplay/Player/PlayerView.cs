using UnityEngine;

namespace Project.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject _explosion;


        public void Explosion()
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
    }
}
