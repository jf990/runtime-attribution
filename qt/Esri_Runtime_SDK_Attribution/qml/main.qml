
// Copyright 2016 ESRI
//
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
//
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
//
// See the Sample code usage restrictions document for further information.
//

import QtQuick 2.6
import QtQuick.Controls 1.4
import Esri.ArcGISRuntime 100.0
import Esri.ArcGISExtras 1.1

ApplicationWindow {
    id: appWindow
    width: 768
    height: 1024
    title: "Esri_Runtime_SDK_Attribution"

    property real startLatitude: 40.7576
    property real startLongitude: -73.9857
    property int startScale: 120000
    property real scaleFactor: System.displayScaleFactor

    MapView {
        id: mapView
        anchors.fill: parent
        wrapAroundMode: Enums.WrapAroundModeEnabledWhenSupported

        Map {
            id: map
            BasemapNationalGeographic {}
            initialViewpoint: viewpoint
            onLoadStatusChanged: {
                if (loadStatus == Enums.LoadStatusLoaded) {
                    var layers = map.basemap.baseLayers
                    var attributionText = ""
                    if (layers != null) {
                        var error = layers.forEach(function(layer, index, array) {
                            attributionText += (attributionText == "" ? "" : "; ") + layer.attribution;
                        });
                        if (error) {
                            console.log(error);
                        }
                        attribution.text = attributionText
                    }
                }
            }
        }
    }

    Rectangle {
        id: attributionBar
        anchors {
            left: parent.left
            right: parent.right
            bottom: parent.bottom
            rightMargin: 120 * scaleFactor
        }
        height: 18 * scaleFactor
        color: "transparent"

        Text {
            id: attribution
            anchors.fill: parent
            text: ""
            font.pixelSize: 10 * scaleFactor
            color: "#323232"
            clip: true
        }
    }

    ViewpointCenter {
        id: viewpoint
        center: Point {
            x: startLongitude
            y: startLatitude
            spatialReference: SpatialReference { wkid: 4326 }
        }
        targetScale: startScale
    }
}
