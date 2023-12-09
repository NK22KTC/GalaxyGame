using Photon.Pun;

/// <summary> ネットワークオブジェクトを取得する </summary>
public interface INetworkObject
{
    bool DoingTransfer { get; }

    PhotonView PassPhotonView();
    /// <summary> if文内でTryGetComponentで取得、自身が所有者でないならoutした変数で所有権をリクエスト </summary>
    PhotonView PassPhotonView(out PhotonView view);
    /// <summary> 
    /// ネットワークオブジェクト取得開始時に<see cref="DoingTransfer"></see> をtrueにする
    /// </summary>
    void UpdateTransferSituation();
}

/// <summary> フラグメントの情報を取得する </summary>
public interface IFragment : INetworkObject
{
    public FragmentType FragmentType { get; }
}

/// <summary> 攻撃アイテムの情報を取得する(仮置き) </summary>
public interface IItem : INetworkObject
{

}