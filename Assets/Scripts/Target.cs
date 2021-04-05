using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public int nextSceneIndex = 0;

    private void OnCollisionEnter(Collision other)
    {
        print("OnCollisionEnter");
        if (other.gameObject.GetComponentsInParent<Kid>() != null)
        {
            print(other.gameObject.name);
            print("You win");
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}