using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTOMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }





}