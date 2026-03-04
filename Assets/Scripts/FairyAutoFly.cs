using UnityEngine;

public class FairyFullCinematic : MonoBehaviour
{
    public Transform cameraTarget;

    public float speed = 2f;
    public float backDistance = 2f;
    public float upHeight = 6f;

    public float circleRadius = 3f;
    public float circleSpeed = 1.5f;

    int state = 0;
    Vector3 targetPos;
    float angle = 0;

    Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
        targetPos = cameraTarget.position + cameraTarget.forward * 2f;
    }

    void Update()
    {
        transform.rotation = startRotation; // ล็อคท่าทางให้ยืนตรง

        if (state == 0)
        {
            Move(targetPos);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                state = 1;
                targetPos = transform.position - transform.forward * backDistance;
            }
        }
        else if (state == 1)
        {
            Move(targetPos);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                state = 2;
                targetPos = transform.position + Vector3.up * upHeight;
            }
        }
        else if (state == 2)
        {
            Move(targetPos);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                state = 3;
                targetPos = cameraTarget.position + cameraTarget.forward * 2f;
            }
        }
        else if (state == 3)
        {
            Move(targetPos);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                state = 4;
            }
        }
        else if (state == 4)
        {
            angle += circleSpeed * Time.deltaTime;

            float x = Mathf.Cos(angle) * circleRadius;
            float z = Mathf.Sin(angle) * circleRadius;

            transform.position = cameraTarget.position + new Vector3(x, 1.5f, z);
        }
    }

    void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}