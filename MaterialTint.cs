using UnityEngine;

public class MaterialTint : MonoBehaviour
{
    private Material material;
    [SerializeField] private Color materialTintColor;
    [SerializeField] private float tintFadeSpeed;

    private void Awake()
    {
        SetMaterial(GetComponent<SpriteRenderer>().material);
    }

    private void Update()
    {
        if (materialTintColor.a > 0)
        {
            materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
            material.SetColor("_Tint", materialTintColor);
        }
    }

    public void SetMaterial(Material material)
    {
        this.material = material;
    }

    public void SetTintColor(Color color)
    {
        materialTintColor = color;
        material.SetColor("_Tint", materialTintColor);
    }

    public void SetTintFadeSpeed(float tintFadeSpeed)
    {
        this.tintFadeSpeed = tintFadeSpeed;
    }
}
