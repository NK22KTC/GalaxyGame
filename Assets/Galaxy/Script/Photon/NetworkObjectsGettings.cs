using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;

public static class NetworkObjectsGettings
{
    /// <summary> アイテムのレイヤー </summary>
    private static readonly LayerMask itemLayer = 2 << 9;

    /// <summary> ネットワークオブジェクトの取得を試す,取得できたらnetWorkObjectで返す </summary>
    private static bool TryGetNetObject<T>(PlayerManager m_PlayerManager, out T netWorkObject) where T : INetWorkObject
    {
        //初期値(null)を代入する
        netWorkObject = default;

        var items = Physics.OverlapSphere(m_PlayerManager.transform.position, GeneralSettings.Instance.m_PlayerSettings.ObtainableDistance, itemLayer);
        if (items.Length == 0) { return false; }

        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, m_PlayerManager.transform.position);

        if (!nearestItem.TryGetComponent(out T netObj)) { return false; }

        netWorkObject = netObj;
        return true;
    }

    private static async UniTask<PhotonView> GetFlagment(PlayerStatusPresenter m_StatusPresenter, IFragment itemFragment)
    {
        m_StatusPresenter.GetFlagment(1).UpdateFlag(itemFragment.FragmentType);

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
        Debug.Log("afterTime : " + Time.time);
        PhotonNetwork.Destroy(view);
    }

    /// <summary> フラグメント以外のアイテムが出てきたら、switch文に変えたい </summary>
    public static async void GetFlagmentProcess(PlayerManager manager)  //相手が所有するネットワークオブジェクトの取得がエラーなしで成功するのが最初の1回しかない
    {
        if (!TryGetNetObject(manager, out IFragment flagment)) { return; }
        Debug.Log("beforeTime : " + Time.time);
        var view = await GetFlagment(manager.m_StatusPresenter, flagment);
        await UniTask.WaitForSeconds(0.02f);
        DestroyNetObj(view);
    }
}
