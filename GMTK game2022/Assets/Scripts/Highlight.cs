using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color originalColor;
    [SerializeField] Color HighlightColor;
    bool _highlighted;
    public bool Highlighted
    {
        get => _highlighted;
        set
        {
            if (_highlighted != value)
            {
                _highlighted = value;
                MarkDirty();
            }
        }
    }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    void MarkDirty()
    {
        if (Highlighted)
        {
            Debug.Log($"Highlighted as {HighlightColor}");
            meshRenderer.material.color = HighlightColor;
        }
        else
        {
            meshRenderer.material.color = originalColor;
        }
    }
}
