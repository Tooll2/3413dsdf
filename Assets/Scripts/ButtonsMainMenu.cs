using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{
    public void SingleButton()
    {
        SceneManager.LoadScene("Single");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
