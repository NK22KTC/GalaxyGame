using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearAssembly : GameClearCondion
{
    /// <see cref="GameClearCondion.CheckClear"/> ���g�̎��́Z���[�g���ȓ��Ƀv���C���[��������N���A


    /// <summary>
    /// ���g�̎��́Z���[�g���ȓ��Ƀv���C���[��������N���A
    /// </summary>
    /// <see cref="GameClearCondion.UpdateClearCondion"/>
    [PunRPC]
    public override void UpdateClearCondion(int view, bool isClear)
    {
        base.UpdateClearCondion(view, isClear);
    }
}
