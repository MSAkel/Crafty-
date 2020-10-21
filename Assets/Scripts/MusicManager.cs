using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] musicChangeArray;
    private AudioSource audioSource;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {

        //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        AudioClip currentSceneMusic = musicChangeArray[scene.buildIndex];

        if (currentSceneMusic)
        {
            audioSource.clip = currentSceneMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
