using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
