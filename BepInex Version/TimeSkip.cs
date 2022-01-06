using System.Linq;
using UnityEngine;
using Assets.CS.TabletopUI;
using Assets.Core.Entities;
using Assets.TabletopUi;

public class TimeSkip : MonoBehaviour
{
    private SituationController _situationWithLowestTimeRemaining => Registry.Get<SituationsCatalogue>().GetRegisteredSituations().OrderBy(s => s.SituationClock.TimeRemaining).FirstOrDefault(s => s.SituationClock.TimeRemaining > 0f);
    private float _timeRemaining => _activeSituation.SituationClock.TimeRemaining;
    private SituationController _activeSituation;
    private float _overflowCheck;

    private void Awake()
    {
        this.enabled = false;
    }

    private void Update()
    {
        if (_timeRemaining <= 0 || _timeRemaining > _overflowCheck)
        {
            this.enabled = false;
            return;
        }
        float skip = _timeRemaining < 1f ? _timeRemaining : 1f;
        Khronos.Heart.Beat(skip);
    }

    public void SkipToNext()
    {
        _activeSituation = _situationWithLowestTimeRemaining;

        if (_activeSituation is null)
        {
            Debug.Log("No instance of a situation in progress was found");
            return;
        }

        _overflowCheck = _timeRemaining;
        this.enabled = true;
    }
}