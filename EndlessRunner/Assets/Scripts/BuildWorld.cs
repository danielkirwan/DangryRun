using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWorld : MonoBehaviour
{

    public Transform floorTile;
    private Vector3 floorTileSpawn;


    // Start is called before the first frame update
    void Start()
    {
        floorTileSpawn.z = -2.65f;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        //spawn 1st floor
        Instantiate(floorTile, floorTileSpawn, floorTile.rotation);
        floorTileSpawn.z += -2.95f;
        //spawn 2nd floor
        Instantiate(floorTile, floorTileSpawn, floorTile.rotation);
        floorTileSpawn.z += -2.95f;
        StartCoroutine(spawnTile());
    }


}
