using UnityEngine;

public class WindArrowController : MonoBehaviour
{
    public WindEffector windEffector; // Reference to the WindEffector script
    private void Start()
    {
        gameObject.SetActive(true); // Set the arrow active at the start
        UpdateArrowRotation(); // Update arrow rotation once it becomes active
        Debug.Log("Arrow GameObject is activated"); // Log a message for debugging
    }
    private void Update()
    {
        UpdateArrowRotation();
    }

private void UpdateArrowRotation()
{
    if (windEffector != null)
    {
        float windAngle = windEffector.GetForceAngle();
        float adjustedAngle = windAngle - 90; // Adjust the angle based on your arrow's default orientation
        transform.eulerAngles = new Vector3(0, 0, adjustedAngle);
    }
}
}