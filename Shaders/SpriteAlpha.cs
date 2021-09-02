using System.Collections;
using UnityEngine;

public class SpriteAlpha : MonoBehaviour
{
    private Material material;

    protected float MaterialAlpha
    {
        get { return material.GetFloat("_Alpha"); }
        set { material.SetFloat("_Alpha", value); }
    }

    private void Awake()
    {
        SetMaterial(GetComponent<SpriteRenderer>().material);
        MaterialAlpha = 1.0f;
    }

    private void SetMaterial(Material material)
    {
        this.material = material;
    }
}
