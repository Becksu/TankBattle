using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ColorType
{
    Blue,
    Green,
    Red,
    Violet,
    Yeallow,
    None
}
public class ColorObject : MonoBehaviour
{
    public Renderer[] meshrender = new Renderer[7];
    public ColorType colorType;

    public Material GetMaterial()
    {
        
        int random = Random.Range(0, 5);
        colorType = SetColor(random);
        Material material = LevelManager.Instance.colorData.colors[random];
        return material;
    }

    public ColorType SetColor(int i)
    {
        switch (i)
        {
            case 0:
                return ColorType.Blue;
            case 1:
                return ColorType.Green;
            case 2:
                return ColorType.Red;
            case 3:
                return ColorType.Violet;
            case 4:
                return ColorType.Yeallow;
            default:
                return ColorType.None;
        }

    }
}
