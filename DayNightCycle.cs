using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float _lightRotationSpeed = 0.01f;

    private void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(0f, _lightRotationSpeed, 0f * Time.deltaTime) ;

    }
}