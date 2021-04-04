using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Break();
    }

    private void Break()
    {
        foreach (var childCollider in GetComponentsInChildren<Collider>())
        {
            childCollider.enabled = true;
        }

        foreach (var childRigidbody in GetComponentsInChildren<Rigidbody>())
        {
            childRigidbody.isKinematic = false;
        }

        GetComponent<Collider>().enabled = false;
    }
}