using Cysharp.Threading.Tasks;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GroundGenerator
{
    private static Vector3 minimumPos = new Vector3(10, 0, 10);
    private static Vector3 maximumPos = new Vector3(990, 0, 990);

    public static void GenerateGround()
    {
        //Vector3 のx,z にはランダムで値が入る、y にはパーリンノイズで生成した値が入る
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Planet.name, new Vector3(0, 0, 0), Quaternion.identity); 
    }

    public static async UniTask<List<Vector3>> CreatePositions(int generateNum)
    {
        List<Vector3> positions = new List<Vector3>();
        int i = 0;

        return positions;
        //return await UniTask.WaitUntil(() =>
        //{

        //    //while (i <= generateNum)
        //    //{





        //    //    i++;
        //    //}

            
        //});
    } 
}
