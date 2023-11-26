using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public float desiredHeight;
    public float roamRadius;
    private Vector3 originPosition;
    private Vector3 randomPosition;
    
    void Start()
    {
        originPosition = transform.position;
        randomPosition = GetRandomPosition();
    }
    
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit))
        {
            float terrainHeight = hit.point.y;
            transform.position = new Vector3(transform.position.x, terrainHeight + desiredHeight, transform.position.z);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);

        RotateTowards(randomPosition);

        // Kiểm tra xem đã đến vị trí ngẫu nhiên chưa
        if (Vector3.Distance(transform.position, randomPosition) < 0.1f)
        {
            // Nếu đã đến, chọn một vị trí ngẫu nhiên mới
            randomPosition = GetRandomPosition();
        }
    }

    void RotateTowards(Vector3 target)
    {
        // Xác định hướng di chuyển
        Vector3 direction = (target - transform.position).normalized;

        // Tính toán góc quay để đối tượng hướng về hướng di chuyển
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Tạo ra một quaternions để quay đối tượng
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        // Áp dụng quay đối tượng
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }

    Vector3 GetRandomPosition()
    {
        // Tạo một vị trí ngẫu nhiên trong bán kính roamRadius
        float randomX = Random.Range(-roamRadius, roamRadius);
        float randomZ = Random.Range(-roamRadius, roamRadius);

        if (Mathf.Abs(randomX) < 7) {
            randomX = 7;
        }

        if (Mathf.Abs(randomZ) < 7) {
            randomZ = 7;
        }

        // Tạo một Vector3 mới với vị trí ngẫu nhiên
        Vector3 randomPosition = new Vector3(originPosition.x + randomX, originPosition.y, originPosition.z + randomZ);

        return randomPosition;
    }
}