using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPart", menuName = "Part")]
public class Part : ScriptableObject
{
    public enum Class
    {
        None,
        AICore,
        Element,     
    }

    public string DisplayName => string.IsNullOrWhiteSpace(displayName) ? name : displayName;
    [Header("Display Attributes")]
    [SerializeField]
    private string displayName;
    [TextArea(1, 3)]
    public string description;
    public Sprite itemGraphic;
    [Header("Gameplay Attributes")]
    public Class partClass;
    public List<string> attributes;
}
