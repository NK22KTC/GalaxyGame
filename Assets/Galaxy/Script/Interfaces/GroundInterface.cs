using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundGimmick
{
    /// <summary> �M�~�b�N�������������𔻒� </summary>
    bool m_GimmickTriggerd { get; }
    /// <summary> �M�~�b�N���N���A�������𔻒� </summary>
    bool m_GimmickCleard { get; }


    /// <summary> �M�~�b�N�������ɊJ�n </summary>
    void StartButtle();
    /// <summary> �M�~�b�N�N���A���ɔ��� </summary>
    void MakeWarpMarker();
}
