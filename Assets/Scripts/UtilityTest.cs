using UnityEngine;

public class UtilityTest : MonoBehaviour
{
    public Renderer renderer;
    public Color targetColor;
    public float switchTime;

    public void SwitchToColor()
    {
        ARKManager.instance.ChangeColor(renderer, targetColor, switchTime);
    }
}