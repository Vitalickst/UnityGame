using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

    public void ShowRewardedAd() {
        if (Advertisement.IsReady("rewardedVideo")) {
            var options = new ShowOptions {
                resultCallback = HandleShowResult
            };

            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                GameManager.Instance.Player.AddGems(100);
                UIManager.Instance.OpenShop(GameManager.Instance.Player.Diamonds);
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
}
