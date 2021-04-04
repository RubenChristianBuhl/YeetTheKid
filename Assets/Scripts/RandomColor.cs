using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Renderer[] ignoredRenderers;
    public Material[] colors;

    void Start()
    {
        foreach (var childRenderer in GetComponentsInChildren<Renderer>())
        {
            if (!ignoredRenderers.Contains(childRenderer))
            {
                childRenderer.material = colors[Random.Range(0, colors.Length)];
            }
        }
    }
}