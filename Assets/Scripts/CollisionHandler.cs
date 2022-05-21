using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip successfulLanding;
    [SerializeField] AudioClip deathCollision;

    [SerializeField] ParticleSystem successfulLandingParticles;
    [SerializeField] ParticleSystem deathCollisionParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    int GetSceneIndex() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return currentSceneIndex;
    }

    void OnCollisionEnter(Collision other) {
        if (isTransitioning) { return; }
            switch (other.gameObject.tag) {
                case "Finish":
                    StartSuccessSequence();
                    break;
                case "Friendly":
                    Debug.Log("Touched the launch pad - returning to the start of the level");
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
    }

    private void StartSuccessSequence()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(successfulLanding);
        successfulLandingParticles.Play();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence() {
        audioSource.Stop();
        audioSource.PlayOneShot(deathCollision);
        deathCollisionParticles.Play();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel() {
        int currentSceneIndex = GetSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<Movement>().enabled = true;
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

