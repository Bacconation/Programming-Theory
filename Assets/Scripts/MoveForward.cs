using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float movementSpeed = 15;

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

    private void ApplyMovement()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
