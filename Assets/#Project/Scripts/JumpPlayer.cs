using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpPlayer : MonoBehaviour
{
    private const string ACTION_MAP = "Player";
    private const string ACTION_JUMP = "Jump";

    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float jumpForce;
    private InputAction jump;
    private Rigidbody2D rb;

    private void Awake()
    {
        jump = inputActions.FindActionMap(ACTION_MAP).FindAction(ACTION_JUMP);
        jump.performed += ctx => { OnJump(ctx); };

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }

    private void Disable()
    {
        inputActions.FindActionMap(ACTION_MAP).Disable();
    }


    private void OnJump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
}
