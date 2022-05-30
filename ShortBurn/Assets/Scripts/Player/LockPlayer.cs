using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    public static LockPlayer instance;

    public FirstPersonController fpsController;
    public MouseLook mouseLook;
    public Sway sway;
    private void Awake()
    {
        instance = this;
    }
}
