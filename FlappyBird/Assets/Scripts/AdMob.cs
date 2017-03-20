using UnityEngine;
using GoogleMobileAds.Api;
public class AdMob : MonoBehaviour {

    BannerView bannerView = null; // 배너 출력
    void Start()
    {
		#if UNITY_EDITOR
			string adUnitId = "unused";
		#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-2778546304304506/2355311671";
		#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-2778546304304506/8600747675";
		#else
			string adUnitId = "unexpected_platform";
		#endif

        // BannerView(애드몹 사이트에 등록된 아이디, 크기, 위치) / AdSize.SmartBanner : 화면 해상도에 맞게 늘임, AdPosition.Bottom : 화면 바닥에 붙음
		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // 애드몹 리퀘스트 초기화
        AdRequest request = new AdRequest.Builder().Build();
        //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        //.AddTestDevice("내 디바이스 아이디")  // My test device.


        bannerView.LoadAd(request); //배너 광고 요청
        bannerView.Show();  // 배너 광고 출력 
    }
}
