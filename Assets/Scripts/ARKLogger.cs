public class ARKLogger 
{
    public void Debug(string message)
    {
        if (ARKManager.instance.isLoggingEnabled)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}