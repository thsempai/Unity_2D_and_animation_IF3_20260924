using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private const string ACTION_MAP = "Player";
    private const string ACTION_MOVE = "Move";

    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float speed;
    private InputAction move;

    private bool isOnMove = false;

    private void Awake()
    {
        move = inputActions.FindActionMap(ACTION_MAP).FindAction(ACTION_MOVE);
        move.started += ctx => { OnMoveStart(ctx); };
        move.canceled += ctx => { OnMoveCancel(ctx); };
    }

    private void OnMoveCancel(InputAction.CallbackContext ctx)
    {
        isOnMove = false;
    }

    private void OnMoveStart(InputAction.CallbackContext ctx)
    {
        isOnMove = true;
    }

    private void Update()
    {
        if (isOnMove)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 mvt = Time.deltaTime * speed * move.ReadValue<float>() * Vector2.right;
        transform.Translate(mvt);
    }

    private void OnEnable()
    {
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap(ACTION_MAP).Disable();
    }


}
