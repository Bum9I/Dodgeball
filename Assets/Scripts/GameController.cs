using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private ColorsProvider _colorsProvider;
    [SerializeField] private CircleManager _circleManager;
    [SerializeField] private Cylinder _cylinderPrefab;
    [SerializeField] private Sphere _spherePrefab;

    private void Awake()
    {
        _circleManager.Initialize(_cylinderPrefab, _colorsProvider);
        _circleManager.Initialize(_spherePrefab, _colorsProvider);
    }
}
