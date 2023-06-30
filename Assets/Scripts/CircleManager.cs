using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CircleManager : MonoBehaviour
{
    [SerializeField]
    private Transform _plane;

    public void Initialize(Cylinder cylinderPrefab, ColorsProvider colorsProvider)
    {
        for (int i = 0; i < 6; i++)
        {
            var cylinder = Instantiate(cylinderPrefab, _plane.position, Quaternion.identity, _plane);

            cylinder.Initialize(colorsProvider.GetColor());
        }
    }

    public void Initialize(Sphere spherePrefab, ColorsProvider colorsProvider)
    {
        var cylinder = Instantiate(spherePrefab, _plane.position, Quaternion.identity, _plane);
        
        cylinder.Initialize(colorsProvider);
    }
}