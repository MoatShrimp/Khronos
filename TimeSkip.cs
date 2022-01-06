using System.Linq;
using UnityEngine;
using SecretHistories.UI;
using SecretHistories.Entities;
using SecretHistories.Fucine;

public class TimeSkip : MonoBehaviour, ISituationSubscriber
{
    private Situation _situationWithLowestTimeRemaining => Watchman.Get<HornedAxe>().GetRegisteredSituations().OrderBy(s => s.TimeRemaining).FirstOrDefault(s => s.TimeRemaining > 0f);
    private Situation _activeSituation;

    private void Awake()
    {
        this.enabled = false;
    }

    private void Update()
    {
        float bugCorrectedTime = _activeSituation.TimeRemaining / 2; // current beta version is bugged and doubles the Hear.Beat time
        float skip = bugCorrectedTime < 1f ? bugCorrectedTime : 1f;
        Khronos.Heart.Beat(skip, 0.05f);
    }

    public void SkipToNext()
    {
        _activeSituation = _situationWithLowestTimeRemaining;

        if (_activeSituation is null)
        {
            NoonUtility.LogWarning("No instance of a situation in progress was found");
            return;
        }

        _activeSituation.AddSubscriber(this);
        this.enabled = true;
    }

    public void SituationStateChanged(Situation situation)
    {
        this.enabled = false;
    }
    
    public void TimerValuesChanged(Situation situation) { }
    public void SituationSphereContentsUpdated(Situation situation) { }
}