using UnityEngine;
using System.Collections;

public class AdvertisementManager : MonoBehaviour, IAdmobCallback {

    Rect rect = new Rect();
    void OnGUI()
    {
        //DrawBannerAdvs();
        //DrawInterstitialAds();
    }

    void DrawBannerAdvs()
    {
        rect.x = 20;
        rect.y = 40;
        
        rect.width = Screen.width * 0.2f;
        rect.height = Screen.height * 0.1f;
        // Make the Enable Button
        if (GUI.Button(rect, "Enable banner"))
        {
            Debug.Log("Enabled");
            AdvertisementHandler.EnableAds("Mic_1");
        }

        rect.y = rect.y + rect.height;
        if (GUI.Button(rect, "Disable banner"))
        {
            Debug.Log("Disable");
            AdvertisementHandler.DisableAds("Mic_1");
        }

        rect.y = rect.y + rect.height;
        // Make the Hide Button
        if (GUI.Button(rect, "Hide banner"))
        {
            AdvertisementHandler.HideAds("Mic_1");
        }

        rect.y = rect.y + rect.height;
        // Make the Show button.
        if (GUI.Button(rect, "Show banner"))
        {
            AdvertisementHandler.ShowAds("Mic_1");
        }
    }

    void DrawInterstitialAds()
    {
        
        rect.width = Screen.width * 0.2f;
        rect.height = Screen.height * 0.1f;

        rect.x = Screen.width - rect.width - 20;
        rect.y = 40;

        // Make the Enable Button
        if (GUI.Button(rect, "Enable Interstitial"))
        {
            Debug.Log("Enabled");
            AdvertisementHandler.EnableAds("Mic_2");
        }

        rect.y = rect.y + rect.height;
        if (GUI.Button(rect, "Disable Interstitial"))
        {
            Debug.Log("Disable");
            AdvertisementHandler.DisableAds("Mic_2");
        }

        rect.y = rect.y + rect.height;
        // Make the Hide Button
        if (GUI.Button(rect, "Hide Interstitial"))
        {
            AdvertisementHandler.HideAds("Mic_2");
        }

        rect.y = rect.y + rect.height;
        // Make the Show button.
        if (GUI.Button(rect, "Show Interstitial"))
        {
            AdvertisementHandler.ShowAds("Mic_2");
        }
    }


    /// <summary>
    /// Admob publisher App Id
    /// </summary>
    [SerializeField]
	private string m_publisherId = "pub-4848628447185232";
    public string PublisherId
    {
        get { return m_publisherId; }
        set { m_publisherId = value; }
    }

    /// <summary>
    /// Advertisement Size
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AdvSize m_advSize = AdvertisementHandler.AdvSize.SMART_BANNER;
    public AdvertisementHandler.AdvSize AdvSize
    {
        get { return m_advSize; }
        set { m_advSize = value; }
    }

    /// <summary>
    /// Advertisement Orientation
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AdvOrientation m_orientation = AdvertisementHandler.AdvOrientation.HORIZONTAL;
    public AdvertisementHandler.AdvOrientation Orientation
    {
        get { return m_orientation; }
        set { m_orientation = value; }
    }

    /// <summary>
    /// Advertisement First Position
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.Position m_positionOne = AdvertisementHandler.Position.BOTTOM;
    public AdvertisementHandler.Position PositionOne
    {
        get { return m_positionOne; }
        set { m_positionOne = value; }
    }


    /// <summary>
    /// Advertisement Second Position
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.Position m_positionTwo = AdvertisementHandler.Position.CENTER_HORIZONTAL;
    public AdvertisementHandler.Position PositionTwo
    {
        get { return m_positionTwo; }
        set { m_positionTwo = value; }
    }

    /// <summary>
    /// Set True, if testing game/app
    /// </summary>
    /*[SerializeField]
    private bool m_isTesting = false;
    public bool IsTesting
    {
        get { return m_isTesting; }
        set { m_isTesting = value; }
    }
    
    /// <summary>
    /// Test Device Id, if you know
    /// </summary>
    [SerializeField]
    private string m_testDeviceId = "4965DFB7E2F16194A15150C45A6927A9";
    public string TestDeviceId
    {
        get { return m_testDeviceId; }
        set { m_testDeviceId = value; }
    }*/

    /// <summary>
    /// Animation Type when loading new Advertisement
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AnimationInType m_animationInType = AdvertisementHandler.AnimationInType.SLIDE_IN_LEFT;
    public AdvertisementHandler.AnimationInType AnimationInType
    {
        get { return m_animationInType; }
        set { m_animationInType = value; }
    }

    /// <summary>
    /// Animation Type when unloading current/old Advertisement
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AnimationOutType m_animationOutType = AdvertisementHandler.AnimationOutType.FADE_OUT;
    public AdvertisementHandler.AnimationOutType AnimationOutType
    {
        get { return m_animationOutType; }
        set { m_animationOutType = value; }
    }
    
    /// <summary>
    /// Level of debug logs
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.LevelOfDebug m_levelOfDebug = AdvertisementHandler.LevelOfDebug.LOW;
    public AdvertisementHandler.LevelOfDebug LevelOfDebug
    {
        get { return m_levelOfDebug; }
        set { m_levelOfDebug = value; }
    }


	// Use this for initialization
	void Start () {
        Debug.Log("Unity Calling Start");
        Debug.Log("Initializing with " + 
            "  Pub ID: " + m_publisherId +
            "  Adv Size: " + m_advSize +
            "  Orientation: " + m_orientation +
            "  Position 1: " + m_positionOne +
            "  Position 2: " + m_positionTwo +
            //"  IsTesting: " + m_isTesting +
            //"  DeviceID: " + m_testDeviceId + 
            "  AnimIn: " + m_animationInType +
            "  AnimOut: " + m_animationOutType +
            "  LevelOfDebug: " + m_levelOfDebug
            );

        //Initializing Plugin with values
        AdvertisementHandler.Instantiate(m_publisherId, /*m_isTesting, m_testDeviceId,*/ m_levelOfDebug);
        AdvertisementHandler.CreateNewAdv("Mic_1", m_advSize, m_orientation, m_positionOne, m_positionTwo, m_animationInType, m_animationOutType);
        //Shoot request to enable advertisements
        AdvertisementHandler.EnableAds("Mic_1");

        //Registering for callback to implemented interface
        AdvertisementHandler.RegisterCallback(this);
	}

    public void OnReceiveAdCallback(string a_message)
    {
        Debug.Log("Received OnReceiveAd callback");
    }

    public void OnFailedToReceiveAdCallback(string a_message, string a_errorCode)
    {
        Debug.Log("Received OnFailedToReceiveAd callback");
    }

    public void OnPresentScreenCallback(string a_message)
    {
        Debug.Log("Received OnPresentScreen callback");
    }

    public void OnDismissScreenCallback(string a_message)
    {
        Debug.Log("Received OnDismissScreen callback");
    }

    public void OnLeaveApplicationCallback(string a_message)
    {
        Debug.Log("Received OnLeaveApplication callback");
    }
}
