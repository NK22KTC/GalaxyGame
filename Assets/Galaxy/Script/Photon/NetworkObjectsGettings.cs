using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> �A�C�e���̃��C���[ </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> <see cref="INetworkObject"/>���p������item�̎擾������,�擾�ł�����networkObject�ŕԂ� </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T networkObject) where T : INetworkObject
    {
        //�����l(null)��������
        networkObject = default;

        ///�v���C���[���S,���a�� ObtainableDistance �̋��̂�,itemLayer �Ŕ�����Ƃ郌�C���[�𐧌�����
        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        //itemLayer �̃I�u�W�F�N�g������Α�����
        if (items.Length == 0) { return false; }


        var nearestItem = ObjectAcquisitionCalculate.GetNearestObject(items, m_PlayerManager.transform.position);
        //INetworkObject���p�����Ă����瑱����
        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }
        //���Ɏ擾���悤�Ƃ��Ă���l�b�g���[�N�I�u�W�F�N�g���擾�J�n����Ă��Ȃ���Α�����
        if(netObj.DoingTransfer) { return false; }

        networkObject = netObj;
        networkObject.UpdateTransferSituation();
        return true;
    }

    /// <summary> 
    /// �擾���悤�Ƃ��Ă���A�C�e���̏��L�҂����g�ɂȂ�܂őҋ@
    /// </summary>
    /// <remarks>
    /// �A�C�e���̏��L�҂����g�ɂȂ�����ēx�������J�n����
    /// </remarks>
    /// <returns> �t���O�����g��PhotonView��Ԃ� </returns>
    public static async UniTask<PhotonView> CheckOwner(PlayerManager m_PlayerManager, INetworkObject netObj)
    {
        //���������L���Ă���l�b�g���[�N�I�u�W�F�N�g���𔻕�
        if (!netObj.PassPhotonView(out PhotonView view).IsMine)
        {
            //�����̂łȂ��Ȃ珊�L�������N�G�X�g����
            view.RequestOwnership();
            //���g�ɏ��L�����ڂ�܂őҋ@
            await UniTask.WaitUntil(() => view.Owner == m_PlayerManager.GetComponent<PhotonView>().Owner);
        }
        return view;
    }

    /// <summary> �t���O�����g�ȊO�̃A�C�e�����o�Ă�����Aswitch���ɕς����� </summary>
    public static async UniTask<INetworkObject> GetNetworkObject(PlayerManager manager)
    {
        if (!TryGetNetObject(manager, out INetworkObject netObj)) { return null; }
        var view = await CheckOwner(manager, netObj);

        if (view.TryGetComponent(out IFragment flag))
        {
            return flag;
        }
        else if(view.TryGetComponent(out IGameButton button))
        {
            return button;
        }
        return null;
    }
}
