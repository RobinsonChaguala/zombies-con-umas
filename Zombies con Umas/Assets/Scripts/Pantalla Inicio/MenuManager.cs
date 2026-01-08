using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField ipInput;
    public InputField relayCodeInput;

    public void JugarSolo()
    {
        FindObjectOfType<CustomNetworkManager>().StartSolo();
    }

    public void JugarConAmigosUN()
    {
        RelayManager.Instance.StartRelayHost();
    }

    public void UnirseConAmigosUN()
    {
        RelayManager.Instance.StartRelayClient(relayCodeInput.text);
    }

    public void JugarConAmigosTunel()
    {
        FindObjectOfType<CustomNetworkManager>()
            .StartDirectClient(ipInput.text);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
