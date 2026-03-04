using UnityEngine;

public class CameraFollowFairy : MonoBehaviour
{
    public Transform fairy;
    public float rotateSpeed = 3f;

    void Update()
    {
        Vector3 direction = fairy.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotateSpeed * Time.deltaTime
        );
    }
}