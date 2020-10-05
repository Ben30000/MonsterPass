using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    private static ManageScenes Manager = null;
    private GameSparksApiCalls Api;

    private AudioSource AudioSource = null;
    public AudioClip[] AudioFiles;

    void Awake()
    {
        if(Manager == null)
        {
            Manager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        AudioSource = this.GetComponentInChildren<AudioSource>();
        Api = GameObject.Find("GameSparks").GetComponent<GameSparksApiCalls>();
    }

    void Update()
    {

    }

    public bool isMusicOn()
    {
        return AudioSource.isPlaying;
    }

    public void toggleMusic()
    {
        if(AudioSource.isPlaying) {
            AudioSource.Stop();
        } else {
            AudioSource.Play();
        }
    }

    public void setMusic(int audioIndex)
    {
        if(AudioSource.isPlaying) {
            AudioSource.Stop();
            AudioSource.clip = AudioFiles[audioIndex];
            AudioSource.Play();
        } else {
            AudioSource.clip = AudioFiles[audioIndex];
        }
    }

    public string getMusic()
    {
        return AudioSource.clip.name;
    }

    public void setVolume(float audioVolume)
    {
        if(AudioSource.isPlaying) {
            AudioSource.volume = audioVolume;
        }
    }

    public float getVolume()
    {
        return AudioSource.volume;
    }

        //move user to login screen
    public void toTitleScreen()
    {
        SceneManager.LoadScene("titleScreen");
    }

    //move user to login screen
    public void toSignIn()
    {
        SceneManager.LoadScene("signinScreen");
    }

    //move user to register screen
    public void toRegister()
    {
        SceneManager.LoadScene("registerScreen");
    }

    //move user to ranch screen
    public void toRanchScreen()
    {
        SceneManager.LoadScene("ranchScreen");
    }

    //move user to settings
    public void toSettingsScreen()
    {
        SceneManager.LoadScene("settingsScreen");
    }

    //move user to monster creation screen
    public void toMonsterEditingScreen()
    {
        SceneManager.LoadScene("monsterEditingScreen");
    }
}
