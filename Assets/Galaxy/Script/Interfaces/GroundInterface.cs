using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundGimmick
{
    /// <summary> �M�~�b�N�������������𔻒� </summary>
    bool GimmickTriggerd { get; }
    /// <summary> �M�~�b�N���N���A�������𔻒� </summary>
    bool GimmickCleard { get; }


    /// <summary> �M�~�b�N�������ɊJ�n </summary>
    void StartButtle();
    /// <summary> �M�~�b�N�N���A���ɔ��� </summary>
    void MakeWarpMaker();
}
