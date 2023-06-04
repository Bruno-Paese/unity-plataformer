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
    public int totalGems = 0;
    public GameObject player;

    int gems = 0;
    bool isPaused = false;
    Scene scn;
    private GameObject[] getCount;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        scn = SceneManager.GetActiveScene();
        pausePannel.SetActive(false);
        getCount = GameObject.FindGameObjectsWithTag("Pickup");
        totalGems = getCount.Length;
        gemQuantity.text = gems.ToString("00") + "/" + totalGems;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

;        if (player.GetComponent<Rigidbody2D>().position.y < -6)
        {
            player.GetComponent<PlayerScript>().die();
        }
    }

    public void addGem()
    {
        gems++;
        gemQuantity.text = gems.ToString() + "/" + totalGems;
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

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausePannel.SetActive(isPaused);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
