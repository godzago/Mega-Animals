using AppsFlyerSDK;
using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAController : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, UIManager.level.ToString());
        AppsFlyer.sendEvent("LevelFail", new Dictionary<string, string>(UIManager.level));
    }
}
