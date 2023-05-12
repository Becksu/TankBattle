using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ColorTypeData", fileName ="Data/ColorTypeData",order =1)]
public class ColorTypeData : ScriptableObject
{
    public Material[] colors;
}

