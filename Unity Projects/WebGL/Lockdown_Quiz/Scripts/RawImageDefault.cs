//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageDefault : MonoBehaviour
{
    RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = transform.GetComponent<RawImage>();
        //img.uvRect = new Rect(0,0,Screen.width,Screen.height);
        img.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
