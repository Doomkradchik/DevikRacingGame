using UnityEngine;

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

    private void OnEnable()
    {
        carController.SpeedChanged += OnSpeedChanged;
    }

    private void OnDestroy()
    {
        carController.SpeedChanged -= OnSpeedChanged;
    }

    private void OnSpeedChanged(float currentSpeed, float maxSpeed)
    {
        var angle = Mathf.Lerp(angleParams.from, angleParams.to, currentSpeed / maxSpeed);
        arrow.rotation = Quaternion.Euler(0, 0, angle);
    }
}

