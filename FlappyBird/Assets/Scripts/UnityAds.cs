using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour {


	void Start()
	{
		#if UNITY_EDITOR
		string unityAdsId = "1056489";
		#elif UNITY_ANDROID
		string unityAdsId = "1056489";
		#elif UNITY_IPHONE
		string unityAdsId = "1056490";
		#else
		string unityAdsId = "unexpected_platform";
		#endif

		Advertisement.Initialize(unityAdsId, false);
	}
}
