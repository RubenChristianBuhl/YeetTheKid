using UnityEngine;
using UnityEngine.SceneManagement;

public class Kid : MonoBehaviour
{
    public Rigidbody spine;
    public float maxFallDepth = 8;

    private void Update()
    {
        if (spine.transform.position.y < -maxFallDepth)
        {
            EndMenu.NextLevelSceneIndex = SceneManager.GetActiveScene().buildIndex;
            EndMenu.Message = "You fell off!";
            EndMenu.Retry = true;
            SceneManager.LoadScene(EndMenu.SceneIndex);
        }
    }
}