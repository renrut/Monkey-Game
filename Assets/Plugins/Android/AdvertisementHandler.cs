using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IAdmobCallback
{
    void OnFailedToReceiveAdCallback(string a_message, string a_errorCode);
    void OnPresentScreenCallback(string a_message);
    void OnDismissScreenCallback(string a_message);
    void OnLeaveApplicationCallback(string a_message);
    void OnReceiveAdCallback(string a_message);
}

public class AdvertisementHandler : MonoBehaviour
{

    static string TagType = "AdmobPlugin :::: ";

    public enum AdvSize
    {
        BANNER,
        IAB_BANNER,
        IAB_MRECT,
        IAB_LEADERBOARD,
        SMART_BANNER,
        InterstitialAd
    };

    public enum AdvOrientation
    {
        VERTICAL,
        HORIZONTAL
    };

    public enum Position
    {
        NO_GRAVITY = 0,
        CENTER_HORIZONTAL = 1,
        LEFT = 3,
        RIGHT = 5,
        FILL_HORIZONTAL = 7,
        CENTER_VERTICAL = 16,
        CENTER = 17,
        TOP = 48,
        BOTTOM = 80,
        FILL_VERTICAL = 112
    };

    public enum AnimationInType
    {
        SLIDE_IN_LEFT, 
        FADE_IN,
        NO_ANIMATION
    };

    public enum AnimationOutType
    {
        SLIDE_OUT_RIGHT,
        FADE_OUT,
        NO_ANIMATION
    };

    public enum LevelOfDebug
    {
        NONE,
        LOW,
        HIGH,
        FLOOD
    }

    static AndroidJavaClass admobPluginClass;
    static AndroidJavaClass unityPlayer;
    static AndroidJavaObject currActivity;

    /// <summary>
    /// Callback listner interface list
    /// </summary>
    static List<IAdmobCallback> m_callbackListnerList;
    static List<IAdmobCallback> Listners
    {
        get { return m_callbackListnerList; }
        set { m_callbackListnerList = value; }
    }

    /// <summary>
    /// game object name to call for callback, IMPORTANT, IF YOU WANT CALLBACK FROM PLUGIN
    /// </summary>
    static string currGameObjectName = string.Empty;

    void Start()
    {
        currGameObjectName = gameObject.name;
    }

