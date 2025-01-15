using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Item", menuName = "Level/Level Item", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] private ExampleData[] _examples;

    public ExampleData[] Examples => _examples;
}
