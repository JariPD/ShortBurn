using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    public static LockPlayer instance;

    public FirstPersonController FpsController;
    public MouseLook MouseLook;
    public Sway Sway;
    public CharacterController CharacterController;

    private void Awake()
    {
        instance = this;
    }

    public void LockAll()
    {
        FpsController.enabled = false;
        MouseLook.enabled = false;
        Sway.enabled = false;
        CharacterController.enabled = false;
    }

    public void UnlockAll()
    {
        FpsController.enabled = true;
        MouseLook.enabled = true;
        Sway.enabled = true;
        CharacterController.enabled = true;
    }
}
