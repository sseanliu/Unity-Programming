using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Add this for Button

public class SceneChanger : MonoBehaviour
{
    public Button sceneChangeButton;  // Reference to the button
    public string targetSceneName;    // Scene to load

    void Start()
    {
        // If we have a button assigned, add a listener to it
        if (sceneChangeButton != null)
        {
            sceneChangeButton.onClick.AddListener(() => ChangeScene(targetSceneName));
        }
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Changing scene to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
