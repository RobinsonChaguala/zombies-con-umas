using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }

    public void StartSolo()
    {
        StartHost();
        SceneManager.LoadScene("Game");
    }

    public void StartDirectHost()
    {
        networkAddress = "localhost";
        StartHost();
        SceneManager.LoadScene("Game");
    }

    public void StartDirectClient(string address)
    {
        networkAddress = address;
        StartClient();
    }
}

