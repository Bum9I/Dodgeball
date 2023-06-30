using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private ColorsProvider _colorsProvider;
    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        var renderer = GetComponent<Renderer>();
        renderer.material.color = _colorsProvider.GetColor();
        transform.position = GetRandomPosition();
    }

    public void ChangeColorAndMove()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = _colorsProvider.GetColor();
        transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-7f, 7f);
        float randomZ = Random.Range(-7f, 7f);
        
        return new Vector3(randomX, 0.5f, randomZ);
    }
    
}