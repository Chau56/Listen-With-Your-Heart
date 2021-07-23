
/// <summary>
/// <author>
/// 张翔宇
/// </author>
///<updater>
///周权
/// </updater>
/// <date>
/// 2021/7/16
/// </date>
/// <update>
/// 2021/7/19
/// </update>
/// </summary>

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField]
    private GameObject whiteRecord;
    [SerializeField]
    private GameObject blackRecord;
    private Image white;
    private Image black;
    private int score = 0;
    private void StoreScore()
    {
        StartCoroutine(Store());
    }


    private IEnumerator Store()
    {
        yield return new WaitForEndOfFrame();
        int score = 2 * D1.Value - D1.Bonus + 2 * D2.Value - D2.Bonus;
        if (score <= PlayerPrefs.GetInt("Score", -1)) yield break;
        PlayerPrefs.SetInt("BlackDistance", D1.Value);
        PlayerPrefs.SetInt("WhiteDistance", D2.Value);
        PlayerPrefs.SetInt("BlackRate", P1.Percent);
        PlayerPrefs.SetInt("WhiteRate", P2.Percent);
        PlayerPrefs.SetInt("Score", score);
    }
    private void ResetRecord()
    {
        black.enabled = false;
        white.enabled = false;
    }
    private void show()
    {
        score = 2 * D1.Value - D1.Bonus + 2 * D2.Value - D2.Bonus;
        if (score > PlayerPrefs.GetInt("Score", -1))
        {
            black.enabled = true;
            white.enabled = true;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        white = whiteRecord.GetComponent<Image>();
        black = blackRecord.GetComponent<Image>();
        white.enabled = false;
        black.enabled = false;
        var events = GameEvents.instance;
        events.GameRestart += ResetRecord;
        events.GameWin += show;
        events.GameEnd += StoreScore;
        events.GameBeforeAwake += debugTest;
        PlayerPrefs.DeleteAll();
    }

    private void debugTest()
    {
        Debug.Log($"Distance: {PlayerPrefs.GetInt("BlackDistance", -1)} {PlayerPrefs.GetInt("WhiteDistance", -1)}");
        Debug.Log($"Rate: {PlayerPrefs.GetInt("BlackRate", -1)} {PlayerPrefs.GetInt("WhiteRate", -1)}");
        Debug.Log($"Score: {PlayerPrefs.GetInt("Score", -1)}");
    }
}