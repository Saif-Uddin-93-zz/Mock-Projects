using UnityEngine;
using TMPro;

public class Question_Tracker : MonoBehaviour
{
    TextMeshProUGUI t;
    //string qNum;
    public void UpdateQ(string qNum) 
    {
        t = transform.GetComponent<TextMeshProUGUI>();
        t.text = qNum; 
    }
}
