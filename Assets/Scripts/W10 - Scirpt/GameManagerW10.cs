using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using SimpleJSON;
public class GameManagerW10 : MonoBehaviour
{
    public RawImage rawImage;
    public string dogAPI = "https://dog.ceo/api/breed/<breed>/images";
    void Start()
    {
        DogScriptableObject DobermannPinscher = ScriptableObject.CreateInstance<DogScriptableObject>();

        DobermannPinscher.dogBreed = "Dobermann Pinscher";
        DobermannPinscher.infoUrl = "https://dog.ceo/api/breed/doberman/images";
        DobermannPinscher.imgUrl = "https://images.dog.ceo/breeds/doberman/n02107142_7459.jpg";

        string DobermannPinscherJson = JsonUtility.ToJson(DobermannPinscher, true);

        File.WriteAllText(Application.dataPath + "/DobermannPinscher.json", DobermannPinscherJson);

        Debug.Log(DobermannPinscherJson);

        // read json file into the scriptable object
        string json = File.ReadAllText(Application.dataPath + "/DobermannPinscher.json");
        
        // Create a new instance first, then apply the JSON data to it
        DogScriptableObject DobermannPinscher2 = ScriptableObject.CreateInstance<DogScriptableObject>();
        JsonUtility.FromJsonOverwrite(json, DobermannPinscher2);

        File.WriteAllText(Application.dataPath + "/DobermannPinscher2.json", json);

        // render the image
        StartCoroutine(GetImage(DobermannPinscher2.imgUrl));

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string queryBreed = "akita";
            string queryUrl = dogAPI.Replace("<breed>", queryBreed);

            StartCoroutine(GetJSonFromAPI(queryUrl));
        }
    }

    IEnumerator GetJSonFromAPI(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log(webRequest.downloadHandler.text);

            string apiJson = webRequest.downloadHandler.text;
            JSONNode apiNode = JSON.Parse(apiJson);

            // Get the array of image URLs
            JSONArray imageUrls = apiNode["message"].AsArray;
            
            if (imageUrls != null && imageUrls.Count > 0)
            {
                // Get a random image from the array
                int randomIndex = Random.Range(0, imageUrls.Count);
                string imgUrl = imageUrls[randomIndex];
                Debug.Log("Selected random image: " + imgUrl);
                StartCoroutine(GetImage(imgUrl));
            }
            else
            {
                Debug.LogError("Failed to get valid image URLs from API response");
            }
        }
    }

    IEnumerator GetImage(string url)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
            rawImage.texture = texture;
            
            // Set rawImage size to match the texture's dimensions
            rawImage.rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
        }
    }
    
}