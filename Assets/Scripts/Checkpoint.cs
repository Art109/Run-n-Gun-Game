using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
            return;

        

        if (collision.CompareTag("Player"))
        {
            activated = true;
            GameManager.Instance.SetCheckpoint(transform.position);
        }
        
    }
}
