using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text gemQuantity;
    public static GameManager gm;
    public GameObject pausePannel;

    int gems = 0;
    bool isPaused = false;
    Scene scn;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        gemQuantity.text = gems.ToString("00");
        scn = SceneManager.GetActiveScene();
        pausePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausePannel.SetActive(isPaused);
    }
}
