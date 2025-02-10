using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public SubmitName submitName;
    public string welcomeText = "Welcome <playerName> to the game!";
    public TMP_InputField inputField;
    public Button westButton;
    public Button eastButton;
    public Button submitButton;

    public void Start()
    {
        westButton.gameObject.SetActive(false);
        eastButton.gameObject.SetActive(false);
    }
    public void StartQuest()
    {
        titleText.text = welcomeText.Replace("<playerName>", submitName.playerName);

        ShowButtons();
    }

    public void ShowButtons()
    {
        westButton.gameObject.SetActive(true);
        eastButton.gameObject.SetActive(true);
        submitButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
    }
}
