using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    private Highlight _highlighter;
    public bool caught;


    // Start is called before the first frame update
    void Start()
    {
        _highlighter = GetComponent<Highlight>();
        caught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (caught)
        {
            _highlighter.Highlighted = true;
        }

        else {
            _highlighter.Highlighted = false;

        }
    }

    public void gotCaught(){
        caught = true;
    
    }

    public void gotFreed(){
        caught = false;
    }
}
