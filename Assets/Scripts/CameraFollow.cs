using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    
    [SerializeField]
    private Transform player1, player2;
    public float  smoothSpeed = 0.125f;
    public Vector3 offset;

   void FixedUpdate()
   {
       Vector3 interpolated = Vector3.Lerp(player1.position, player2.position, 0.5f);
       transform.position = new Vector3(
           transform.position.x, transform.position.y, interpolated.z);
      // Vector3 desiredPosition = target.position + offset;
      // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
       //transform.position = smoothedPosition;

       transform.LookAt(target);
   }

}
