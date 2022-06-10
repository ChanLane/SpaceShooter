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
        Destroy(gameObject, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (laserSpeed * Time.deltaTime));
    }

    #endregion
  
}
