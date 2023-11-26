using UnityEngine;

public class CursorControl : MonoBehaviour
{
    private void Start()
    {
        // Ẩn con trỏ chuột khi chạy game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Kiểm tra sự kiện để hiển thị hoặc ẩn con trỏ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorVisibility();
        }
    }

    private void ToggleCursorVisibility()
    {
        // Đảo ngược trạng thái con trỏ và hiển thị hoặc ẩn nó
        Cursor.visible = !Cursor.visible;

        // Đảo ngược trạng thái lockMode để cho phép hoặc ngăn chặn di chuyển con trỏ chuột
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
    }
}