using UnityEngine;
using UnityEngine.InputSystem;
public class SpeedManager : MonoBehaviour
{
    private float _speedMultiplier = 1f;
    private readonly float _smallStep = (1f / 50); // smaller steps between 0% to 100% for more granular selecion
    private readonly float _largeStep = (5f / 100); // larger steps between 100% to 600%
    private float _maxSpeed => 0.05f / Time.smoothDeltaTime; // max speed based on frame rate
    private float _guiTimer = 0;
    private float _guiTimerStartTime = 1f;
    
    public void LateUpdate()
    {
        if (_speedMultiplier != 1f && Khronos.IsGameScene)
        {
            float oldTime = Reflection.GetPrivateField<float>(Khronos.Heart, "timerBetweenBeats");
            float newTime = (oldTime - Time.deltaTime) + (Time.deltaTime * _speedMultiplier);
            newTime = newTime > 0.05f ? 0.05f : newTime;
            Reflection.SetPrivateField(Khronos.Heart, "timerBetweenBeats", newTime);
        }
    }

    void OnGUI()
    {
        if (_guiTimer > 0)
        {
            _guiTimer -= Time.deltaTime;

            var mousePos = Mouse.current.position; ;
            GUILayout.BeginArea(new Rect(mousePos.x.ReadValue() - 50, Screen.height - mousePos.y.ReadValue() - 30, 100, 100));
            GUILayout.Box($"Speed: {_speedMultiplier:p0}");
            GUILayout.EndArea();            
        }
    }

    public void ChangeSpeed(speedMod mod)
    {
        float change = 0f;
        switch(mod)
        {
            case speedMod.increase:
                change = _speedMultiplier < 1 ? _smallStep : _largeStep;
                break;
            case speedMod.decrease:
                change = _speedMultiplier <= 1 ? -(_smallStep) : -(_largeStep);
                break;
            default:
                _speedMultiplier = 1f;
                break;
        }
        _speedMultiplier += change;
        _speedMultiplier = _speedMultiplier < 0 ? 0 :
                           _speedMultiplier > _maxSpeed ? _maxSpeed :
                           _speedMultiplier;
        _guiTimer = _guiTimerStartTime;
    }
    
    public enum speedMod{
        increase,
        decrease,
        reset
    } 
}