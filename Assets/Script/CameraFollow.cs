using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Dito ilalagay ang Player
    public float smoothSpeed = 0.125f; // Kung gaano ka-smooth ang sunod (0 to 1)
    public Vector3 offset; // Distance ng camera sa player

    void Start()
    {
        // Kusa nating kukunin ang offset base sa current position nila sa Scene
        // Make sure na naka-position na nang maayos ang camera bago i-play
        offset = transform.position - target.position;
    }

    void LateUpdate() // LateUpdate ang gamit para sigurado na tapos na gumalaw ang player bago sumunod ang camera
    {
        if (target != null)
        {
            // Ito ang gusto nating puntahan ng camera
            Vector3 desiredPosition = target.position + offset;

            // Ang Lerp ay nagbibigay ng smooth transition mula sa current position papunta sa desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // I-apply ang position
            transform.position = smoothedPosition;
        }
    }
}
