using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video_script : MonoBehaviour
{
    public int sceneToLoad;
    VideoPlayer vid;
    //https://www.youtube.com/watch?v=SFkdcQgNJHo

    int countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        vid = transform.GetComponent<VideoPlayer>();
        vid.Play();
        Debug.Log(vid.frameCount);
    }

    // Update is called once per frame
    void Update()
    {
        countdown++;
        Debug.Log(vid.frame + ", Countdown: " + countdown);
        if ((int)vid.frame >= 119 || countdown >=300) 
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }
}
