using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> アイテムのレイヤー </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> <see cref="INetworkObject"/>を継承したitemの取得を試す,取得できたらnetworkObjectで返す </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T networkObject) where T : INetworkObject
    {
        //初期値(null)を代入する
        networkObject = default;

        ///プレイヤー中心,半径が ObtainableDistance の球体で,itemLayer で判定をとるレイヤーを制限する
        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        //itemLayer のオブジェクトがあれば続ける
        if (items.Length == 0) { return false; }


        var nearestItem = ObjectAcquisitionCalculate.GetNearestObject(items, m_PlayerManager.transform.position);
        //INetworkObjectを継承していたら続ける
        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }
        //既に取得しようとしているネットワークオブジェクトが取得開始されていなければ続ける
        if(netObj.DoingTransfer) { return false; }

        networkObject = netObj;
        networkObject.UpdateTransferSituation();
        return true;
    }

    /// <summary> 
    /// 取得しようとしているアイテムの所有者が自身になるまで待機
    /// </summary>
    /// <remarks>
    /// アイテムの所有者が自身になったら再度処理を開始する
    /// </remarks>
    /// <returns> フラグメントのPhotonViewを返す </returns>
    public static async UniTask<PhotonView> CheckOwner(PlayerManager m_PlayerManager, INetworkObject netObj)
    {
        //自分が所有しているネットワークオブジェクトかを判別
        if (!netObj.PassPhotonView(out PhotonView view).IsMine)
        {
            //自分のでないなら所有権をリクエストする
            view.RequestOwnership();
            //自身に所有権が移るまで待機
            await UniTask.WaitUntil(() => view.Owner == m_PlayerManager.GetComponent<PhotonView>().Owner);
        }
        return view;
    }

    /// <summary> フラグメント以外のアイテムが出てきたら、switch文に変えたい </summary>
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
