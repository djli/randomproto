using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AreaEffector2D))]
public class WindEffector : MonoBehaviour
{
    [Header("Force Magnitude Settings")]
    public float minForceMagnitude = 0f;
    public float maxForceMagnitude = 10f;
    public float timeBetweenMagnitudeChanges = 2f;

    [Header("Force Angle Settings")]
    public float minForceAngle = 0f;
    public float maxForceAngle = 360f;
    public float timeBetweenAngleChanges = 3f;

    private AreaEffector2D areaEffector;

    private void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();

        StartCoroutine(RandomizeMagnitude());
        StartCoroutine(RandomizeAngle());
    }

    private IEnumerator RandomizeMagnitude()
    {
        while (true)
        {
            float randomMagnitude = Random.Range(minForceMagnitude, maxForceMagnitude);
            areaEffector.forceMagnitude = randomMagnitude;
            yield return new WaitForSeconds(timeBetweenMagnitudeChanges);
        }
    }

    private IEnumerator RandomizeAngle()
    {
        while (true)
        {
            float randomAngle = Random.Range(minForceAngle, maxForceAngle);
            areaEffector.forceAngle = randomAngle;
            yield return new WaitForSeconds(timeBetweenAngleChanges);
        }
    }

private void OnGUI()
{
    GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
    labelStyle.fontSize = 70; // Font size for the label text. Adjust as necessary.
    labelStyle.normal.textColor = Color.white; // Set text color to white
    
    GUIStyle numberStyle = new GUIStyle(GUI.skin.label);
    numberStyle.fontSize = 90; // Larger font size for the number. Adjust as necessary.
    numberStyle.normal.textColor = Color.white; // Set text color to white

    // Display the "Force Magnitude:" label with smaller text
    GUI.Label(new Rect(10, 10, 800, 90), "Force Magnitude:", labelStyle);
    
    // Display the force magnitude number with larger text
    GUI.Label(new Rect(10, 100, 800, 100), areaEffector.forceMagnitude.ToString("F2"), numberStyle);
}

    private string GetDirectionFromAngle(float angle)
    {
        if (angle >= 337.5f || angle < 22.5f) return "N";
        if (angle >= 22.5f && angle < 67.5f) return "NE";
        if (angle >= 67.5f && angle < 112.5f) return "E";
        if (angle >= 112.5f && angle < 157.5f) return "SE";
        if (angle >= 157.5f && angle < 202.5f) return "S";
        if (angle >= 202.5f && angle < 247.5f) return "SW";
        if (angle >= 247.5f && angle < 292.5f) return "W";
        if (angle >= 292.5f && angle < 337.5f) return "NW";
        return "";
    }
    public float GetForceAngle()
    {
        return areaEffector.forceAngle;
    }

}