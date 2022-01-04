using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    int GetSceneIndex() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return currentSceneIndex;
    }
    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Finish":
                LoadNextLevel();
                break;
            case "Friendly":
                Debug.Log("Touched the launch pad - returning to the start of the level");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel() {
        int currentSceneIndex = GetSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel() {
        int currentSceneIndex = GetSceneIndex();
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}

