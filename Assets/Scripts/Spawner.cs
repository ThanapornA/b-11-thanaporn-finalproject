using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [ SerializeField ] public GameObject[] prefabs;
    [ SerializeField ] public float timeToSpawn = 1f;
    [ SerializeField ] public float minPosition , maxPosition;

    private void Start()
    {
        StartCoroutine(FallingObjectsSpawn()); //note : use this to start using IEnumerator
    }

    IEnumerator FallingObjectsSpawn() //note : a special method that runs together with other methods
    {
        while (true)
        {
            var fallingObjPosition = Random.Range( minPosition , maxPosition );

            var position = new Vector3( fallingObjPosition , transform.position.y);

            GameObject fallingPrefabs = Instantiate(prefabs[Random.Range(0 , prefabs.Length )] , position , Quaternion.identity ); //note : Quaternion ....

            yield return new WaitForSeconds( timeToSpawn );

            Destroy( fallingPrefabs , 5f );
        }
    }
}