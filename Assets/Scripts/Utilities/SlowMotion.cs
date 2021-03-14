using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 10f;

    void Update()
    {
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void SlowDown()
    {
        Debug.Log("Slow down");
        Time.timeScale = slowDownFactor; // timeScale slows down by 1/factor 
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

    }
}

