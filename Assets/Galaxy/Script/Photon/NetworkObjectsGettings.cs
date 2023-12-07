using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> �A�C�e���̃��C���[ </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> <see cref="INetworkObject"/>���p������interface�̎擾������,�擾�ł�����networkObject�ŕԂ� </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T networkObject) where T : INetworkObject
    {
        //�����l(null)��������
        networkObject = default;

        ///�v���C���[���S,���a�� ObtainableDistance �̋��̂�,itemLayer �Ŕ�����Ƃ郌�C���[�𐧌�����
        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        //itemLayer �̃I�u�W�F�N�g������Α�����
        if (items.Length == 0) { return false; }


        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, m_PlayerManager.transform.position);
        //INetworkObject���p�����Ă����瑱����(����񂯂�, itemLayer �Ɏw�肵���I�u�W�F�N�g�� INetworkObject ���p�����ĂȂ�������o�O�邩��u���Ƃ�)
        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }

        networkObject = netObj;
        return true;
    }

    private static async UniTask<PhotonView> GetFlagment(PlayerManager m_PlayerManager, IFragment itemFragment)
    {
        //���������L���Ă���l�b�g���[�N�I�u�W�F�N�g�����擾
        if (!itemFragment.PassPhotonView(out PhotonView view).IsMine)
        {
            //�����̂łȂ��Ȃ珊�L�������N�G�X�g����
            view.RequestOwnership();
            //���g�ɏ��L�����ڂ�܂őҋ@
            await UniTask.WaitUntil(() => view.Owner == m_PlayerManager.GetComponent<PhotonView>().Owner);
        }
        return view;
    }

    private static void DestroyNetObj(PhotonView view)
    {
        PhotonNetwork.Destroy(view);
    }

    /// <summary> �t���O�����g�ȊO�̃A�C�e�����o�Ă�����Aswitch���ɕς����� </summary>
    public static async void GetFlagmentProcess(PlayerManager manager)  //���肪���L����l�b�g���[�N�I�u�W�F�N�g�̎擾���G���[�Ȃ��Ő�������̂��ŏ���1�񂵂��Ȃ�
    {
        if (!TryGetNetObject(manager, out IFragment flagment)) { return; }  //�t���O�����g
        var view = await GetFlagment(manager, flagment);
        manager.m_StatusPresenter.GetFlagment(1).UpdateFlag(flagment.FragmentType);
        DestroyNetObj(view);
    }
}
