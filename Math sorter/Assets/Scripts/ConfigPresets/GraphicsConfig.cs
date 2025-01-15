using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Configs/GraphicsConfig", order = 1)]
public class GraphicsConfig : ScriptableObject
{
    [SerializeField] private List<Sprite> _graphics = new List<Sprite>();

    public IReadOnlyList<Sprite> Graphics => _graphics;
}
