using UnityEngine;
using TMPro;
public class SubmitName : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    string playerName = "";  
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerNamer()
    {
        playerName = nameText.text;
        Debug.Log(playerName);
    }
}
