using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject bomb;
    public Transform[] spawnersPosition;
    void Start()
    {
        StartCoroutine(SpawFruits());
    }

    private IEnumerator SpawFruits()
    {
        //Randomize
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 1f));
            Transform newTransform = spawnersPosition[Random.Range(0, spawnersPosition.Length)];

            GameObject newObject;

            if(Random.Range(0,100) < 30)
            {
                newObject = Instantiate(bomb, newTransform);
            }
            else 
            {
                newObject = Instantiate(fruits[Random.Range(0, fruits.Length)], newTransform);
            }

            newObject.GetComponent<Rigidbody2D>().AddForce(newTransform.up * Random.Range(10f,25f), ForceMode2D.Impulse);
            Destroy(newObject, 4f);
        }
    }
}
