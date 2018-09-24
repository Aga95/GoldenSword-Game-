using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    private float dayCycleSpeed;

    void Start()
    {
        dayCycleSpeed = 0.05f;    
    }
    
    void Update ()
    {
        transform.Rotate(Vector3.right, dayCycleSpeed);
	}
}
