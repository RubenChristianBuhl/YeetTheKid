using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public int nextSceneIndex;

    private void OnCollisionEnter(Collision other)
    {
        if (GameObject.FindWithTag("Kid").GetComponentsInChildren<Collider>().Contains(other.collider))
        {
            EndMenu.NextLevelSceneIndex = nextSceneIndex;
            EndMenu.Message = "Happy Birthday!\nYou hit the flag!";
            EndMenu.Retry = false;
            SceneManager.LoadScene(EndMenu.SceneIndex);
        }
    }
}