using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBus : Vehicle
{
    [SerializeField] private float scaleChange;
    [SerializeField] private float scaleSpeed;
    private float baseXScale;
    private bool scalingDown = false;

    private void Start()
    {
        baseXScale = transform.localScale.x;
    }

    public override void MoveVehicle() // POLYMORPHISM
    {
        base.MoveVehicle();

        ChangeVehicleScale();
    }

    private void ChangeVehicleScale() // ABSTRACTION
    {
        if (transform.localScale.x >= baseXScale + scaleChange)
        {
            scalingDown = true;
            SetVehicleColor();
        }
        else if (transform.localScale.x <= baseXScale - scaleChange)
        {
            scalingDown = false;
            SetVehicleColor();
        }

        if(!scalingDown)
            transform.localScale = new Vector3(transform.localScale.x + scaleSpeed, transform.localScale.y, transform.localScale.z);

        if (scalingDown)
            transform.localScale = new Vector3(transform.localScale.x - scaleSpeed, transform.localScale.y, transform.localScale.z);
    }
}
