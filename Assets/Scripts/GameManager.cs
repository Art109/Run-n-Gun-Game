using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 checkpointPosition;
    private bool checkpointSet = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
        checkpointSet = true;
    }

    public Vector3 GetRespawnPosition(Vector3 defaultSpawn)
    {
        return checkpointSet ? checkpointPosition : defaultSpawn;
    }

    public void GoToBossFight()
    {
        SceneManager.LoadScene("BossFight");
    }

    public void RestartGame()
    {
        checkpointSet = false;
        SceneManager.LoadScene("Level1");
    }
}

