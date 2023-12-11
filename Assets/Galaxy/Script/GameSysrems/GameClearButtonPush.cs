using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearButtonPush : GameClearCondion
{
    /// <see cref="GameClearCondion.CheckClear"/> プレイヤーがボタンを押したらクリア


    /// <summary>
    /// プレイヤーがボタンを押したらクリア
    /// </summary>
    /// <see cref="GameClearCondion.UpdateClearCondion"/>
    [PunRPC]
    public override void UpdateClearCondion(int view, bool isClear)
    {
        base.UpdateClearCondion(view, isClear);
    }
}
