using UnityEngine;

public class Kid : MonoBehaviour
{
    public Rigidbody spine;
    public float maxFallDepth = 8;

    private void Update()
    {
        if (spine.transform.position.y < -maxFallDepth)
        {
            print("You lose");
        }
    }
}