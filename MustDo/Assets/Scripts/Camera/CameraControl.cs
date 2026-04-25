using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    private InputAction rightClick;
    private InputAction scrollAction;

    [Header("Movement Settings")]
    public float moveSpeed = 0.5f;
    public float smoothness = 5f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    private Vector3 targetPosition;
    private Vector3 lastMousePosition;
    private Camera cam;
    private float targetZoom;

    private void Awake()
    {
        // ดึง Action จาก Input System (ตรวจสอบชื่อให้ตรงกับใน Input Actions Asset)
        rightClick = InputSystem.actions.FindAction("RightClick");
        scrollAction = InputSystem.actions.FindAction("ScrollWheel"); // ปกติชื่อนี้ใน Default Actions
    }

    void Start()
    {
        cam = GetComponent<Camera>();
        targetPosition = transform.position;
        targetZoom = cam.orthographic ? cam.orthographicSize : transform.position.y;
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();

        // Smooth Movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothness);
    }

    void HandleMovement()
    {
        // จังหวะเริ่มกด
        if (rightClick.WasPressedThisFrame())
        {
            lastMousePosition = Mouse.current.position.ReadValue();
        }

        // จังหวะกำลังกดค้างและลาก (เปลี่ยนเป็น IsPressed)
        if (rightClick.IsPressed())
        {
            Vector3 currentMousePos = Mouse.current.position.ReadValue();
            Vector3 delta = currentMousePos - lastMousePosition;

            // คำนวณทิศทาง (2.5D: ลากเมาส์ X/Y -> ขยับกล้อง X/Z)
            Vector3 move = new Vector3(-delta.x, 0, -delta.y) * moveSpeed * 0.01f;

            targetPosition += move;
            lastMousePosition = currentMousePos;
        }
    }

    void HandleZoom()
    {
        // อ่านค่า Scroll จาก Input System ตัวใหม่
        float scroll = 0;
        if (scrollAction != null)
        {
            scroll = scrollAction.ReadValue<Vector2>().y * 0.01f;
        }
        else
        {
            // Fallback ถ้าหา Action ไม่เจอ
            scroll = Mouse.current.scroll.ReadValue().y * 0.01f;
        }

        if (scroll != 0)
        {
            targetZoom -= scroll * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }

        if (cam.orthographic)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * smoothness);
        }
        else
        {
            targetPosition.y = Mathf.Lerp(targetPosition.y, targetZoom, Time.deltaTime * smoothness);
        }
    }
}