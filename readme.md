# ⚡ Power Overhaul (Stationeers Mod)

> Because plumbing should not need its own power plant.

**Power Overhaul** is a Stationeers mod that brings sanity back to the power consumption of gas devices.  
The mod scales down the power usage of atmospheric devices on a configureable scale from 5% to 100%.

This repository is only required if you want to work on the mod. If you just want to use the mod you
can do so with the Steam Workshop.

---

## ✅ Features

- 🔋 Scales down power consumption for:
  - Pressure Regulator  
  - Back Pressure Regulator  
  - Volume Pump
  - Gas Mixer
- ⚙️ Power draw scaling is configurable via the in-game **Mod Settings** UI or via a config file.
- 🧮 Adjusts both **runtime usage** and **logic-reported power** values for accurate readings.

---

## 🧩 Dependencies

- BepInEx 5.4 or newer (https://github.com/BepInEx/BepInEx/)
- Stationeers LaunchPad 0.2.12 or newer (https://github.com/StationeersLaunchPad/StationeersLaunchPad/)
- Stationeers game (Terrain update)
- Works on Windows, Linux, and Steam Deck

---

## 🛠️ Build

The committed .csproj file is for use in VS Code on linux with mono. If you want to modify and 
build the mod in Visual Studio or on Windows you might need to change some project settings to fit 
your environment. 

The following setting needs to be adjusted, as my Steam library is not in $HOME:
```xml
<PropertyGroup>
  <GameDir>/path/to/root/folder/of/Stationeers</GameDir>
</PropertyGroup>
```

After successful build PowerOverhaul.dll needs to be copied from **.../PowerOverhaul/bin/Release/net48**
to the mod folder of the game, which is located in **Documents/My Games/Stationeers/mods/PowerOverhaul**.
The location of the Documents folder is one of the following, depending on your platform:
- Linux: .../Steam/steamapps/compatdata/544550/pfx/drive_c/users/steamuser/
- Windows: %USERPROFILE%/Documents/


