using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private ScreenShake screenShake;

    public void Start()
    {
        virtualCamera.Follow = GameManager.instance.Player.transform;
        screenShake.enabled = true;
    }
}
