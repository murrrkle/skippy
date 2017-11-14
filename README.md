# 581a2 - Skippy
Receives input from a Nintendo JoyCon remote from [here](https://github.com/murrrkle/581a2-joycon/releases).
Runs on Android Phones (>4.4) with Google Cardboard.

## Compilation Instructions:
1. Download `skippy.zip` package file and import the `.unitypackage` file into the latest version of Unity 2017
2. In **Edit...** \> **Project Settings...** \> **Player** \> **Other Settings**, change the following:
* **Configuration** \> **API Compatibility Level** should be set to `.Net 2.0`
* Uncheck **Multithreaded Rendering** for performance
* **Bundle Identifier** should be set to use the appropriate *Company Name* and *Product Name*
* **Minimum API Level** should be set to **Android 4.4 'Kit Kat'**
3. Select **Android** in **Build Settings** and click **Build**.

## Running Skippy:
1. Move the compiled `.apk` file to your Android device and install it
2. Open it and put it in your Google Cardboard
3. Make sure the JoyCon Input reciever application is running and communicating with the JoyCon.

## Libraries used:
* [NetworkIt](https://github.com/kevinta893/NetworkIt/releases)
* GoogleVR

## Other Resources:
* [Tranquil Mountain Lake in 360 VR](https://www.youtube.com/watch?v=joQFDRwevo8)
* [Meditation Bell Sound Effect](https://www.youtube.com/watch?v=dqwk5nGZMiw)
* Ghostly Voice Pad Synthesizer from Garageband
* [Lowpoly Flowers](https://www.assetstore.unity3d.com/en/#!/content/47083)
