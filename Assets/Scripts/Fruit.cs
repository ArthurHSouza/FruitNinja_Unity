using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject cutedFruit;
    private int pointsAdded;

    private void Awake()
    {
        if(gameObject.name.Contains("Banana",System.StringComparison.OrdinalIgnoreCase))
        {
            pointsAdded = 1;
        }
        else if(gameObject.name.Contains("Orange", System.StringComparison.OrdinalIgnoreCase))
        {
            pointsAdded = 2;
        }
        else
        {
            pointsAdded = 3;
        }
    }
    private void CutFruit()
    {
        GameObject newCutedFruit = Instantiate(cutedFruit, transform.position, transform.rotation);
        Rigidbody[] newCutedFruitBody = newCutedFruit.GetComponentsInChildren<Rigidbody>();

        Destroy(gameObject);

        FindObjectOfType<GameManager>().UpdateScore(pointsAdded);

        foreach (Rigidbody body in newCutedFruitBody)
        {
            body.transform.rotation = Random.rotation;
            body.AddExplosionForce(Random.Range(500,700), newCutedFruit.transform.position, 5f);
        }
        Destroy(newCutedFruit,5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blade")
        {
            CutFruit();
        }
    }
}
