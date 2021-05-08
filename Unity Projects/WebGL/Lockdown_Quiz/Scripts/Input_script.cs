//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Input_script : MonoBehaviour
{
    TMP_InputField input;
    //Button but;
    public GameObject fSize;
    // Start is called before the first frame update
    void Start()
    {
        input = transform.GetComponent<TMP_InputField>();
        //but = transform.GetChild(1).GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        input.pointSize = fSize.GetComponent<Input_button>().fontSize;
    }

    public string GetInput() 
    {
        return input.text;        
    }

    public void Deb() 
    {
        Debug.Log(GetInput());
        Debug.Log(PlayerPrefs.GetString("name"));
    }

}
