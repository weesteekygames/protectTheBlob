using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_background_alpha_script : MonoBehaviour
{
    public float alpha; 
    // Start is called before the first frame update
    void Start()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
