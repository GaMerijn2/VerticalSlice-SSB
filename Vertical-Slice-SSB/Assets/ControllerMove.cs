using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerContols controls;
    Vector2 move;

    void Awake()
    {
        controls = new PlayerContols();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx1 => move = Vector2.zero;
    }

    private void Update()
    {

        Vector2 m = new Vector2(move.x, move.y);
        transform.Translate(m, Space.World);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
