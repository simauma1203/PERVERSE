using UnityEngine;
using System.Collections;

public class HandheldUtil
{

#if UNITY_ANDROID
    private static AndroidJavaObject unityPlayer = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
    private static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>( "currentActivity" );

    private static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService","vibrator");

    public static void Initialize()
    {
        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
    }
    public static void Destruct()
    {
        vibrator.Dispose();

        currentActivity.Dispose();
        unityPlayer.Dispose();
    }
#else
    public static void Initialize() {
    }
    public static void Destruct() {
    }
#endif

    // vibrate
#if UNITY_ANDROID
    public static void vibrate(long msec)
    {
        vibrator.Call("vibrate", msec);
    }
#else
    public static void vibrate(long msec) {
    }
#endif
}