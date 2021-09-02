using UnityEngine;
using UnityEngine.InputSystem;


public class ArrowTouchMovement : MonoBehaviour
{
    private Camera _mainCamera;

    private Vector3 targetPos;
    private bool moving = false;
    [SerializeField] private float forwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Move();
    }

    private void ProcessInput()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            return;
        }

        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        Debug.Log("Touch position" + touchPos);

        Ray worldPosRay = _mainCamera.ScreenPointToRay(touchPos);
        Debug.Log("World Position" + worldPosRay);
        RaycastHit hit;
        if (Physics.Raycast(worldPosRay, out hit, 1000))
        {
            targetPos = hit.point;
            moving = true;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        if (moving)
        {
            transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z);
            if (transform.position.x == targetPos.x)
            {
                moving = false;
            }
        }
    }
}