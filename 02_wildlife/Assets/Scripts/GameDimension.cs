using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDimension
{
    [SerializeField]
    private float minH;
    [SerializeField]
    private float maxH;
    [SerializeField]
    private float minV;
    [SerializeField]
    private float maxV;
    public float toleranceZoneLength = 5f;

    GameDimension(Vector2 hRange, Vector2 vRange)
    {
        MinH = hRange.x;
        MaxH = hRange.y;
        MinV = vRange.x;
        maxV = vRange.y;
    }

    public float MinH { get => minH; set => minH = value; }
    public float MaxH { get => maxH; set => maxH = value; }
    public float MinV { get => minV; set => minV = value; }
    public float MaxV { get => maxV; set => maxV = value; }

    public float GetWidth()
    {
        return MaxH - MinH;
    }

    public float GetHeight()
    {
        return MaxV - MinV;
    }

}

