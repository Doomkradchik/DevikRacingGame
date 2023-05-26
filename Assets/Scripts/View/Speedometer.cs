using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private RectTransform arrow;
    [SerializeField] private AngleParams angleParams;

    [System.Serializable]
    public struct AngleParams
    {
        public float from;
        public float to;
    }

    private void Update()
    {
        OnSpeedChanged(carController.CurrentSpeed, carController.MaxSpeed);
    }


    private void OnSpeedChanged(float currentSpeed, float maxSpeed)
    {
        var angle = Mathf.Lerp(angleParams.from, angleParams.to, currentSpeed / maxSpeed);
        arrow.rotation = Quaternion.Euler(0, 0, angle);
    }
}

