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
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}