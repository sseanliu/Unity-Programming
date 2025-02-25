using UnityEngine;

public class ObjectClicker3D : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        Camera mainCamera = Camera.main;
        GameObject gameManagerObject = GameObject.Find("GameManagerHolder");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        if (mainCamera != null)
        {
            Vector3 position = mainCamera.transform.position;
            Quaternion rotation = mainCamera.transform.rotation;
            Debug.Log($"Main Camera Position: {position}");
            Debug.Log($"Main Camera Rotation: {rotation}");
        }
        else
        {
            Debug.LogError("Main Camera not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 position = mainCamera.transform.position;
            Quaternion rotation = mainCamera.transform.rotation;
            Debug.Log($"Main Camera Position: {position}");
            Debug.Log($"Main Camera Rotation: {rotation}");
        }
        else
        {
            Debug.LogError("Main Camera not found.");
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitPoint))
            {
                Debug.Log("Hit " + hitPoint.point);
                gameManager.DestroyObject(hitPoint.collider.gameObject);
            }
        }
    }
}
