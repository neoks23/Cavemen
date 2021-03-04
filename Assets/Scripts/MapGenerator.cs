using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject terrain;
    public GameObject terrainTop;

    public List<Material> materials;

    [SerializeField]
    int length;
    [SerializeField]
    int loadingProgress;
    [SerializeField]
    int totalBlocks;

    public int LoadingProgress
    {
        get { return loadingProgress; }
    }
    public int TotalBlocks
    {
        get { return totalBlocks; }
    }
    void Start()
    {
        loadingProgress = 0;
        totalBlocks = (length * length * (length / 2)) + ((length - 1) * (length - 1) * (length / 2));
        StartCoroutine(InstantiateBlock(0.000001f));
        StartCoroutine(InstantiateMiddleBlock(0.000001f));
    }

    IEnumerator InstantiateBlock(float s)
    {

        for (int y = 0; y > -length / 2; y--)
        {
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    loadingProgress++;
                    if (y == 0)
                    {
                        Block block = terrain.GetComponent<Block>();
                        block.B = Block.Blocks.Grass;
                        block.transform.localPosition = new Vector3(x, y, z);
                        Instantiate(block.gameObject, transform, false);
                        yield return new WaitForSeconds(s);
                    }
                    else
                    {
                        int r = Random.Range(0, 100);
                        Block block = terrain.GetComponent<Block>();


                        if (r < 80)
                        {
                            block.B = Block.Blocks.Dirt;
                        }
                        else if (r >= 80 && r <= 90 && y < -2)
                        {
                            block.B = Block.Blocks.Stone;
                        }
                        else if (r > 90 && r < 97 && y < -4)
                        {
                            if (r % 2 == 0)
                            {
                                block.B = Block.Blocks.Gold;
                            }
                            else
                            {
                                block.B = Block.Blocks.Iron;
                            }
                        }
                        else if(y < -5)
                        {
                            block.B = Block.Blocks.Diamonds;
                        }


                        block.transform.localPosition = new Vector3(x, y, z);
                        Instantiate(block.gameObject, transform, false);
                        yield return new WaitForSeconds(s);
                    }

                }
            }
        }
    }
    IEnumerator InstantiateMiddleBlock(float s)
    {

        for (int y = 0; y > -length / 2; y--)
        {
            for (int x = 0; x < length - 1; x++)
            {
                for (int z = 0; z < length - 1; z++)
                {
                    loadingProgress++;
                    if (y == 0)
                    {
                        Block block = terrain.GetComponent<Block>();
                        block.B = Block.Blocks.Grass;
                        block.transform.localPosition = new Vector3(x, y, z);
                        Instantiate(block.gameObject, transform, false);
                        yield return new WaitForSeconds(s);
                    }
                    else
                    {
                        int r = Random.Range(0, 100);
                        Block block = terrain.GetComponent<Block>();


                        if (r < 80)
                        {
                            block.B = Block.Blocks.Dirt;
                        }
                        else if (r >= 80 && r <= 90 && y < -2)
                        {
                            block.B = Block.Blocks.Stone;
                        }
                        else if (r > 90 && r < 97 && y < -4)
                        {
                            if (r % 2 == 0)
                            {
                                block.B = Block.Blocks.Gold;
                            }
                            else
                            {
                                block.B = Block.Blocks.Iron;
                            }
                        }
                        else if (y < -5)
                        {
                            block.B = Block.Blocks.Diamonds;
                        }


                        block.transform.localPosition = new Vector3(x, y, z);
                        Instantiate(block.gameObject, transform, false);
                        yield return new WaitForSeconds(s);
                    }
                }
            }
        }
    }
}
