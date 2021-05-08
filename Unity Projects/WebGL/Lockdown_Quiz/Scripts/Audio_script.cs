using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_script : MonoBehaviour
{
    AudioSource sound;
    public int sceneToLoad;

    public bool loadLevel = true;

    private void Start()
    {
        sound = transform.GetComponent<AudioSource>();
        Debug.Log(sound.name);
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sound.isPlaying && loadLevel) 
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }


}
