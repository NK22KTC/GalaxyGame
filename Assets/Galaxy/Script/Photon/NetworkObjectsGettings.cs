using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> アイテムのレイヤー </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> <see cref="INetworkObject"/>を継承したinterfaceの取得を試す,取得できたらnetworkObjectで返す </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T networkObject) where T : INetworkObject
    {
        //初期値(null)を代入する
        networkObject = default;

        ///プレイヤー中心,半径が ObtainableDistance の球体で,itemLayer で判定をとるレイヤーを制限する
        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        //itemLayer のオブジェクトがあれば続ける
        if (items.Length == 0) { return false; }


        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, m_PlayerManager.transform.position);
        //INetworkObjectを継承していたら続ける(いらんけど, itemLayer に指定したオブジェクトが INetworkObject を継承してなかったらバグるから置いとく)
        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }

        networkObject = netObj;
        return true;
    }

    private static async UniTask<PhotonView> GetFlagment(PlayerManager m_PlayerManager, IFragment itemFragment)
    {
        //自分が所有しているネットワークオブジェクトかを取得
        if (!itemFragment.PassPhotonView(out PhotonView view).IsMine)
        {
            //自分のでないなら所有権をリクエストする
            view.RequestOwnership();
            //自身に所有権が移るまで待機
            await UniTask.WaitUntil(() => view.Owner == m_PlayerManager.GetComponent<PhotonView>().Owner);
        }
        return view;
    }

    private static void DestroyNetObj(PhotonView view)
    {
        PhotonNetwork.Destroy(view);
    }

    /// <summary> フラグメント以外のアイテムが出てきたら、switch文に変えたい </summary>
    public static async void GetFlagmentProcess(PlayerManager manager)  //相手が所有するネットワークオブジェクトの取得がエラーなしで成功するのが最初の1回しかない
    {
        if (!TryGetNetObject(manager, out IFragment flagment)) { return; }  //フラグメント
        var view = await GetFlagment(manager, flagment);
        manager.m_StatusPresenter.GetFlagment(1).UpdateFlag(flagment.FragmentType);
        DestroyNetObj(view);
    }
}
