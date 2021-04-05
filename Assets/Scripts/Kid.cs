using UnityEngine;
using UnityEngine.SceneManagement;

public class Kid : MonoBehaviour
{
    public Rigidbody spine;
    public float maxFallDepth = 8;
    public int fallSceneIndex = 0;

    private void Update()
    {
        if (spine.transform.position.y < -maxFallDepth)
        {
            print("You lose");
            SceneManager.LoadScene(fallSceneIndex);
        }
    }
}