using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public void Initialize(Color color)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = color;

        transform.position = GetRandomPosition();
    }
    
    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-7f, 7f);
        float randomZ = Random.Range(-7f, 7f);
        
        return new Vector3(randomX, 1, randomZ);
    }
}
