using UnityEngine;
using UnityEngine.Networking;

public class Load_URL : MonoBehaviour
{
    //Input_button name_input;
    string name_string;
    string response_workaround(string NAME, string ROUND1, string ROUND2, string FINALROUND) 
    {
        return "https://docs.google.com/forms/d/e/1FAIpQLSf8O9BIm4Hyd6oloBpvPWQ9O5sK81Y1CX7wbLvMrgoSMS0VEg/formResponse?usp=pp_url&entry.1778524138=" +
            NAME+"&entry.495244804="+ROUND1+"&entry.1399721644="+ROUND2+"&entry.1507587132="+FINALROUND+"&submit=Submit";
    }

    public bool end = false;

    public enum Rounds
    {
        Round1,
        Round2,
        FinalRound,
        End
    };

    public Rounds stage;

    string r1_URL = "";
    string r2_URL = "";
    string fr_URL = "";

    [HideInInspector]
    public string[] R = new string[5];

    private void Start()
    {
        if (end) LoadWebPage(); Debug.Log("end!");
    }

    string BuildURL()
    {
        switch (stage)
        {
            case Rounds.Round1:
                r1_URL = "https%3A%2F%2Fdocs.google.com%2Fforms%2Fd%2Fe%2F1FAIpQLSesqAvEkrvM0Yq_8j8f95tbS9bt2oYqJAzhcniYfRhmD2DxrQ%2FformResponse%3Fusp%3Dpp_url%26entry.565045485%3D" +
                    PlayerPrefs.GetString("name") + "&entry.1676392448=" + R[0] + "&entry.1278327312=" + R[1] + "&entry.31673271=" + R[2] + "&entry.2028296922=" + R[3] + "&entry.450165993=" + R[4] + "&submit=Submit";
                return r1_URL;
            case Rounds.Round2:
                r2_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfbLu3XEkLR4iv6ck1VyNvTzWrl_Ru5s62OTqRzLy1QUal1Sw/formResponse?usp=pp_url&entry.464774202=" +
                    PlayerPrefs.GetString("name") + "&entry.115660186=" + R[0] + "&entry.594728571=" + R[1] + "&entry.70868325=" + R[2] + "&entry.1513993454=" + R[3] + "&entry.1474412436=" + R[4] + "&submit=Submit";
                return r2_URL;
            case Rounds.FinalRound:
                fr_URL = "https://docs.google.com/forms/d/e/1FAIpQLSccz4PTV5dQJHTuDb0aMOc4LBGZbWFq398Iw5Y2wCNPPH3Ljw/formResponse?usp=pp_url&entry.831890802=" +
                    PlayerPrefs.GetString("name") + "&entry.524310709=" + R[0] + "&entry.589632511=" + R[1] + "&entry.283081030=" + R[2] + "&entry.2070966678=" + R[3] + "&entry.932704073=" + R[4] + "&submit=Submit";
                return fr_URL;
            default:
                break;
        }
        return "";
    }

    public void SaveInPrefs() 
    {
        switch (stage)
        {
            case Rounds.Round1:
                PlayerPrefs.SetString("r1",BuildURL()); break;
            case Rounds.Round2:
                PlayerPrefs.SetString("r2", BuildURL()); break;
            case Rounds.FinalRound:
                PlayerPrefs.SetString("fr", BuildURL()); break;
            default:
                break;
        }
        PlayerPrefs.Save();
        //Application.OpenURL(PlayerPrefs.GetString("r1"))
    }

    public void LoadWebPage() { /*
        Application.OpenURL(PlayerPrefs.GetString("r1"));
        Application.OpenURL(PlayerPrefs.GetString("r2"));
        Application.OpenURL(PlayerPrefs.GetString("fr"));*/
        Application.OpenURL(response_workaround(PlayerPrefs.GetString("name"),
            UnityWebRequest.EscapeURL(PlayerPrefs.GetString("r1")),
            UnityWebRequest.EscapeURL(PlayerPrefs.GetString("r2")),
            UnityWebRequest.EscapeURL(PlayerPrefs.GetString("fr"))));
        //Application.OpenURL(UnityWebRequest.UnEscapeURL("https%3A%2F%2Fdocs.google.com%2Fforms%2Fd%2Fe%2F1FAIpQLSesqAvEkrvM0Yq_8j8f95tbS9bt2oYqJAzhcniYfRhmD2DxrQ%2FformResponse%3Fusp%3Dpp_url%26entry.565045485%3D"));
    }

    public void SetName() => name_string = PlayerPrefs.GetString("name");

    //Round 1: https://docs.google.com/forms/d/e/1FAIpQLSesqAvEkrvM0Yq_8j8f95tbS9bt2oYqJAzhcniYfRhmD2DxrQ/viewform?usp=pp_url&entry.565045485=Tara&entry.1676392448=B&entry.1278327312=A&entry.31673271=A&entry.2028296922=A&entry.450165993=A
    //ROUND 2: https://docs.google.com/forms/d/e/1FAIpQLSfbLu3XEkLR4iv6ck1VyNvTzWrl_Ru5s62OTqRzLy1QUal1Sw/viewform?usp=pp_url&entry.464774202=test&entry.115660186=A&entry.594728571=B&entry.70868325=C&entry.1513993454=D&entry.1474412436=A
    //FINAL ROUND: https://docs.google.com/forms/d/e/1FAIpQLSccz4PTV5dQJHTuDb0aMOc4LBGZbWFq398Iw5Y2wCNPPH3Ljw/viewform?usp=pp_url&entry.831890802=name&entry.524310709=A&entry.589632511=A&entry.283081030=A&entry.2070966678=B&entry.932704073=D
}
