using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundGimmick
{
    /// <summary> ギミックが発動したかを判定 </summary>
    bool GimmickTriggerd { get; }
    /// <summary> ギミックをクリアしたかを判定 </summary>
    bool GimmickCleard { get; }


    /// <summary> ギミック発動時に開始 </summary>
    void StartButtle();
    /// <summary> ギミッククリア時に発動 </summary>
    void MakeWarpMaker();
}
