using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoadBar : MonoBehaviour {

    Slider levelProgressBar;

    IEnumerator LoadLevel() {
        AsyncOperation async = SceneManager.LoadSceneAsync(1);

        while(!async.isDone) {
            levelProgressBar.value = async.progress;

            yield return null;
        }
    }
}
