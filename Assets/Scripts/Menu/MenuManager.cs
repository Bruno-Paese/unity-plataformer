using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu, levelSelect;
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            PlayerPrefs.DeleteAll();
            CheckLevels();
            Debug.Log("Resetou");
        }
    }

    // Update is called once per frame
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void LevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
        CheckLevels();
    }

    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    void CheckLevels()
    {
        levelButtons[0].interactable = true;
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.HasKey("Level" + (i + 1).ToString() + "Unlocked"))
            {
                levelButtons[i].interactable = true;
            } else
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
