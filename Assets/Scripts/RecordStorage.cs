using System.Collections;
using UnityEngine;

public class RecordStorage : MonoBehaviour
{
    [SerializeField]
    private ProgressCalculate P1;
    [SerializeField]
    private ProgressCalculate P2;
    [SerializeField]
    private Distance D1;
    [SerializeField]
    private Distance D2;

    private void StoreScore()
    {
        StartCoroutine(Store());
    }

    private IEnumerator Store()
    {
        yield return new WaitForEndOfFrame();
        int score = D1.Bonus + D1.Value + D2.Bonus + D2.Value;
        if (score <= PlayerPrefs.GetInt("Score", -1)) yield break;
        PlayerPrefs.SetInt("BlackDistance", D1.Value);
        PlayerPrefs.SetInt("WhiteDistance", D2.Value);
        PlayerPrefs.SetInt("BlackRate", P1.Percent);
        PlayerPrefs.SetInt("WhiteRate", P2.Percent);
        PlayerPrefs.SetInt("Score", score);
}

    // Start is called before the first frame update
    private void Start()
    {
        var events = GameEvents.instance;
        events.GameEnd += StoreScore;
        events.GameBeforeAwake += debugTest;
    }

    private void debugTest()
    {
        Debug.Log($"Distance: {PlayerPrefs.GetInt("BlackDistance",-1)} {PlayerPrefs.GetInt("WhiteDistance",-1)}");
        Debug.Log($"Rate: {PlayerPrefs.GetInt("BlackRate", -1)} {PlayerPrefs.GetInt("WhiteRate", -1)}");
        Debug.Log($"Score: {PlayerPrefs.GetInt("Score",-1)}");
    }
}
