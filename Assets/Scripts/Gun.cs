using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletForce;
    [SerializeField] 
    private float angularLimit;
    [SerializeField]
    private bool rightGun;
    [SerializeField]
    private GameObject otherGun;
    [SerializeField]
    private SpriteRenderer playerRenderer;

    #endregion
    
    private void Update()
    {
        CheckGunSwitch();
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0f)
        {
            FireBall();
        }
        MoveGun();
    }

    private void FireBall()
    {
        GameObject ball = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        ball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }

    private void MoveGun()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        if (rightGun)
        {
            if (rotationZ > angularLimit)
            {
                rotationZ = angularLimit;
            }
            else if (rotationZ < -angularLimit)
            {
                rotationZ = -angularLimit;
            }
        }
        else
        {
            if((rotationZ > 0) && rotationZ < (180 - angularLimit))
            {
                rotationZ = 180 - angularLimit;
            }
            else if ((rotationZ < 0) && rotationZ > (-180 + angularLimit))
            {
                rotationZ = -180 + angularLimit;
            }
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    private void CheckGunSwitch()
    {
        
        if (rightGun && playerRenderer.flipX)
        {
            otherGun.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(!rightGun && !playerRenderer.flipX)
        {
            otherGun.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
    