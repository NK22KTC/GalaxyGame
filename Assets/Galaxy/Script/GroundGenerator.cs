using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;

public struct VectorXZ
{
    public VectorXZ(int X, int Z)
    {
        x = X;
        z = Z;
    }

    public int x;
    public int z;
}

public class GroundGenerator : MonoBehaviour
{
    //(10, 10) ���� (990, 990) �܂ŁA�Ԋu��(70,70) �Őݒu����

    private static List<GameObject> generateGrounds = new List<GameObject>();
    private static List<VectorXZ> generatePosz = new List<VectorXZ>();
    private static List<int> generatePoses = new List<int>();

    //���[�v���������������璼��
    private const int minPos = 10; 
    private const int maxPos = 310;
    private const int interval = 20;

    //�u����n�ʂ̍ő�l�ƍŏ��l�A�ŏ��l�̓v���C���[�̐�+1��
    private const int maxPut = 225;
    private const int minPut = 3;

    public async Task GenerateGround(int maxGenerateNum, PhotonView view)
    {
        if(maxGenerateNum > maxPut) { maxGenerateNum = maxPut; }
        else if(maxGenerateNum < minPut) { maxGenerateNum = minPut; }

        for(int i = minPos; i <= maxPos; i += interval)
        {
            generatePoses.Add(i);
        }
        int generateNum = 0;

        while (generateNum < maxGenerateNum)  //�n�ʂ̐�������ʒu�����߂�
        {
            var adding = true;
            var vec = new VectorXZ(generatePoses[Random.Range(0, generatePoses.Count - 1)], generatePoses[Random.Range(0, generatePoses.Count - 1)]);

            foreach (var addedVec in generatePosz)
            {
                if (addedVec.x != vec.x) { continue; }
                if (addedVec.z != vec.z) { continue; }
                adding = false;
                break;
            }
            if (!adding) { continue; }

            generatePosz.Add(vec);
            generateNum++;
        }

        for(int i = 0; i < generatePosz.Count; i++)
        {
            await Task.Delay(10);  //�������d���Ȃ�Ȃ��悤��
            PuttingGround(generatePosz[i].x, generatePosz[i].z);
        }
        generatePosz = null;

        SetWarpCooperation(null, null);
    }

    private void PuttingGround(int posX, int posZ)
    {
        var ground = PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Planet.name,
                                  new Vector3(posX, 0, posZ),
                                  new Quaternion(1.0f, 0, 0, 0)
                                  );

        generateGrounds.Add(ground);
    }

    private async void SetWarpCooperation(GameObject initPoint1, GameObject initPoint2)  //���[�v�ʒu����
    {
        if (initPoint1 == null)
        {
            initPoint1 = generateGrounds[Random.Range(0, generateGrounds.Count)];

            initPoint1.GetComponent<GroundManager>().SetInitialPoint().CreateSpawnPoint().SetSpawnPlayerType((int)Player.Owner);
        }
        if(initPoint2 == null)
        {
            while (true)
            {
                initPoint2 = generateGrounds[Random.Range(0, generateGrounds.Count)];
                Debug.Log(initPoint2.name);
                if (initPoint1 == initPoint2) { continue; }
                initPoint2.GetComponent<GroundManager>().SetInitialPoint().CreateSpawnPoint().SetSpawnPlayerType((int)Player.Client);

                break;
            }
        }

        

        await Task.Delay(10);

        //SetWarpCooperation(initPoint1, initPoint2);
    }
}
