using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTank : Vehicle
{
    [SerializeField] private float spinRate;

    private void Start()
    {
        SetVehicleColor();
    }

    public override void MoveVehicle()
    {
        if(transform.parent.name == "East Spawn Position")
            transform.Translate(movementSpeed * Time.deltaTime * -Vector3.right, Space.World);
        else
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.right, Space.World);

        transform.Rotate(0, spinRate, 0);
    }
}
