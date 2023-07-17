# tagforce-essentials
A collection of mods made by myself for Yu-Gi-Oh! GX Tag Force PSP.  
**Both European (ULES-00600) and American (ULUS-10136) versions of the game are supported.  
All in-game selectable languages are supported.**

## Included Mods [UMD Compatible]
- Japanese Voice Enabler
  - Allows the game to play the Japanese voices included in the files on the Title Screen, in the Card Shop and during normal Gameplay.

- Japanese Point Gauge Display
  - Allows the game to use the Point Gauge from the Japanese version of the game for the ATK/DEF display of a monster, and Life Points displayed in the 3D cutscenes in duels.
<div align="center">
	<img src="./Images/ExamplePointGaugeMonster1.png" align="center" width=400/> -> <img src="./Images/ExamplePointGaugeMonster2.png" align="center" width=400/>
</div><br/>

<div align="center">
	<img src="./Images/ExamplePointGaugeLife1.png" align="center" width=400/> -> <img src="./Images/ExamplePointGaugeLife2.png" align="center" width=400/>
</div><br/>

- Uncensored Cards
  - Allows the game to display the Japanese Artwork of cards, Uncensored FMVs for special monster animations and other card related effects whilst keeping the game's currently selected language.

<div align="center">
	<img src="./Images/ExampleCardAlbumCensored1.png" align="center" width=400/> -> <img src="./Images/ExampleCardAlbumUncensored1.png" align="center" width=400/>
</div><br/>

<div align="center">
	<img src="./Images/ExampleDeckEditorCensored1.png" align="center" width=400/> -> <img src="./Images/ExampleDeckEditorUncensored1.png" align="center" width=400/>
</div><br/>

<div align="center">
	<img src="./Images/ExampleCensoredFMV1.png" align="center" width=400/> -> <img src="./Images/ExampleUncensoredFMV1.png" align="center" width=400/>
</div><br/>

<div align="center">
	<img src="./Images/ExampleCensoredSpiritMessage1.png" align="center" width=400/> -> <img src="./Images/ExampleUncensoredSpiritMessage1.png" align="center" width=400/>
</div><br/>
	
# Installation (Real Hardware)
The following installation guide assumes you have already set up your PSP with Custom Firmware and your choice of a cheat engine (TempAR/CWCheat). 

1. Drag and Drop the ISO backup of the game onto `tagforce-essentials.exe`.
   - (Alternatively run the exe in command line as the following: `tagforce-essentials.exe <path_to_iso>`)
2. Connect your PSP with USB to copy files to Memory Stick.
3. Copy the generated `PSP` folder and its contents to the Memory Stick's root.
4. Install the cheats found in the `Codes\PSP` folder to your installed Cheat Engine of choice.
   1. TempAR:
      - Copy the appropriate `*.db` file for your region of the game from `Codes\PSP\TempAR\` to `<psp_root>\seplugins\TempAR\cheats\`.
   2. CWCheat:
      - Copy the contents of the appropriate `*.db` file for your region of the game from `Codes\PSP\CWCheat\` into the `CHEAT.db` file found in `<psp_root>\seplugins\cwcheat\`.
5. Unplug the PSP and boot up the game and enable the cheats inside TempAR/CWCheat.
   - CWCheat requires all 4 parts of the `Uncensored Cards` cheat to be enabled for it to work otherwise the game/system will crash.
6. If you've done everything correctly after turning the cheats on in TempAR/CWCheat the mods should now work (certain areas may need to be reloaded if you enable the codes while in them, for example: if the codes are enabled in the Shop the Shop area might need to be reloaded for the codes to work).

# Installation (Emulator)
1. Download the latest version of [PPSSPP](https://www.ppsspp.org/).
2. Drag and Drop the ISO backup of the game onto `tagforce-essentials.exe`.
   - (Alternatively run the exe in command line as the following: `tagforce-essentials.exe <path_to_iso>`)
3. Copy the generated `PSP` folder and its contents to `<ppsspp_root>\memstick\`.
4. Copy the Codes from the `Codes\PPSSPP` folder for your region of the game to `<ppsspp_root>\memstick\PSP\Cheats\`.
5. Turn on the installed cheats for the game inside PPSSPP for the game.
6. If you've done everything correctly after turning the cheats on in PPSSPP the mods should now work (certain areas may need to be reloaded if you enable the codes while in them, for example: if the codes are enabled in the Shop the Shop area might need to be reloaded for the codes to work).

# Known Issues
- TempAR will fail to boot the game on real hardware if the patches are enabled at boot. There are two ways to get around this:
  - Bringing up TempAR's menu before the game can boot and waiting for the game to check the memory card data to exit out of its menu.
  - Enabling the cheats only once the game has finished booting up and not saving them to auto-enable on boot.
- CWCheat will fail to apply the cheats fast enough for the game to be able to play the Title Screen voices on boot as the title screen code gets loaded very early on.

# Nuget Packages
- [XDeltaSharp](https://github.com/pleonex/xdelta-sharp) - Allowing the xdelta patches to be applied by code.
- [DiscUtils](https://github.com/DiscUtils/DiscUtils) - Allowing ISO files to be loaded and extracted in C#.

# Special Thanks
- [Matheus Abreu](https://gbatemp.net/members/matheus-abreu.400265/) - Creator of the [original Japanese Voice Enabler xdelta patches](https://gbatemp.net/threads/release-enable-japanese-voice-acting-in-yu-gi-oh-gx-tag-force-usa.572290/) that were used for researching how to enable the voices from the game's code directly.
