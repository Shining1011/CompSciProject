using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    // General
    public static PlayerMovement instance;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    [SerializeField]
    private Transform groundPoint;
    //

    // StepCheck
    [SerializeField]
    private Transform stepMax;
    [SerializeField]
    private float stepCheckDistance;
    [SerializeField]
    private float stepCheckDepth;
    [SerializeField]
    private float stepCheckHeight;
    [SerializeField]
    private LayerMask stepCheckLayerMask;
    private float stepCheckDifference;
    private Vector2 stepCheckBox;
    //

    // Light
    [SerializeField]
    private Transform flashLightTransform;
    //

    // Animation
    [SerializeField]
    private SpriteRenderer gfxRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string walkingAnimation;
    [SerializeField]
    private string idleAnimation;
    //
    #endregion

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {

            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        stepCheckDifference = (stepMax.position - groundPoint.position).magnitude;
        stepCheckBox = new Vector2(playerCollider.size.x + 2f*stepCheckDistance, stepCheckHeight);
    }
    
    private void Update()
    {
        if (Time.timeScale > 0f)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 move = Vector3.zero;
        move.y = rb.velocity.y;
        if (Input.GetKey(KeyCode.A))
        {
            Animations.instance.PlayAnimation(animator, walkingAnimation);
            gfxRenderer.flipX = true;
            move += -Vector3.right * speed;
            MoveFlashLight(1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Animations.instance.PlayAnimation(animator, walkingAnimation);
            gfxRenderer.flipX = false;
            move += Vector3.right * speed;
            MoveFlashLight(-1);
        }
        if(move.x == 0)
        {
            Animations.instance.PlayAnimation(animator, idleAnimation);
        }

        StepCheck(move.x);
        rb.velocity = move;
    }

    private void StepCheck(float direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(stepMax.position, stepCheckBox, 0f, Vector2.down, stepCheckDifference - stepCheckHeight / 2f + stepCheckDepth, ~stepCheckLayerMask);
        if (hit.collider != null && hit.distance != 0)
        {
            transform.position += Vector3.up * (stepCheckDifference - hit.distance - stepCheckHeight / 2f);
            transform.position += Vector3.right * direction * 0.005f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    private void MoveFlashLight(int side)
    {
        flashLightTransform.localRotation = Quaternion.Euler(0f, 0f, 90f * side);
    }
}
