using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public int lines = 4;
    public int columns = 3;
    public float padding = 0.3f;
    public Material[] materials;
    private List<Material> potentialMaterials = new List<Material>();
    private List<CubeBehavior> cubes = new List<CubeBehavior>();
    private List<CubeBehavior> cubesRevealed = new List<CubeBehavior>();

    // Start is called before the first frame update
    void Start()
    {   
        if((lines * columns) % 2 != 0) {
            Debug.LogError("The level need to have an even number of cubes", gameObject);
            return;
        }

        for(int i=0; i < materials.Length; i++){
            potentialMaterials.Add(materials[i]);
            potentialMaterials.Add(materials[i]);
        }
        float decal = 1 + padding;

        for(float y=0; y < decal * lines; y += decal){
            for(float x=0; x < decal * columns; x += decal){
                Vector3 position = new Vector3(x, y, 0f);
                CreateCube(position);
            }
        }
    }

    public void CubeRevealed(CubeBehavior cube){
        if(cubesRevealed.Contains(cube))return;
        cube.RevealColor();
        cubesRevealed.Add(cube);

        if(cubesRevealed.Count >= 2){
            if(cubesRevealed[0].hiddenMaterial == cubesRevealed[1].hiddenMaterial){
                Debug.Log("It's a match!!!");
            }
        cubesRevealed.Clear();
        }
    }

    private void CreateCube(Vector3 position){
        GameObject cubeGO = Instantiate(cubePrefab, position, Quaternion.identity);
        CubeBehavior cube = cubeGO.GetComponent<CubeBehavior>();
        cubes.Add(cube);
        cube.manager = this;

        int index = Random.Range(0, potentialMaterials.Count);
        cube.hiddenMaterial = potentialMaterials[index];
        potentialMaterials.RemoveAt(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
