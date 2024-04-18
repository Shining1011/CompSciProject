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
    #endregion
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBall();
        }
    }

    private void FireBall()
    {
        GameObject ball = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        ball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }
}
