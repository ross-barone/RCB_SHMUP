using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputController : MonoBehaviour
{
    [SerializeField] MovementController movementController;
    [SerializeField] CollisionHandler collisionManager;
    [SerializeField] Vector3 inputDirection = Vector3.zero;

    //called to handle all player movement input
    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.SetDirection(context.ReadValue<Vector2>());
    }

    //
    public void OnShoot(InputAction.CallbackContext context)
    {
        bool x = collisionManager.isAABB;
        collisionManager.isAABB = !x;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
