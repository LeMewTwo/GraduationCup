using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text timerText;

    private float secondCount;
    private int minuteCount;

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        secondCount += Time.deltaTime;
        timerText.text = minuteCount + "m:" + (int)secondCount + "s";
        if (secondCount >= 60)
        {
            minuteCount++;
            secondCount = 0;
        }
        else if (minuteCount >= 60)
        {
            minuteCount = 0;
        }
    }
}
