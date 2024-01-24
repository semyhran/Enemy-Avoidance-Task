using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Level
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}


