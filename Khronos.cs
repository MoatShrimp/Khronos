using UnityEngine.InputSystem;
using UnityEngine;
using SecretHistories.UI;
using SecretHistories.Services;
using SecretHistories.Entities;
public class Khronos : MonoBehaviour
{
    public static TimeSkip Skipper { get; set; }
    public static SpeedManager SpeedManager { private get; set; }
    public static Khronos ActiveTimeWarp { get; private set; }
    public static bool IsGameScene => Watchman.Get<StageHand>().SceneIsActive(Watchman.Get<Compendium>().GetSingleEntity<Dictum>().PlayfieldScene);
    public static Heart Heart => Watchman.Get<Heart>();
    public Keyboard _keyboard = Keyboard.current;

    public static void Initialise()
    {
        GameObject container = new GameObject();
        ActiveTimeWarp = container.AddComponent<Khronos>();
        Skipper = container.AddComponent<TimeSkip>();
        SpeedManager = container.AddComponent<SpeedManager>();
    }
    private void Update()
    {
        if (Khronos.IsGameScene)
        {
            if (_keyboard[Key.F12].wasPressedThisFrame) Skipper.SkipToNext();
            if (_keyboard[Key.F11].isPressed) SpeedManager.ChangeSpeed(SpeedManager.speedMod.increase);
            if (_keyboard[Key.F10].isPressed) SpeedManager.ChangeSpeed(SpeedManager.speedMod.decrease);
            if (_keyboard[Key.F9].wasPressedThisFrame) SpeedManager.ChangeSpeed(SpeedManager.speedMod.reset);
        }            
    }
}