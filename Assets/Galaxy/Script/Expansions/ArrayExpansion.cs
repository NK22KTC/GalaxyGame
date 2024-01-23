using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExpansion<T>
{
    public static T Random(T[] arr)
    {
        return arr[UnityEngine.Random.Range(0, arr.Length)];
    }
}
