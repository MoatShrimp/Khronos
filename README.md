# Khronos
A speed control mod for Cultist Simulator Beta branch (and the Stable blanch using BepInEx). With this mod you get full control of the speed of the game together the ability to jump forward in time to the next event. Main mod requires the current (as of 2022-01-06) Beta branch 'Gate of Horn' of Cultist Simulator in order to work. Otherwise BepInEx is required.

Mod for the Beta branch can be downloaded from Steam Workshop here: https://steamcommunity.com/sharedfiles/filedetails/?id=2709533810

## Usage
### Press
- **F12 -** to skip forward in time till the the next event completes.  
- **F11 -** to increase game speed, max speed is dependent on the in-game fps with 300% speed being the maximum for 60fps and 600% for 120fps
- **F9 -** to decrease game speed, min speed is 0% by which in-game time comes to a halt
- **F8 -** to reset game speed to normal 100% speed

## BepInEx version installation
For the stable release of Cultist Simulator, this mod uses BepInEx.
- Install the [latest x86 version](https://github.com/BepInEx/BepInEx/releases/) of BepInEx by downloladig and extracting the zip file into your Cultist Simulator install location.
- Run the game once, to let BepInEx create its folder structure.
- Place the Khronos.dll file from the download into `Cultist Simulator/BepInEx/Plugins`
Hotkeys can be changed in the configuration file `Cultist Simulator\BepInEx\config\MoatShrimp.CultistSimulatorPlugins.Khronos.cfg`created after initial startup.

## Dependencies for source files
Project Dependencies should be placed in a folder called `external`. All files can be found inside the game folder `Cultist Simulator/cultistsimulator_Data/Managed`

Required files:
- SecretHistories.Main.dll
- UnityEngine.CoreModule.dll
- UnityEngine.IMGUIModule.dll
- Unity.InputSystem.dll

## Dependencies for BepInEx version of source files
Project Dependencies should be placed in a folder called `external`. All files can be found inside the game folder `Cultist Simulator/cultistsimulator_Data/Managed`

Required files:
- Assembly-CSharp.dll
- BepInEx.dll
- UnityEngine.dll
- UnityEngine.CoreModule.dll
- UnityEngine.IMGUIModule.dll


