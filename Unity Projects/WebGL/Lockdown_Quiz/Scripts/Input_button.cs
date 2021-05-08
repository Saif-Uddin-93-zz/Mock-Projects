using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Input_button : MonoBehaviour
{
    //TMP_InputField input;
    Input_script name_input;
    public string name_string;
    public float fontSize;
    public int lvl;
    Load_URL url;
    public bool titleScene = false;

    // Start is called before the first frame update
    void Start()
    {
        name_input = transform.parent.GetComponent<Input_script>();
        if (titleScene == false) { 
            url = transform.parent.GetChild(12).GetComponent<Load_URL>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        fontSize = transform.GetChild(0).GetComponent<Text>().cachedTextGenerator.fontSizeUsedForBestFit;
    }

    public void CollectInput()
    {
        name_string = name_input.GetInput();
    }

    public void SaveInput()
    {
        PlayerPrefs.SetString("name", name_string);
        PlayerPrefs.Save();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(lvl);
    }

    public void SaveAnswers ()
    {
        url.SaveInPrefs();
    }
}
