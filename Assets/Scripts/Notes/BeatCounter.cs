using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatCounter : MonoBehaviour
{
    #region Variables
    public static BeatCounter instance;                 // instance of game logic
    public AudioSource audioSource;
    public bool isStarted;                              // checks if audio has begun
    private float delay = 1;
    private float timer;

    [Header("Scoring")]
    public GameObject[] beatCount;
    public int currScore;
    private int scorePerOkBeat = 100;
    private int scorePerGreatBeat = 125;
    private int scorePerPerfectBeat = 150;
    public int currMultiplier;
    private int multiplierTracker;
    public int[] multiplierThresholds;
    private int okBeats;
    private int greatBeats;
    private int perfectBeats;
    private int missedBeats;

    [Header("UI Components")]
    // during game
    public Text scoreTxt;
    public Text multiplierTxt;
    public Text hitQualityTxt;
    // post game
    public GameObject resultsScreen;
    public Text scoreFinalTxt;
    public Text percentageTxt;
    public Text rankTxt;
    public Text okTxt;
    public Text greatTxt;
    public Text perfectTxt;
    public Text missedTxt;
    #endregion

    void Start()
    {
        instance = this;

        scoreTxt.text = "Score:      0";
        hitQualityTxt.text = "";
        currMultiplier = 1;

        timer = delay;

        for (int i = 0; i < beatCount.Length; i++)
        {
            if (i == 0)
                beatCount[i] = GameObject.Find("Note");
            else
                beatCount[i] = GameObject.Find("Note (" + i + ")");
        }
    }

    void Update()
    {
        if (!isStarted)
        {
            isStarted = true;
            audioSource.Play();
        }
        else
        {
            if (!audioSource.isPlaying && !resultsScreen.activeInHierarchy)
            {
                audioSource.Stop();

                timer += Time.deltaTime;

                if (timer > 5)
                {
                    resultsScreen.SetActive(true);
                    Debug.Log("end game");
                }

                ResultsScreenTexts();
            }
        }
    }

    #region Beat checks
    public void BeatHit()
    {
        //Debug.Log("Hit");

        if (currMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currMultiplier++;
            }
        }

        multiplierTxt.text = "Multiplier:   x" + currMultiplier;
        scoreTxt.text = "Score:     " + currScore;
    }

    public void OkHit()
    {
        Debug.Log("Ok hit");

        hitQualityTxt.color = Color.yellow;
        hitQualityTxt.text = "OK";
        currScore += scorePerOkBeat * currMultiplier;
        BeatHit();
        okBeats++;
    }

    public void GreatHit()
    {
        Debug.Log("Great hit");

        hitQualityTxt.color = Color.blue;
        hitQualityTxt.text = "GREAT";
        currScore += scorePerGreatBeat * currMultiplier;
        BeatHit();
        greatBeats++;
    }

    public void PerfectHit()
    {
        Debug.Log("Perfect hit");

        hitQualityTxt.color = Color.green;
        hitQualityTxt.text = "PERFECT";
        currScore += scorePerPerfectBeat * currMultiplier;
        BeatHit();
        perfectBeats++;
    }

    public void BeatMiss()
    {
        currMultiplier = 1;
        multiplierTracker = 0;
        multiplierTxt.text = "Multiplier:   x" + currMultiplier;

        missedBeats++;

        Debug.Log("Misses: " + missedBeats);

        /* ADDED FOR ALPHA BUILD; SUBJECT TO CHANGE IN FUTURE BUILDS
        // If player misses three beats, the music stops. This casues the
        // results panel to display.
        if (missedBeats >= 3)
        {
            audioSource.Stop();
            Destroy(GameObject.Find("Notes"));
            Destroy(GameObject.Find("HUDText"));
            Destroy(GameObject.Find("Chords"));
        }
        //*/
    }
    #endregion

    #region Results
    private void ResultsScreenTexts()
    {
        okTxt.text = "" + okBeats;
        greatTxt.text = "" + greatBeats;
        perfectTxt.text = "" + perfectBeats;
        missedTxt.text = "" + missedBeats;

        float hitCount = okBeats + greatBeats + perfectBeats;
        float percentCount = (hitCount / beatCount.Length) * 100f;

        percentageTxt.text = percentCount.ToString("F1") + "%";

        ResultsScreenRank(percentCount);

        scoreFinalTxt.text = "" + currScore;
    }

    private void ResultsScreenRank(float percentCount)
    {
        if (percentCount == 100)
        {
            rankTxt.text = "SSS";
        }
        else if (percentCount > 97)
        {
            rankTxt.text = "SS";
        }
        else if (percentCount > 95)
        {
            rankTxt.text = "S";
        }
        else if (percentCount > 90)
        {
            rankTxt.text = "A";
        }
        else if (percentCount > 80)
        {
            rankTxt.text = "B";
        }
        else if (percentCount > 70)
        {
            rankTxt.text = "C";
        }
        else if (percentCount > 60)
        {
            rankTxt.text = "D";
        }
        else
        {
            rankTxt.text = "F";
        }
    }
    #endregion
}
