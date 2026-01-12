using UnityEngine;

public class Sentry : Enemy
{

    bool active;
    Transform target;

    protected override void Update()
    {
        base.Update();

        Detect();

        if (!active) 
        { 
            return;
        }

        Search();

        
    }
    protected override void Shoot()
    {
        if (!CanShoot())
            return;

        ResetFireCooldown();
        Debug.Log("Sentry Disparou");
    }

    protected override void Detect()
    {
       Collider2D player = Physics2D.OverlapCircle(transform.position, data.Range, playerLayer);

        active = player != null;
        target = player != null ? player.transform : null;

    }

    void Search()
    {
        Aim();

        if (IsAligned())
        {
            Shoot();
        }
    }

    void Aim()
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

    bool IsAligned() 
    {

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.up,
            data.Range,
            playerLayer
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
            transform.position + transform.up * data.Range
        );
    }

}
