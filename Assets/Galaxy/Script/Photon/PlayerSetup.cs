using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject myCamera;
    public GameObject myCamvas;

    public void IsLocalPlayer(PlayerSetup mySetUp)  //RPC‚ð‚Â‚©‚¤
    {
        Debug.Log("aaaaaaaaaaaaaaaaa");
        var playerSetUps = FindObjectsOfType<PlayerSetup>();
        foreach (var setUp in playerSetUps)
        {
            if (setUp == mySetUp)
            {
                ActiveComponent();
                myCamera.SetActive(true);
            }
            else
            {
                Destroy(setUp.myCamera);
                Destroy(setUp.myCamvas);
            }
        }
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
