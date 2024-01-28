using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Cysharp.Threading.Tasks;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject waitingCamera;
    public GameObject WaitCamvas;
    public Text text;

    public Transform spawnPoint;
    [SerializeField]
    private int maxPlayer = 1;  //�����̍ő�l��

    private bool canStart = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()  //���݂��镔���Ƀ����_���ɓ���
    {
        PhotonNetwork.JoinRandomRoom();

        Debug.Log("We're in the lobby");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)  //�����ɓ���Ȃ������畔�������
    {
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayer;
        PhotonNetwork.CreateRoom(RoomNameCreator.CreateRoomName(), roomOptions, null);
    }

    public override async void OnJoinedRoom()
    {
        Debug.Log("We're connected and in a room!");

        if (PhotonNetwork.IsMasterClient)
        {
            var generator = PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Generator.name, new Vector3(0, 0, 0), Quaternion.identity);
            await generator.GetComponent<GroundGenerator>().GenerateGround(50, generator.GetComponent<PhotonView>());
            PhotonNetwork.Destroy(generator);
            SpawnPointExtension.SetPlayerSpawn();  // �n�`�̎����������o���オ�����炻���ɏ�������

            GetComponent<PhotonView>().RPC(nameof(StartGame), RpcTarget.AllBuffered);
        }

        await WaitAnotherPlayer();

        await UniTask.WaitUntil(() => canStart);
        text.text = "�X�^�[�g!";

        await WaitOneSec();
        SetUpGame();
    }

    void SetUpGame()
    {
        Destroy(WaitCamvas, 0.2f);
        Destroy(waitingCamera, 0.2f);

        var playerType = PhotonNetwork.IsMasterClient ? Player.Owner : Player.Client;
        GameObject _player = PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Player.name, SpawnPointExtension.TakeSpawnPoint(playerType), Quaternion.identity);

        PlayerSetup playerSetup = _player.GetComponent<PlayerSetup>();
        playerSetup.IsLocalPlayer(playerSetup);
    }

    //�����̐l�����ő�ɂȂ�����ҋ@�I��
    async UniTask WaitAnotherPlayer() => await UniTask.WaitUntil(() => PhotonNetwork.PlayerList.Length == maxPlayer);
    async UniTask WaitOneSec() => await UniTask.Delay(1000);

    [PunRPC]
    private void StartGame() => canStart = true;
}



public class RoomNameCreator
{
    private static int nameLength = 10;

    private static int largeA = 65;
    private static int largeZ = 90;
    private static int smallA = 97;
    private static int smallZ = 122;
    public static string CreateRoomName()
    {
        string name = "";
        for (int i = 0; i < nameLength; i++)
        {
            if (i == 0)  //1������
            {
                name += (char)Random.Range(largeA, largeZ + 1);
            }
            else
            {
                name += (char)Random.Range(smallA, smallZ + 1);
            }
        }
        Debug.Log(name);
        return name;
    }
}