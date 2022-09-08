using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Material hiddenMaterial;
    private Material originalMaterial;
    public LevelManager manager;

    void Start()
    {
     originalMaterial = GetComponent<Renderer>().material;   
    }


    void OnMouseUp(){
        manager.CubeRevealed(this);
    }

    public void RevealColor(){
        GetComponent<Renderer>().material = hiddenMaterial;
    }

    public void UnrevealColor(){
        GetComponent<Renderer>().material = originalMaterial;
    }
            
    // Update is called once per frame
    void Update()
    {
        
    }
}
