using UnityEngine;

/// <summary> オブジェクト取得時に使う計算 </summary>
public static class ObjectAcquisitionCalculate
{
    /// <summary> 距離が一番近いオブジェクトを返す </summary>
    public static Collider GetNearestObject(Collider[] items, Vector3 playerPosition)
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
