using UnityEngine;

public class Patroller : Enemy
{
    enum State { Patrol, Chase, Attack }

    Transform target;

    State currentState;

    [Header("Movement Params")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    int direction = 1;
    Rigidbody2D rb;

    [Header("Chase Params")]
    [SerializeField] float detectionMultiplier = 1.5f;

    

    protected override void Awake()
    {

        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (rb == null) 
        {
            Debug.LogWarning(this + "without Rb");
            gameObject.SetActive(false);
        }
    }

    protected override void Update() 
    { 
        base.Update();

        switch (currentState) 
        
        { 
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                Shoot();
                break;
        
        }

    }
    protected override void Detect() // Verifies if player is on range and changes the current state
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, Data.Range * detectionMultiplier, PlayerLayer);

        if (player == null)
        {
            target = null;
            currentState = State.Patrol;
            return;
        }

        target = player.transform;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance < Data.Range)
        {
            currentState = State.Attack;
        }
        else 
        { 
            currentState |= State.Chase;
        }

    }

    void Chase() // Logic of Chase Player
    {
        if (target == null)
        { 
            return;
        }

        float dir = Mathf.Sign(target.position.x -  transform.position.x);
        direction = (int)dir;

        Move();

        FaceDirection(direction);
    }

    void Patrol() // Logic of Patrol an Area
    {
        Move();

        if (!BorderCheck())
        {
            Flip();
        }
    }

    void Move() // Enemy Movement
    {
        rb.velocity = new Vector2(direction * Data.MoveSpeed, rb.velocity.y);
    }

    void StopMovement() 
    {
        rb.velocity = Vector2.zero;
    }

    void Flip()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void FaceDirection(int dir)
    {
        if (dir == direction)
            return;

        direction = dir;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;


    }



    bool BorderCheck() // Verifies if the enemy is near a border
    {
        bool check = Physics2D.OverlapCircle(groundCheck.position ,0.1f, groundLayer);

        if (check) 
        { 
            return true;
        }
        return false;
    }

    void Shoot()
    {
        StopMovement();

        if (target == null)
            return;

        float dir = Mathf.Sign(target.position.x - transform.position.x);
        FaceDirection((int)dir);

        Vector2 shootDir = (target.position - ShootPoint.position).normalized;
        TryShoot(shootDir);
    }

    protected override void DrawExtraGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Data.Range);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Data.Range * detectionMultiplier);
    }
}
