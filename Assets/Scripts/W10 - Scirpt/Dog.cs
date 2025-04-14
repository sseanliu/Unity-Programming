using UnityEngine;

[CreateAssetMenu(fileName = "New Dog", menuName = "Dog")]

public class DogScriptableObject : ScriptableObject
{
    public string dogBreed;
    public string infoUrl;
    public string imgUrl;
}