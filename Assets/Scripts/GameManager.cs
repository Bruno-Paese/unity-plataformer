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
    public int totalGems;

    int gems = 0;
    bool isPaused = false;
    Scene scn;
    private GameObject[] getCount;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        gemQuantity.text = gems.ToString("00");
        scn = SceneManager.GetActiveScene();
        pausePannel.SetActive(false);
        getCount = GameObject.FindGameObjectsWithTag("Pickup");
        totalGems = getCount.Length;
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
        gemQuantity.text = gems.ToString("00") + "/" + totalGems;
        if (gems >= totalGems)
        {
            SceneManager.LoadScene(scn.buildIndex + 1);
            PlayerPrefs.SetInt("level" + (scn.buildIndex).ToString() + "Unlocked", 1);
        }
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
