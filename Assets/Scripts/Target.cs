using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentsInParent<Kid>() != null)
        {
            print("You win");
        }
    }
}
