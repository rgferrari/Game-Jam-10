using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    bool isMenu = true;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //futuramente irá tocar a musica tema do jogo
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play("descoberta-v1");
            isMenu = true;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!isMenu)
            {
                //Pause("theme");
                Play("descoberta-v1");
                isMenu = true;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (isMenu) { 
                Pause("descoberta-v1");
                //Play("theme");
                isMenu = false;
            }
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound" + name + "not found!");
            return;
        }
        s.source.Play();
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found!");
            return;
        }
        s.source.Pause();
    }
}
