using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> �A�C�e���̃��C���[ </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> <see cref="INetWorkObject"/>���p������interface�̎擾������,�擾�ł�����networkObject�ŕԂ� </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T networkObject) where T : INetWorkObject
    {
        //�����l(null)��������
        networkObject = default;

        ///�v���C���[���S,���a�� ObtainableDistance �̋��̂�,<see cref="itemLayer">�Ŕ�����Ƃ郌�C���[�𐧌�����
        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        if (items.Length == 0) { return false; }

        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, m_PlayerManager.transform.position);

        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }

        networkObject = netObj;
        return true;
    }

    private static async UniTask<PhotonView> GetFlagment(PlayerStatusPresenter m_StatusPresenter, IFragment itemFragment)
    {
        m_StatusPresenter.GetFlagment(1).UpdateFlag(itemFragment.FragmentType);  //�Ӗ��I�ɂ���͕ʂɈڂ�����������

        //���������L���Ă���l�b�g���[�N�I�u�W�F�N�g�����擾
        if (!itemFragment.PassPhotonView(out PhotonView view).IsMine)
        {
            //�����̂łȂ��Ȃ珊�L�������N�G�X�g����
            view.RequestOwnership();
            //���N�G�X�g�����F�����܂ő҂�
            await UniTask.WaitUntil(() => itemFragment.OwnershipTransfered);
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
        if (!TryGetNetObject(manager, out IFragment flagment)) { return; }
        var view = await GetFlagment(manager.m_StatusPresenter, flagment);
        DestroyNetObj(view);
    }
}