    /// <summary>
    /// Initializing Plugin with values
    /// </summary>
    /// <param name="pubID">Admob App ID</param>
    /// <param name="advSize">Advertisement Size</param>
    /// <param name="advOrient">Advertisement Orientation</param>
    /// <param name="position_1">Advertisement First Position</param>
    /// <param name="position_2">Advertisement Second Position</param>
    /// <param name="isTesting">Flag for testing game/app</param>
    /// <param name="testDeviceId">Test Device Id</param>
    /// <param name="animIn">Animation IN Type</param>
    /// <param name="animOut">Animation OUT Type</param>
    /// <param name="levelOfDebug">Debug Level</param>
    public static void Instantiate(string pubID, /*bool isTesting, string testDeviceId,*/ LevelOfDebug levelOfDebug)
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
	        Debug.Log(TagType + "Instantiate Called");
	        admobPluginClass = new AndroidJavaClass("com.microeyes.admob.AdmobActivity");
	        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	        currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	        admobPluginClass.CallStatic("Initialize", currActivity, pubID, /*isTesting, testDeviceId,*/ currGameObjectName, (int) levelOfDebug);
	        Debug.Log(TagType + "Instantiate FINISHED");
		#endif
    }

    public static void CreateNewAdv(string identifier, AdvSize advSize, AdvOrientation advOrient, Position position_1, Position position_2, AnimationInType animIn, AnimationOutType animOut)
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log(TagType + "CreateNewAdv Called");

        admobPluginClass.CallStatic("CreateNewAdv", identifier, (int)advSize, (int)advOrient, (int)position_1, (int)position_2, (int)animIn, (int)animOut);
       

        Debug.Log(TagType + "CreateNewAdv FINISHED");
		#endif
    }

    /// <summary>
    /// Enable Advertisements, work if not yet called / after calling DisableAdvs();
    /// </summary>
    public static void EnableAds(string identifier)
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log(TagType + "ENABLED Called");
        admobPluginClass.CallStatic("EnableAdv", identifier);
        Debug.Log(TagType + "ENABLED FINISHED");    
		#endif
    }

    /// <summary>
    /// Disable Advertisements, Call EnableAds() to start again
    /// ShowAds() won't work here.
    /// </summary>
    public static void DisableAds(string identifier)
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log(TagType + "DISABLED Called");
        admobPluginClass.CallStatic("DisableAdv", identifier);
        Debug.Log(TagType + "DISABLED FINISHED"); 
		#endif
    }

    /// <summary>
    /// Temp Hide Advertisements, Call Show() to show again
    /// EnableAds() won't work here
    /// </summary>
    public static void HideAds(string identifier)
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log(TagType + "HIDE ADV Called");
        admobPluginClass.CallStatic("HideAdv", identifier);
        Debug.Log(TagType + "HIDE ADV FINISHED");
		#endif
    }

    /// <summary>
    /// Show Advertisements, work after EnableAds() already called
    /// </summary>
    public static void ShowAds(string identifier)
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log(TagType + "SHOW ADV Called");
        admobPluginClass.CallStatic("ShowAdv", identifier);
        Debug.Log(TagType + "SHOW ADV FINISHED");
		#endif
    }

    public static void RegisterCallback(IAdmobCallback a_callback)
    {

        Debug.Log(TagType + "Request registering callback");
        if (Listners == null)
        {
            Debug.Log(TagType + "Admob Callback Listner list was NULL. Now initialized");
            Listners = new List<IAdmobCallback>();
        }
        else if (currGameObjectName.Equals(string.Empty))
        {
            Debug.LogError(TagType + "Current GameObject Name is empty. Please attach this script to any game object");
            return;
        }

        Listners.Add(a_callback);
        Debug.Log(TagType + "Registered callback");
    }

    public static void UnregisterCallback(IAdmobCallback a_callback)
    {
        Debug.Log(TagType + "Request unregistering callback");
        if (Listners == null)
        {
            Debug.LogError(TagType + " callback listener is null. Intialize please or register any callback");
            return;
        }
        else if(Listners.Count == 0)
        {
            Debug.LogError(TagType + " No callback listener registered");
            return;
        }
        
        Listners.Remove(a_callback);
        Debug.Log(TagType + "Unregistered callback");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Exiting Admob test App");
            Application.Quit();
        }
    }

    #region Callback from Admob Plugin

    public void OnReceiveAd(string a_advId)
    {
        Debug.Log(TagType + "Admob Callback - OnReceiveAd: " + a_advId);

        if (Listners != null && Listners.Count > 0)
        {
            for (int l_callbackIndex = 0; l_callbackIndex < Listners.Count; l_callbackIndex++)
            {
                if (Listners[l_callbackIndex] == null)
                {
                    Debug.Log(TagType + "one of callback listner is null");
                }
                else
                {
                    Listners[l_callbackIndex].OnReceiveAdCallback(a_advId);
                }
            }
        }

    }

    /// <summary>
    /// Called when an ad was not received
    /// </summary>
    /// <param name="a_data">Contains Error message</param>
    public void OnFailedToReceiveAd(string a_data)
    {
        Debug.Log(TagType + "Admob Callback - OnFailedToReceiveAd: " + a_data);

        string[] l_arrData = a_data.Split('<');
        string l_advId = l_arrData[0];
        string l_errorCode = l_arrData[1];

        if (Listners != null && Listners.Count > 0)
        {
            for (int l_callbackIndex = 0; l_callbackIndex < Listners.Count; l_callbackIndex++)
            {
                if (Listners[l_callbackIndex] == null)
                {
                    Debug.Log(TagType + "one of callback listener is null");
                }
                else
                {
                    Listners[l_callbackIndex].OnFailedToReceiveAdCallback(a_data, l_errorCode);
                }
            }
        }
    }

    /// <summary>
    /// Called when an Activity is created in front of the app
    /// </summary>
    /// <param name="a_advId">Contains empty message</param>
    public void OnPresentScreen(string a_advId)
    {
        Debug.Log(TagType + "Admob Callback - OnPresentScreen: " + a_advId);

        if (Listners != null && Listners.Count > 0)
        {
            for (int l_callbackIndex = 0; l_callbackIndex < Listners.Count; l_callbackIndex++)
            {
                if (Listners[l_callbackIndex] == null)
                {
                    Debug.Log(TagType + "one of callback listner is null");
                }
                else
                {
                    Listners[l_callbackIndex].OnPresentScreenCallback(a_advId);
                }
            }
        }
    }

    /// <summary>
    /// Called when an ad is clicked and about to return to the application
    /// </summary>
    /// <param name="a_advId">Contains empty message</param>
    public void OnDismissScreen(string a_advId)
    {
        Debug.Log(TagType + "Admob Callback - OnDismissScreen: " + a_advId);

        if (Listners != null && Listners.Count > 0)
        {
            for (int l_callbackIndex = 0; l_callbackIndex < Listners.Count; l_callbackIndex++)
            {
                if (Listners[l_callbackIndex] == null)
                {
                    Debug.Log(TagType + "one of callback listner is null");
                }
                else
                {
                    Listners[l_callbackIndex].OnDismissScreenCallback(a_advId);
                }
            }
        }
    }

    /// <summary>
    /// Called when an ad is clicked and going to start a new Activity that will leave the application
    /// </summary>
    /// <param name="a_advId">Contains empty message</param>
    public void OnLeaveApplication(string a_advId)
    {
        Debug.Log(TagType + "Admob Callback - OnLeaveApplication: " + a_advId);

        if (Listners != null && Listners.Count > 0)
        {
            for (int l_callbackIndex = 0; l_callbackIndex < Listners.Count; l_callbackIndex++)
            {
                if (Listners[l_callbackIndex] == null)
                {
                    Debug.Log(TagType + "one of callback listner is null");
                }
                else
                {
                    Listners[l_callbackIndex].OnLeaveApplicationCallback(a_advId);
                }
            }
        }
    }

    #endregion
}
