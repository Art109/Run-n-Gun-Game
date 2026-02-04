using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]private Vector3 defaultSpawnPosition;

    private void Start()
    {
        if(defaultSpawnPosition == null)
        {
            defaultSpawnPosition = transform.position;
        }
    }

    public void Respawn()
    {
        Vector3 spawnPos = GameManager.Instance.GetRespawnPosition(defaultSpawnPosition);
        transform.position = spawnPos;
    }
}
