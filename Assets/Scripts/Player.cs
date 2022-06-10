using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : MonoBehaviour 
{
 
    #region Variables

    [SerializeField] private float movementSpeed;
    // Start is called before the first frame update

    [FoldoutGroup("Player Bounds")]
    [SerializeField] private float xNegBound;
    
    [FoldoutGroup("Player Bounds")]
    [SerializeField] private float xPosBound;

    [FoldoutGroup("Player Bounds")]
    [SerializeField] private float yNegBound;
    
    [FoldoutGroup("Player Bounds")]
    [SerializeField] private float yPosBound;

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform muzzleLocation;

    private bool _canFire = true;

    [SerializeField] private float cooldownTime;


    #endregion

    #region UnityMethods

    private void Start()
    {
        transform.position = Vector3.zero;
        
    }

    private void Update()
    { 
        HandleMovement();
        HandleLaserFire();
    }
    
    #endregion

    #region CustomMethods
    private void HandleMovement()
    {
        transform.Translate(GetMovementDirection() * (movementSpeed * Time.deltaTime));
        EnforcePlayerBounds();
    }
    private static Vector3 GetMovementDirection()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical"); 
        var direction = new Vector3(horizontalInput, verticalInput, 0);

        return direction;
    }
    private void EnforcePlayerBounds()
    {
        var position = transform.position;
        var yValue = position.y;
        var xValue = position.x;
        
        if (transform.position.x < xNegBound)
        {
            transform.position = new Vector3(xPosBound, yValue, 0);
        }

        if (transform.position.x > xPosBound)
        {
            transform.position = new Vector3(xNegBound, yValue, 0);
        }

        if (transform.position.y <= yNegBound) 
        {
            transform.position = new Vector3(xValue, yNegBound, 0);
        }

        if (transform.position.y >= yPosBound)
        {
            transform.position = new Vector3(xValue, yPosBound, 0);
        }
    }
    private void HandleLaserFire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canFire)
        {
            _canFire = false;
            Instantiate(laserPrefab, muzzleLocation.position, Quaternion.identity);
            HandleCoolDown();
        }
    }
    private void HandleCoolDown()
    {
        StartCoroutine(CoolDownRoutine(cooldownTime));
    }
    private IEnumerator CoolDownRoutine(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        _canFire = true;
    }
    
    #endregion
    
}

