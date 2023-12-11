using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearAssembly : GameClearCondion
{
    /// <see cref="GameClearCondion.CheckClear"/> 自身の周囲〇メートル以内にプレイヤーがいたらクリア


    /// <summary>
    /// 自身の周囲〇メートル以内にプレイヤーがいたらクリア
    /// </summary>
    /// <see cref="GameClearCondion.UpdateClearCondion"/>
    [PunRPC]
    public override void UpdateClearCondion(int view, bool isClear)
    {
        base.UpdateClearCondion(view, isClear);
    }
}
