using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int gems = 0;
    public Text gemQuantity;
    Scene scn;

    public static GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        gemQuantity.text = gems.ToString("00");
        scn = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addGem()
    {
        gems++;
         gemQuantity.text = gems.ToString("00");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(scn.buildIndex);
    }
}
