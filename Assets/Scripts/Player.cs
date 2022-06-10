using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GetMovementDirection() * (movementSpeed * Time.deltaTime));
    }

    private static Vector3 GetMovementDirection()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical"); 
        var direction = new Vector3(horizontalInput, verticalInput, 0);

        return direction;
    }
}
