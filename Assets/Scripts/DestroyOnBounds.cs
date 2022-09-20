using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBounds : MonoBehaviour
{
    [SerializeField] float xBoundsmin, xBoundsMax;

    private void Update()
    {
        if (transform.position.x < xBoundsmin || transform.position.x > xBoundsMax)
            DestroyVehicle();
    }

    private void DestroyVehicle()
    {
        Destroy(gameObject);
    }
}
