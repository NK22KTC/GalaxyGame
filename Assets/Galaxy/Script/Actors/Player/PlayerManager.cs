using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerStatusPresenter m_StatusPresenter = new PlayerStatusPresenter();
    PlayerStatePresenter StatePresenter = new PlayerStatePresenter();
    PlayerInputPresenter InputPresenter = new PlayerInputPresenter();

    [SerializeField]
    UIManager uiManager;

    public PlayerStatePresenter m_StatePresenter => StatePresenter;
    public PlayerInputPresenter m_InputPresenter => InputPresenter;

    void Start()
    {
        m_StatePresenter.OnStartPlayState();
        SetUIManager();
    }

    void Update()
    {
        PlayerStateUpdater.ChangeState(StatePresenter, InputPresenter);
        GetItem();
    }

    void SetUIManager()
    {
        uiManager = transform.GetComponentInChildren<UIManager>();
        uiManager.ShareValue(this);
        uiManager = null;
    }

    void LateUpdate()
    {

    }

    void GetItem()
    {
        var items = Physics.OverlapSphere(transform.position, 5, 2 << 9);
        if (items.Length == 0) { return; }
        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, transform.position);

        if (!nearestItem.TryGetComponent(out IFragmentable itemFragment)) { return; }

        if (InputPresenter.SwitchGetItem)
        {
            switch (itemFragment.FragmentType)
            {
                case FragmentType.Guide:
                    m_StatusPresenter.GetFlagment(1).UpdateFlagGuide();
                    break;
                case FragmentType.Light:
                    m_StatusPresenter.GetFlagment(1).UpdateFlagLight();
                    break;
                case FragmentType.Mark:
                    m_StatusPresenter.GetFlagment(1).UpdateFlagMark();
                    break;
            }
            itemFragment.DestroyItem();

            Debug.Log(m_StatusPresenter.m_StatusManager.FlagGuide);
            Debug.Log(m_StatusPresenter.m_StatusManager.FlagLight);
            Debug.Log(m_StatusPresenter.m_StatusManager.FlagMark);
        }
    }
}