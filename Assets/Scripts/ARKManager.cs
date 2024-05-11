using System.Collections;
using UnityEngine;

public class ARKManager : MonoBehaviour
{
    public static ARKManager instance { get; private set; }
    public ARKLogger arkLogger;

    public bool isLoggingEnabled = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            arkLogger = new ARKLogger();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Changes the color of renderer's material to given color in given switch time
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="targetColor"></param>
    /// <param name="switchTime"></param>
    public void ChangeColor(Renderer renderer, Color targetColor, float switchTime)
    {
        arkLogger.Debug("[ARKManager] ChangeColor: Changing to given color");
        StartCoroutine(ChangeRoutine(renderer, targetColor, switchTime));
    }

    private IEnumerator ChangeRoutine(Renderer renderer, Color targetColor, float switchTime)
    {
        Color startColor = renderer.material.color;
        float elapsedTime = 0f;

        while (elapsedTime < switchTime)
        {
            float t = elapsedTime / switchTime;
            renderer.material.color = Color.Lerp(startColor, targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final color is exactly the target color
        renderer.material.color = targetColor;
    }
}