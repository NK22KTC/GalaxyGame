using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject myCamera;
    public GameObject myCamvas;

    public void IsLocalPlayer(PlayerSetup mySetUp)  //RPC‚ð‚Â‚©‚¤
    {
        ActiveComponent();
        myCamera.SetActive(true);
        myCamvas.SetActive(true);
    }

    void ActiveComponent()
    {
        if (!TryGetComponent(out PlayerManager manager))
        {
            manager = gameObject.AddComponent<PlayerManager>();
        }
        if (!TryGetComponent(out PlayerController controller))
        {
            controller = gameObject.AddComponent<PlayerController>();
        }

        manager.m_Camera = myCamera;
    }

    public void DestroyPlayerConponent(PlayerSetup setUp)
    {
        Destroy(setUp.GetComponent<PlayerManager>());
        Destroy(setUp.GetComponent<PlayerController>());
    }
}
