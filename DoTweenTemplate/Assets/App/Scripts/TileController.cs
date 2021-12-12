using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    //the end of tile where other tile joins
    public Transform endPoint;

    //movement speed of tile.
    public float speed;

    //the z position where tile will go when resetting
    public float resetPosition;

    GameObject randomCollectible;

    [Space]

    #region CollectibleSpawnControl

    [SerializeField] private GameObject[] collectiblePrefabs;

    [SerializeField] private Vector2[] randomCollectibleSpawnPoints;

    #endregion
    private void MoveTile()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (transform.position.z >= resetPosition)
        {
            GamePlayManager.instance.ChangeParent();
        }
    }

    public void SpawnCollectible()
    {
        if (GamePlayManager.instance.gamePlayState != GamePlayStates.Gaming)
        {
            return;
        }

        if (randomCollectible != null)
        {
            Destroy(randomCollectible.gameObject);
        }

        //This variable is used to increase spawn randomness of obstacles.
        int randomnessGenerator = Random.Range(0, 11);

        Debug.Log(randomnessGenerator);

        if (randomnessGenerator%2!=0)
        {
            return;
        }

        //This is the index of random collectible.
        int randomCollectibleIndex = Random.Range(0, collectiblePrefabs.Length);

        //and this is the index of random position of collectible.
        int randomCollectiblePosIndex = Random.Range(0, randomCollectibleSpawnPoints.Length);

        Vector3 randomPosition = randomCollectibleSpawnPoints[randomCollectiblePosIndex];

        //The length of our board is 10 unit.
        //randomPosition.z = Random.Range(-10, 0);

        randomCollectible = Instantiate(collectiblePrefabs[randomCollectibleIndex], transform);

        randomCollectible.transform.localPosition = randomPosition;

    }


  


 
}
