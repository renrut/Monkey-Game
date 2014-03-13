using UnityEngine;

// Example script showing how you can easily call into the GoogleMobileAdsPlugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour {

    void Start()
    {
		print("Started");
		GoogleMobileAdsPlugin.CreateBannerView("ca-app-pub-4848628447185232/7141493905",
		                                       GoogleMobileAdsPlugin.AdSize.SmartBanner,
                                               true);
        print("Created Banner View");
		GoogleMobileAdsPlugin.RequestBannerAd(true);
        print("Requested Banner Ad");
		GoogleMobileAdsPlugin.ShowBannerView();
    }

    void OnEnable()
    {
		print("Registering for AdMob Events");
		GoogleMobileAdsPlugin.ReceivedAd += HandleReceivedAd;
		GoogleMobileAdsPlugin.FailedToReceiveAd += HandleFailedToReceiveAd;
		GoogleMobileAdsPlugin.ShowingOverlay += HandleShowingOverlay;
		GoogleMobileAdsPlugin.DismissedOverlay += HandleDismissedOverlay;
		GoogleMobileAdsPlugin.LeavingApplication += HandleLeavingApplication;
    }

    void OnDisable()
    {
        print("Unregistering for AdMob Events");
		GoogleMobileAdsPlugin.ReceivedAd -= HandleReceivedAd;
		GoogleMobileAdsPlugin.FailedToReceiveAd -= HandleFailedToReceiveAd;
		GoogleMobileAdsPlugin.ShowingOverlay -= HandleShowingOverlay;
		GoogleMobileAdsPlugin.DismissedOverlay -= HandleDismissedOverlay;
		GoogleMobileAdsPlugin.LeavingApplication -= HandleLeavingApplication;
    }

    public void HandleReceivedAd()
    {
        print("HandleReceivedAd event received");
    }

    public void HandleFailedToReceiveAd(string message)
    {
        print("HandleFailedToReceiveAd event received with message:");
        print(message);
    }

    public void HandleShowingOverlay()
    {
        print("HandleShowingOverlay event received");
    }

    public void HandleDismissedOverlay()
    {
        print("HandleDismissedOverlay event received");
    }

    public void HandleLeavingApplication()
    {
        print("HandleLeavingApplication event received");
    }
}