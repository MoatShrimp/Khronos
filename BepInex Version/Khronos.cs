using UnityEngine;
using Assets.CS.TabletopUI;
using Assets.TabletopUi.Scripts.Services;
using BepInEx;
using BepInEx.Configuration;

[BepInPlugin("MoatShrimp.CultistSimulatorPlugins.Khronos", "Khronos", "0.7.1")]
public class Khronos : BaseUnityPlugin
{
    public static TimeSkip Skipper { get; set; }
    public static SpeedManager SpeedManager { private get; set; }
    public static bool IsGameScene => Registry.Get<StageHand>().SceneIsActive(4);
    public static Heart Heart => Registry.Get<TabletopManager>().GetComponentInChildren<Heart>();
    private KeyboardShortcut _increasSpeedKey;
    private KeyboardShortcut _decreaseSpeedKey;
    private KeyboardShortcut _resetSpeedKey;
    private KeyboardShortcut _skipKey;

    public void Awake()
    {
        _skipKey = Config.Bind("Hotkeys", "TimeSkipKey", new KeyboardShortcut(KeyCode.F12)).Value;
        _increasSpeedKey = Config.Bind("Hotkeys", "IncreasSpeedKey", new KeyboardShortcut(KeyCode.F11)).Value;
        _decreaseSpeedKey = Config.Bind("Hotkeys", "DecreaseSpeedKey", new KeyboardShortcut(KeyCode.F10)).Value;
        _resetSpeedKey = Config.Bind("Hotkeys", "ResetSpeedKey", new KeyboardShortcut(KeyCode.F9)).Value;
        
        Skipper = this.gameObject.AddComponent<TimeSkip>();
        SpeedManager = this.gameObject.AddComponent<SpeedManager>();
        Logger.LogInfo("Khronos-plugin initialized.");
    }
    private void Update()
    {
        if (Khronos.IsGameScene)
        {
            if (_skipKey.IsDown()) Skipper.SkipToNext();
            if (_increasSpeedKey.IsPressed()) SpeedManager.ChangeSpeed(SpeedManager.speedMod.increase);
            if (_decreaseSpeedKey.IsPressed()) SpeedManager.ChangeSpeed(SpeedManager.speedMod.decrease);
            if (_resetSpeedKey.IsDown()) SpeedManager.ChangeSpeed(SpeedManager.speedMod.reset);
        }           
    }
}