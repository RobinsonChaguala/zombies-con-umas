using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Networking.Transport.Relay;
using Mirror;
using UnityTransport = Mirror.Transports.UnityTransport.UnityTransport;

public class RelayManager : MonoBehaviour
{
    public static RelayManager Instance;
    private UnityTransport transport;

    private async void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        await UnityServices.InitializeAsync();
        transport = NetworkManager.singleton.GetComponent<UnityTransport>();
    }

    public async void StartRelayHost()
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(4);
        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        RelayServerData relayData = new RelayServerData(allocation, "dtls");
        transport.SetRelayServerData(relayData);

        Debug.Log("Código Relay: " + joinCode);

        NetworkManager.singleton.StartHost();
    }

    public async void StartRelayClient(string joinCode)
    {
        JoinAllocation allocation =
            await RelayService.Instance.JoinAllocationAsync(joinCode);

        RelayServerData relayData = new RelayServerData(allocation, "dtls");
        transport.SetRelayServerData(relayData);

        NetworkManager.singleton.StartClient();
    }
}
