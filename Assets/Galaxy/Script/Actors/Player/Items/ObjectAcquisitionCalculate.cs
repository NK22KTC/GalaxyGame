using UnityEngine;

/// <summary> �I�u�W�F�N�g�擾���Ɏg���v�Z </summary>
public static class ObjectAcquisitionCalculate
{
    /// <summary> ��������ԋ߂��I�u�W�F�N�g��Ԃ� </summary>
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
