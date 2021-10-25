using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private Transform player1, player2;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (GameManager.instance.isGameScene())
        {
            Vector3 interpolated = Vector3.Lerp(new Vector2(player1.position.x, 0), new Vector2(player2.position.x, 0), 0.5f);
            transform.position = new Vector3(
                transform.position.x, 3.3f, 3.64f);

            Vector3 desiredPosition = interpolated + offset;
            if(target)
            {
                desiredPosition = target.position + offset;
            }
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition + offset;

            //transform.LookAt(desiredPosition);
        }
    }

}
