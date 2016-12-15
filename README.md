# ArcGIS Attribution

Esri requires that when you use an ArcGIS Online basemap, Esri data services, or Esri API technology in your app you must also include Esri attribution. There are specific requirements for attribution you may be required to address in your app depending on how your app is built and the data it uses. For more specific information, please visit [Attribution in your app](https://developers.arcgis.com/terms/attribution/).

![iOS](./assets/attribution-android.png)

The ArcGIS Runtime SDKs do not offer any API control over the display of map attribution, yet Esri's license agreement requires it. Developers are on their own to show map attribution and conform to their licesne agreement with Esri. As detailed in the [Attribution in your app](https://developers.arcgis.com/terms/attribution/) topic, there are specific rules and restrictions when showing attribution.

The purpose of this project is to demonstrate how to get the attribution for all layers currently assigned to the base map used by the map object. The attribution is displayed on the bottom of the map view.

This project has project setups and source code for 4 SDK platforms: Android, iOS, .NET, and Qt.

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
