using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int gems = 0;
    public Text gemQuantity;

    public static GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        gemQuantity.text = gems.ToString("00");
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
}
