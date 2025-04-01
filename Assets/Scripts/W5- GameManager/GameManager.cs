using UnityEngine;
using System.Collections.Generic;

namespace W5GameManager
{
    public class GameManager : MonoBehaviour
    {
        public int[] intArray;
        public List<GameObject> gameObjectList;
        void Start()
        {
            intArray = new int[3];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i;
            }
            
            gameObjectList = new List<GameObject>();
            for (int i = 0; i < 3; i++)
            {
                SpawnObject();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SpawnObject()
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);

            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.transform.position = new Vector3(x, y, z);
            Debug.Log(x + " " + y + " " + z);

            gameObjectList.Add(gameObject);
        }

        public void DestroyObject(GameObject gameObject)
        {
            if (gameObjectList.Count > 0)
            {
                Destroy(gameObject);
                gameObjectList.Remove(gameObject);
            }
        }
    }
}
