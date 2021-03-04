using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Blocks { Dirt, Stone, Grass, Iron, Gold, Diamonds};
    [SerializeField]
    Blocks block;
    [SerializeField]
    float hardness = 0;
    float timer = 0;
    PlayerMovement target;
    MeshCollider meshCollider;
    MeshRenderer meshRenderer;
    
    public Blocks B
    {
        get { return block; }
        set { block = value; }
    }
    public float Hardness
    {
        get { return hardness; }
        set { hardness = value; }
    }
    void Start()
    {
        Renderer m = GetComponent<Renderer>();
        MapGenerator mapGenerator = FindObjectOfType<MapGenerator>();
        switch (block)
        {
            case Blocks.Dirt:
                hardness = 1;
                m.material = mapGenerator.materials[0];
                break;
            case Blocks.Stone:
                hardness = 2;
                m.material = mapGenerator.materials[1];
                break;
            case Blocks.Grass:
                hardness = 1;
                m.material = mapGenerator.materials[2];
                break;
            case Blocks.Iron:
                hardness = 4;
                m.material = mapGenerator.materials[3];
                break;
            case Blocks.Gold:
                hardness = 3;
                m.material = mapGenerator.materials[4];
                break;
            case Blocks.Diamonds:
                hardness = 8;
                m.material = mapGenerator.materials[5];
                break;
        }
        target = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        meshCollider = this.GetComponent<MeshCollider>();
        meshRenderer = this.GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if(Vector3.Distance(transform.localPosition, target.transform.localPosition) <= target.FOV)
        {
            meshCollider.enabled = true;
            meshRenderer.enabled = true;
        }
        else
        {
            meshCollider.enabled = false;
            meshRenderer.enabled = false;
        }
    }
    private void OnMouseDrag()
    {
        timer += Time.deltaTime;
        
        if(timer > hardness)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseUp()
    {
        timer = 0;
    }
}
