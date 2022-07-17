using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    private Highlight _highlighter;
    public bool caught;

    void Start()
    {
        _highlighter = GetComponent<Highlight>();
        caught = false;
    }

    public void gotCaught()
    {
        caught = true;
        _highlighter.Highlighted = true;
    }

    public void gotFreed()
    {
        caught = false;
        _highlighter.Highlighted = false;
    }
}
