using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �A�C�e���擾���Ɏg���v�Z </summary>
public static class ItemAcquisitionCalculate
{
    public static Collider GetNearestItem(Collider[] items, Vector3 playerPosition)
    {
        Collider nearestCollider = null;
        foreach (Collider item in items)
        {
            if(nearestCollider == null)
            {
                nearestCollider = item;
                continue;
            }

            if((item.transform.position - playerPosition).magnitude < (nearestCollider.transform.position - playerPosition).magnitude)
            {
                nearestCollider = item;
            }
        }
        return nearestCollider;
    }
}
