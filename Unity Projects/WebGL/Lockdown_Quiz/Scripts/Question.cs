using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    Load_URL url;

    public enum round
    {
        Round1,
        Round2,
        FinalRound
    };
    [Range(1,5)]
    public int question;

    public enum options
    {
        A,
        B,
        C,
        D
    };

    public round stage;
    public options answers;
    string choice;

    private void Start()
    {
        url = transform.parent.GetChild(4).GetComponent<Load_URL>();
        switch (answers)
        {
            case options.A:
                choice = "A";
                break;
            case options.B:
                choice = "B";
                break;
            case options.C:
                choice = "C";
                break;
            case options.D:
                choice = "D";
                break;
            default: break;
        }
    }

    public void Q_Button(string a) 
    {
        switch (stage)
        {
            case round.Round1:
                //url.R1
                break;
            case round.Round2:
                break;
            case round.FinalRound:
                break;
            default: break;
        }
    }
}
