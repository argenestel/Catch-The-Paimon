using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnObject;

    public int SpawnNumber;


    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Spawn").Length < SpawnNumber)
        {
            var positions = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Debug.Log(positions);
            var GO = Instantiate(_spawnObject, positions, Quaternion.identity);
            GO.transform.LookAt(Camera.main.transform.position);
        }

    }


}
