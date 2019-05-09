using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void StartFirstLevel() {
        SceneManager.LoadScene(1);
    }

    public void ReloadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
