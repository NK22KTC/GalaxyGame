using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearButtonPush : GameClearCondion
{
    /// <see cref="GameClearCondion.CheckClear"/> �v���C���[���{�^������������N���A


    /// <summary>
    /// �v���C���[���{�^������������N���A
    /// </summary>
    /// <see cref="GameClearCondion.UpdateClearCondion"/>
    [PunRPC]
    public override void UpdateClearCondion(PhotonView view, bool isClear)
    {
        base.UpdateClearCondion(view, isClear);
    }
}
