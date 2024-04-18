using UnityEngine;
using System;
using System.Collections;

public class Ball : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float deathTimer;
    #endregion
    
    private void Start()
    {
        StartCoroutine(BallDestroy());
    }

    private IEnumerator BallDestroy()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }
}
