using Photon.Pun;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public  Vector3 m_Position => transform.position;

    [SerializeField]
    private Player spawnPlayer;
    public Player m_SpawnPlayer => spawnPlayer;

    public void SetSpawnPlayerType(int player) => GetComponent<PhotonView>().RPC(nameof(SetSpawnPlayer), RpcTarget.AllBuffered, player);

    [PunRPC]
    private void SetSpawnPlayer(int player) => spawnPlayer = (Player)player;
}

public class SpawnPointExtension
{
    private static SpawnPoint[] GetSpawnPoints()
    {
        return GameObject.FindObjectsOfType<SpawnPoint>();
    }

    public static Vector3 TakeSpawnPoint(Player player)
    {
        var items = GetSpawnPoints();

        if (items[0].m_SpawnPlayer == player)
        {
            return items[0].m_Position;
        }
        else
        {
            return items[1].m_Position;
        }
    }

    public static void SetPlayerSpawn()
    {
        var items = GetSpawnPoints();
        var randomSpawn = Random.Range(0, items.Length);

        for(int i = 0; i < items.Length; i++)
        {
            if(i == randomSpawn)
            {
                items[i].SetSpawnPlayerType((int)Player.Owner);
            }
            else
            {
                items[i].SetSpawnPlayerType((int) Player.Client);
            }
        }
    }
}

public enum Player
{
    Owner,
    Client
}