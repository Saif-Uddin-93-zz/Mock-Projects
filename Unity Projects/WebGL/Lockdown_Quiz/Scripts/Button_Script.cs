using UnityEngine;

public class Button_Script : MonoBehaviour
{
    Load_URL url;
    Question_Tracker qt;
    public bool Q5;

    [Range (1,5)]
    public int questionNumber;
    string answer;
    // Start is called before the first frame update
    void Start()
    {
        url = transform.parent.parent.GetChild(12).GetComponent<Load_URL>();
        qt = transform.parent.parent.GetChild(11).GetComponent<Question_Tracker>();
        if(transform.parent.name != "Dummy") qt.UpdateQ(transform.parent.name);
    }

    public void CollectAnswer()
    {
        answer = transform.name;
        Debug.Log(transform.name);
    }

    public void SendAnswer() 
    {
        url.R[questionNumber-1] = answer;
    }

    public void ChangeQuestion() 
    {
        if (transform.parent.name == "Q5")
        {
            if(url.stage==Load_URL.Rounds.FinalRound)transform.parent.parent.GetChild(9).gameObject.SetActive(true);
            if (Q5 == false)
            {
                transform.parent.parent.GetChild(10).gameObject.SetActive(true);                
            }
        }
        else 
        {
            qt.UpdateQ(transform.parent.name);
            transform.parent.parent.GetChild(questionNumber + 2).gameObject.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
