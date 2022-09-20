using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    //base class for all vehicle types
    //controls movement, coloring, scale

    [SerializeField] protected float movementSpeed = 15;
    [SerializeField] protected List<Color32> baseColors = new();
    protected MeshRenderer vehicleRenderer;
    private SpawnManager spawnManager;
    [SerializeField] GameObject replacementVehiclePrefab;

    private void Awake()
    {
        vehicleRenderer = GetComponent<MeshRenderer>();
        spawnManager = GameObject.Find("Manager").GetComponent<SpawnManager>();

        if (!TryGetComponent<DisableOnBounds>(out _))
            gameObject.AddComponent<DisableOnBounds>();
    }

    private void Update()
    {
        MoveVehicle();
    }

    public virtual void MoveVehicle()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    public void SetVehicleColor()
    {
        vehicleRenderer.material.color = baseColors[Random.Range(0, baseColors.Count)];
    }

    private void OnMouseDown()
    {
        ChangeVehicleType();
    }

    public virtual void ChangeVehicleType()
    {
        spawnManager.ReplaceActiveVehicle(Instantiate(replacementVehiclePrefab, transform.position, transform.rotation, transform.parent), gameObject);
        Destroy(gameObject);
    }
}
