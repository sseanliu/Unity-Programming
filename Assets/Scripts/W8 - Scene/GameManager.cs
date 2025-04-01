using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        // Singleton instance
        public static GameManager Instance { get; private set; }

        private string FILE_PATH;
        private const string FILE_NAME = "highscore.txt";

        public int score;
        public List<GameObject> gameObjectList;
        int sceneIndex;
        public float timeRemaining = 10f;
        public TextMeshPro tmpText;
        private int highScore;

        // High score property
        public int HighScore
        {
            get { return PlayerPrefs.GetInt("HighScore", 0); }
            set
            {
                if (value > HighScore)
                {
                    PlayerPrefs.SetInt("HighScore", value);
                    highScore = value;

                    Debug.Log("File: " + FILE_PATH + FILE_NAME);
                    string highScoreString = highScore + "";
                    File.WriteAllText(FILE_PATH + FILE_NAME, highScoreString);
                    Debug.Log("New High Score: " + highScore);
                }
            }
        }

        // Awake is called before Start
        private void Awake()
        {
            // Singleton pattern implementation
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // Destroy this instance if another already exists
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the instance persist across scenes
            highScore = HighScore; // Load the high score
        }
        
        void Start()
        {
            score = 0;
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            // Spawn initial target
            SpawnInitialTarget();

            FILE_PATH = Application.dataPath;
        }

        // Update is called once per frame
        void Update()
        {
            timeRemaining -= Time.deltaTime;

            tmpText.text = "Time Remaining: " + timeRemaining + "\nHigh Score: " + highScore;
            // if the score hit 10, load the next scene
            if (score >= 5)
            {
                ChangeScene();
            }

            if (timeRemaining <= 0)
            {
                ChangeScene();
            }
        }

        void ChangeScene()
        {
            // Check and update high score before changing scene
            if (score > highScore)
            {
                HighScore = score;
            }
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }
        
        // Create the first target in the scene
        void SpawnInitialTarget()
        {
            // Create a primitive capsule
            GameObject initialTarget = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            
            // Position it at a random position
            float randomX = Random.Range(-6f, 6f);
            float randomY = Random.Range(-6f, 6f);
            initialTarget.transform.position = new Vector3(randomX, randomY, 0f);
            
            // Add the Target component
            Target targetScript = initialTarget.AddComponent<Target>();
            targetScript.targetColor = Color.red;
            
            // Add a Rigidbody to allow for collisions
            Rigidbody rb = initialTarget.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
            
            // Set the color
            Renderer renderer = initialTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }

        // Handle mouse down to relocate target
        void OnMouseDown()
        {
            // Find the current target
            GameObject target = GameObject.FindGameObjectWithTag("Target");
            if (target != null)
            {
                // Generate new random position within -4 to 4 range
                float newX = Random.Range(-4f, 4f);
                float newY = Random.Range(-4f, 4f);
                target.transform.position = new Vector3(newX, newY, 0f);
            }
        }
    }
}
