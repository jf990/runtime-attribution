# ArcGIS Runtime Attribution

Esri requires that when you use an ArcGIS Online basemap, Esri data services, or Esri API technology in your app you must also include Esri attribution. There are specific requirements for attribution you may be required to address in your app depending on how your app is built and the data it uses. For more specific information, please visit [Attribution in your app](https://developers.arcgis.com/terms/attribution/).

If you are going to deploy an app built with a Runtime SDK then this project can help you get started with attribution display. If you are building an app with ArcGIS API for JavaScript then refer to the [Attribution widget](https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Attribution.html).

![iOS](./assets/attribution-android.png)

With version 100.0, the ArcGIS Runtime SDKs do not offer any API control over the display of map attribution, yet Esri's license agreement requires it. Developers are on their own to show map attribution and conform to their license agreement with Esri. As detailed in the [Attribution in your app](https://developers.arcgis.com/terms/attribution/) topic, there are specific rules and restrictions when showing attribution.

The purpose of this project is to demonstrate how to get the attribution for all layers currently assigned to the base map used by the map object. The attribution is displayed on the bottom of the map view.

This project has project setups and source code for 5 SDK platforms: Android, iOS, .NET, Qt, and Xamarin. This project also demonstrates the power of the Runtime API: how the code is very similar on all 5 platforms.

## Android

Follow the [ArcGIS Runtime SDK for Android](https://developers.arcgis.com/android/latest/guide/install-and-set-up.htm) install and setup instructions. This project uses the Gradle setup. After installation you should make sure you have a working setup by building the [Develop your first map app](https://developers.arcgis.com/android/latest/guide/develop-your-first-map-app.htm).

You could use this same source code for a Java project if you are targeting a desktop environment. First get your Java development environment setup by following [Install the SDK](https://developers.arcgis.com/java/latest/guide/install-the-sdk.htm). Then copy the source from this project's `MainActivity.java` into your Java project.

## iOS

This project is written in Swift. Follow the [ArcGIS Runtime SDK for iOS](https://developers.arcgis.com/ios/latest/swift/guide/install.htm) install and setup instructions. This project installs the SDK manually and does not use the Cocoapods setup. After installation you should make sure you have a working setup by building the [Develop your first map app](https://developers.arcgis.com/ios/latest/swift/guide/develop-your-first-map-app.htm).

You could use this same source code for a macOS project if you are targeting a desktop environment. First get your macOS development environment setup by following [Install the SDK](https://developers.arcgis.com/macos/latest/swift/guide/install-and-setup.htm). Then copy the source from this project's `ViewController.swift` into your Java project.

## .NET

This is a C#/WPF application. Follow the [ArcGIS Runtime SDK for .NET](https://developers.arcgis.com/net/latest/wpf/guide/install-the-sdk.htm) install and setup instructions. This project installs the SDK with Nuget. Follow the instructions at [Add ArcGIS Runtime SDK references](https://developers.arcgis.com/net/latest/wpf/guide/add-arcgis-runtime-sdk-references.htm). After installation you should make sure you have a working setup by building the [Develop your first map app](https://developers.arcgis.com/net/latest/wpf/guide/develop-your-first-map-app.htm).

## Qt

The Qt project is implemented using QML only. Follow the [ArcGIS Runtime SDK for Qt](https://developers.arcgis.com/qt/latest/qml/guide/install-and-set-up-on-windows.htm) install and setup instructions depending on your development platform. After setup you can install this project and verify your configuration. You will need at least one setup, it is usually easiest to configure a desktop emulator.

## Xamarin

This Xamarin project is very similar to the .NET/WPF implementation. Using Xamarin forms, you can build this solution to Windows Phone, Android, and iOS as well as Windows desktop apps. To get started, follow the [ArcGIS .NET setup instructions](https://developers.arcgis.com/net/latest/forms/guide/install-the-sdk.htm) for Xamarin Forms (select the **Forms** tab in the Viewing switcher.)
You will be required to get Xamarin setup with respect to the Nuget packages and the ArcGIS Runtime setup packages, so follow the [Install the SDK](https://developers.arcgis.com/net/latest/forms/guide/install-the-sdk.htm) and the [Develop your first map app](https://developers.arcgis.com/net/latest/forms/guide/develop-your-first-map-app.htm) guides if this is your first time. This will guarantee you have the necessary packages installed.
Once you have a working setup you can then load this Xamarin project solution into Visual Studio.

# Known issues and caveats

 * Attribution is picked up for tile service layers. However, it is not for Vector basemaps or layers. The issue is inside the SDK where attribution is not accessible for certain types of layers.
 * Esri is expected to deliver layer attribution with update 1 (version 100.1), therefore this project is only intended to be an temporary solution to conform to the license agreement until this functionality is officially provided by the SDK.
  