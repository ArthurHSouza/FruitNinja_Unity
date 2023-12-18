using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        body.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
