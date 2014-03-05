#pragma strict
var publisherId : String = "pub-4848628447185232";
var refreshRate : float = 60.0;
var testDevice : String = "test_device_code_here";
function Start () {
    AdBannerObserver.Initialize(publisherId, testDevice, refreshRate);
}
