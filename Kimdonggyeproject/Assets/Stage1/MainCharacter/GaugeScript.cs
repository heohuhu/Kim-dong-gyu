using UnityEngine;
using UnityEngine.UI;

public class GaugeScript : MonoBehaviour
{
    public Slider gaugeSlider;
    public float fillSpeed = 1f;       // 게이지 차오르는 속도
    public float drainSpeed = 2f;      // 키를 떼었을 때 줄어드는 속도
    private float currentValue = 0f;
    private bool isPressing = false;

    void Update()
    {
        isPressing = Input.GetKey(KeyCode.Space);

        if (isPressing)
        {
            currentValue += fillSpeed * Time.deltaTime;
        }
        else
        {
            currentValue -= drainSpeed * Time.deltaTime;
        }

        currentValue = Mathf.Clamp(currentValue, 0f, gaugeSlider.maxValue);
        gaugeSlider.value = currentValue;
    }
}
