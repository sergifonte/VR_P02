using UnityEngine;
using TMPro;

public class ColorFilterController : MonoBehaviour
{
    // Drag your "Mat_Blindness" here in the Inspector
    public Material blindnessMaterial; 

    // This function will be called by the Dropdown
    public void SetBlindnessType(int index)
    {
        if (blindnessMaterial != null)
        {
            // "type" must match the variable name in your Shader
            blindnessMaterial.SetInt("type", index);
        }
    }

    // Ensure it starts as "Normal" (index 0)
    void Start()
    {
        if (blindnessMaterial != null)
            blindnessMaterial.SetInt("type", 0);
    }
}