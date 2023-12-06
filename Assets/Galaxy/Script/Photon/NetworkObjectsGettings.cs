using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> アイテムのレイヤー </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> <see cref="INetWorkObject"/>を継承したinterfaceの取得を試す,取得できたらnetworkObjectで返す </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T networkObject) where T : INetWorkObject
    {
        //初期値(null)を代入する
        networkObject = default;

        ///プレイヤー中心,半径が ObtainableDistance の球体で,<see cref="itemLayer">で判定をとるレイヤーを制限する
        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        if (items.Length == 0) { return false; }

        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, m_PlayerManager.transform.position);

        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }

        networkObject = netObj;
        return true;
    }

    private static async UniTask<PhotonView> GetFlagment(PlayerStatusPresenter m_StatusPresenter, IFragment itemFragment)
    {
        m_StatusPresenter.GetFlagment(1).UpdateFlag(itemFragment.FragmentType);  //責務的にこれは別に移した方がいい

        //自分が所有しているネットワークオブジェクトかを取得
        if (!itemFragment.PassPhotonView(out PhotonView view).IsMine)
        {
            //自分のでないなら所有権をリクエストする
            view.RequestOwnership();
            //リクエストが承認されるまで待つ
            await UniTask.WaitUntil(() => itemFragment.OwnershipTransfered);
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
        if (!TryGetNetObject(manager, out IFragment flagment)) { return; }
        var view = await GetFlagment(manager.m_StatusPresenter, flagment);
        DestroyNetObj(view);
    }
}
