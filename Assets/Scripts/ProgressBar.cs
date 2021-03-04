using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    MapGenerator mapGenerator;
    Text txt;
    public GameObject box;
    public GameObject btn;
    float timer;
    void Start()
    {
        timer = 0.0f;
        mapGenerator = FindObjectOfType<MapGenerator>().GetComponent<MapGenerator>();
        txt = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = mapGenerator.LoadingProgress.ToString() + "/" + mapGenerator.TotalBlocks.ToString();

        if(mapGenerator.LoadingProgress == 20000)
        {
            btn.SetActive(true);
        }
        if(mapGenerator.LoadingProgress == mapGenerator.TotalBlocks)
        {
            timer += Time.deltaTime;
            txt.text = "Starting Game...";
    
            if(timer > 5.0f)
            {
                DestroyLoadingScreen();
            }
        }
    }
    public void DestroyLoadingScreen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(box);
        Destroy(gameObject);
    }
}
