using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour {

	void OnMouseDown ()
    {
        print("click leaderboard mouse down");
        // show leaderboard UI
        //Social.ShowLeaderboardUI();
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_iwf);
    }
}
