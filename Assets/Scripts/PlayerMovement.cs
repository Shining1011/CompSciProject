using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    // General
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
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
    private Animator animator;
    [SerializeField]
    private string walkingAnimation;
    [SerializeField]
    private string idleAnimation;
    [SerializeField]
    private Transform playerGfx;
    //
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        stepCheckDifference = (stepMax.position - groundPoint.position).magnitude;
        stepCheckBox = new Vector2(collider.size.x + 2f*stepCheckDistance, stepCheckHeight);
    }

    
    private void Update()
    {
        Move();
        MoveFlashLight();
    }

    private void Move()
    {
        Vector3 move = Vector3.zero;
        move.y = rb.velocity.y;
        if (Input.GetKey(KeyCode.A))
        {
            Animations.instance.PlayAnimation(animator, walkingAnimation);
            Vector3 flip = Vector3.up * 180f;
            playerGfx.eulerAngles = flip;
            move += -Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Animations.instance.PlayAnimation(animator, walkingAnimation);
            Vector3 flip = Vector3.zero;
            playerGfx.eulerAngles = flip;
            move += Vector3.right * speed;
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

    private void MoveFlashLight()
    {
        Vector2 look = flashLightTransform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        flashLightTransform.Rotate(0, 0, angle);
    }
}
