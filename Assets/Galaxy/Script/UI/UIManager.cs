using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    PlayerManager m_PlayerManager;

    [SerializeField]
    GameObject menuDisplay;

    public bool isActiveMenu => menuDisplay.activeSelf;

    // Start is called before the first frame update
    void Start()
    {
        menuDisplay.SetActive(false);
    }

    public void ShareValue(PlayerManager PlayerManager)
    {
        m_PlayerManager = PlayerManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInputPresenter.SwitchMenu)
        {
            menuDisplay.SetActive(!menuDisplay.activeSelf);
            SetCursor();

            PlayerGameState newState = menuDisplay.activeSelf ? PlayerGameState.OpeningMenu : PlayerGameState.Operating;
            m_PlayerManager.m_StatePresenter.ChangeGameState(newState);
        }
    }

    private bool IsLocked => Cursor.lockState == CursorLockMode.Locked;
    private void SetCursor()
    {
        Cursor.lockState = IsLocked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = menuDisplay.activeSelf;
    }
}
