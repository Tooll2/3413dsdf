using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{

    public GameObject mainButtons, lvlSelect;
    public void SingleButton()
    {
        mainButtons.SetActive(false);
        lvlSelect.SetActive(true);
    }

    public void SelectLvlScreept(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
