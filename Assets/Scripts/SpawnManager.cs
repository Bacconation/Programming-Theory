using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> startingVehicles = new();
    private List<GameObject> activeVehicles = new();
    [SerializeField] private float spawnRate;
    [SerializeField] private bool spawningActive;
    [SerializeField] private Transform eastSpawnTransform, westSpawnTransform;
    private Transform activeSpawnTransform;
    private int currentVehicleIndex;
    [SerializeField] private int vehicleSpawnCap;

    private void Start()
    {
        StartCoroutine(SpawnVehicles());
    }

    IEnumerator SpawnVehicles()
    {
        while (spawningActive)
        {
            yield return new WaitForSeconds(spawnRate);

            if(activeVehicles.Count == vehicleSpawnCap)
            {
                currentVehicleIndex = FindInactiveVehicle();

                activeVehicles[currentVehicleIndex].SetActive(true);

                ChooseRandomTransform();

                activeVehicles[currentVehicleIndex].transform.position = activeSpawnTransform.position;

                SetVehicleRotation();
            }
            else
            {
                ChooseRandomTransform();

                activeVehicles.Add(Instantiate(startingVehicles[Random.Range(0, startingVehicles.Count)], activeSpawnTransform));

                SetVehicleRotation();

                currentVehicleIndex++;
            }

        }
    }

    private int FindInactiveVehicle()
    {
        int vehicleIndex = 0;

        for (int i = 0; i < activeVehicles.Count; i++)
        {
            if (!activeVehicles[i].activeSelf)
            {
                vehicleIndex = i;
                break;
            }
        }

        return vehicleIndex;
    }

    private void ChooseRandomTransform()
    {
        int randomTransform = Random.Range(0, 2);
        Transform targetTransform = null;

        if (randomTransform == 0)
            targetTransform = eastSpawnTransform;
        else if (randomTransform == 1)
            targetTransform = westSpawnTransform;

        activeSpawnTransform = targetTransform;
    }

    private void SetVehicleRotation()
    {
        if (activeSpawnTransform == eastSpawnTransform)
            activeVehicles[currentVehicleIndex].transform.eulerAngles = new Vector3(0, -90, 0);
        else
            activeVehicles[currentVehicleIndex].transform.eulerAngles = new Vector3(0, 90, 0);
    }

    public void ReplaceActiveVehicle(GameObject newVehicle, GameObject callingVehicle)
    {
        activeVehicles[GetVehicleIndex(callingVehicle)] = newVehicle;
    }

    private int GetVehicleIndex(GameObject targetVehicle)
    {
        for (int i = 0; i < activeVehicles.Count; i++)
        {
            if (activeVehicles[i] == targetVehicle)
                return i;
        }

        return -1;
    }
}
