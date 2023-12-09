using Photon.Pun;

/// <summary> �l�b�g���[�N�I�u�W�F�N�g���擾���� </summary>
public interface INetworkObject
{
    bool DoingTransfer { get; }

    PhotonView PassPhotonView();
    /// <summary> if������TryGetComponent�Ŏ擾�A���g�����L�҂łȂ��Ȃ�out�����ϐ��ŏ��L�������N�G�X�g </summary>
    PhotonView PassPhotonView(out PhotonView view);
    /// <summary> 
    /// �l�b�g���[�N�I�u�W�F�N�g�擾�J�n����<see cref="DoingTransfer"></see> ��true�ɂ���
    /// </summary>
    void UpdateTransferSituation();
}

/// <summary> �t���O�����g�̏����擾���� </summary>
public interface IFragment : INetworkObject
{
    public FragmentType FragmentType { get; }
}

/// <summary> �U���A�C�e���̏����擾����(���u��) </summary>
public interface IItem : INetworkObject
{

}