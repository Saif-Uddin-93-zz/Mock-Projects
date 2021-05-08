using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxScale : MonoBehaviour
{
    public float scaleWidth = 0.3f;
    public float testWidthPos = 0f;
    public float testHeightPos = 0f;

    float originalWidth;
    float aspectRatio;

    public bool skipEnum = false;

    public enum textPos
    {
        Title,
        Question1,
        Question2,
        Question3,
        Question4,
        Question5,
        Name,
        Submit,
        Next,
        Default
    };
    public textPos Pos = default;

    RectTransform text;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<RectTransform>();
        originalWidth = text.sizeDelta.x;
        aspectRatio = Screen.width / originalWidth;
        text.sizeDelta = new Vector2((originalWidth * aspectRatio) * scaleWidth, (text.sizeDelta.y * aspectRatio) * scaleWidth);
        updatePos();
        
    }

    void Update() 
    {
        //updatePos();
    }    

    void updatePos() 
    {
        if (!skipEnum)
        {
            switch (Pos)
            {
                case textPos.Title:
                    testHeightPos = 0.8f; testWidthPos = 0f;
                    break;
                case textPos.Question1:
                    testHeightPos = 0.3f; testWidthPos = -0.5f;
                    break;
                case textPos.Question2:
                    testHeightPos = 0.3f; testWidthPos = 0.5f;
                    break;
                case textPos.Question3:
                    testHeightPos = -0.2f; testWidthPos = -0.5f;
                    break;
                case textPos.Question4:
                    testHeightPos = -0.2f; testWidthPos = 0.5f;
                    break;
                case textPos.Question5:
                    testHeightPos = -0.6f; testWidthPos = 0f;
                    break;
                case textPos.Name:
                    testHeightPos = -0.8f; testWidthPos = -0.75f;
                    break;
                case textPos.Submit:
                    testHeightPos = -0.8f; testWidthPos = 0f;
                    break;
                case textPos.Next:
                    testHeightPos = -0.8f; testWidthPos = 0.7f;
                    break;
                case textPos.Default:
                    testHeightPos = 0.0f; testWidthPos = 0.0f;
                    break;
                default:
                    break;
            }
        }

        float x = Screen.width/2 * testWidthPos;
        float y = Screen.height/2 * testHeightPos;
        text.anchoredPosition3D = new Vector2(x, y);
    }

}
