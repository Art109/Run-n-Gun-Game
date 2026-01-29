using UnityEngine;

public class Sentry : Enemy
{

    bool active;
    Transform target;

    protected override void Update()
    {
        base.Update();

        if (!active) 
        { 
            return;
        }

        Search();

        
    }

    protected override void Detect() // Verifies if player is on range
    {
       Collider2D player = Physics2D.OverlapCircle(transform.position, Data.Range, PlayerLayer);

        active = player != null;
        target = player != null ? player.transform : null;

    }

    void Search() //Search for the player to align the shoot
    {
        Aim();

        if (IsAligned())
        {
            TryShoot(ShootPoint.up);// Verifies if the enemy can shoot
        }
    }

    void Aim()// Rotates the barrel("Vector Up") of the sentry to align with player
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion desiredRotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            desiredRotation,
            180f * Time.deltaTime
        );

    }

    bool IsAligned() // Verifies if the top barrel is aligned with player
    {

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.up,
            Data.Range,
            PlayerLayer
        );

        rayHit = hit.collider != null;

        return rayHit;
    }


    bool rayHit;
 
    protected override void DrawExtraGizmos()
    {
        Gizmos.color = rayHit ? Color.red : Color.green;
        Gizmos.DrawLine(
            transform.position,
            transform.position + transform.up * Data.Range
        );
    }

}
