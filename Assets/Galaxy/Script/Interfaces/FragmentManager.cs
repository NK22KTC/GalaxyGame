using Photon.Pun;


/// <summary> ���L�҂�ύX���� </summary>
public interface ITransfer
{
    //bool OwnershipTransfered { get; }
}

/// <summary> �l�b�g���[�N�I�u�W�F�N�g���擾���� </summary>
public interface INetworkObject
{
    /// <summary> if������TryGetComponent�Ŏ擾�A���g�����L�҂łȂ��Ȃ�out�����ϐ��ŏ��L�������N�G�X�g </summary>
    PhotonView PassPhotonView(out PhotonView view);
}

/// <summary> �t���O�����g�̏����擾���� </summary>
public interface IFragment : INetworkObject, ITransfer
{
    public FragmentType FragmentType { get; }
}

public interface IItem : INetworkObject, ITransfer
{

}