using Photon.Pun;


/// <summary> 所有者を変更する </summary>
public interface ITransfer
{
    bool OwnershipTransfered { get; }
}

/// <summary> ネットワークオブジェクトを取得する </summary>
public interface INetWorkObject
{
    /// <summary> if文内でTryGetComponentで取得、自身が所有者でないならoutした変数で所有権をリクエスト </summary>
    PhotonView PassPhotonView(out PhotonView view);
}

/// <summary> フラグメントの情報を取得する </summary>
public interface IFragment : INetWorkObject, ITransfer
{
    public FragmentType FragmentType { get; }
}

public interface IItem : INetWorkObject, ITransfer
{

}