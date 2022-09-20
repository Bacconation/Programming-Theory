using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnBounds : MonoBehaviour
{
    [SerializeField] float xBoundsmin = -120, xBoundsMax = 90;

    private void Update()
    {
        if (transform.position.x < xBoundsmin || transform.position.x > xBoundsMax)
            DisableVehicle();
    }

    private void DisableVehicle()
    {
        gameObject.SetActive(false);
    }
}
