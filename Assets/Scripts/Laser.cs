using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    #region Variables

    [SerializeField] private float laserSpeed;
    [SerializeField] private float laserDestroyTime;

    #endregion

    #region UnityMethods
    void Start()
    {
        Destroy(gameObject, laserDestroyTime);   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * (laserSpeed * Time.deltaTime));
    }
    
    #endregion
  
}
