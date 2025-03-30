using UnityEngine;

public class ChangeAllMaterialsTint : MonoBehaviour
{
    public Color tintColor = Color.red; // Base color
    [Range(0f, 1f)] public float intensity = 1f; // Intensity slider (0 = no tint, 1 = full tint)

    // List of materials to exclude
    private string[] excludedMaterials = { "Material.007", "Material.009", "Material.001" };

    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                if (!IsExcluded(mat.name)) 
                {
                    Color newColor = tintColor * intensity; // Multiply by intensity
                    mat.color = newColor;
                }
            }
        }
    }

    bool IsExcluded(string materialName)
    {
        foreach (string excluded in excludedMaterials)
        {
            if (materialName.Contains(excluded)) return true; // Skip if it matches
        }
        return false;
    }
}
