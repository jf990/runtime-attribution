//
//  ViewController.swift
//  Esri Runtime SDK Attribution
//
//  Created by John Foster on 11/10/16.
//  Copyright © 2016 Esri. All rights reserved.
//

import UIKit
import ArcGIS

class ViewController: UIViewController {

    var basemapType:AGSBasemapType = .topographic
    var startLatitude: Double = 40.7576
    var startLongitude: Double = -73.9857
    var startLevelOfDetail: Int = 11

    var map: AGSMap!
    
    @IBOutlet weak var mapView: AGSMapView!
    @IBOutlet weak var attributionView: UILabel!

    /**
     * Configure the UILabel we are going to use to display map attribution.
     */
    func setupAttribution() {
        self.attributionView.numberOfLines = 1
        self.attributionView.lineBreakMode = .byTruncatingTail
        self.attributionView.textColor = UIColor(red: 0.2, green: 0.2, blue: 0.2, alpha: 1.0)
        self.attributionView.textAlignment = NSTextAlignment.left
    }
    
    /**
     * Determine the map attribution from the basemap collection of layers by iterating the layers
     * and concatenating all attributions. This is the quick-and-dumb method that does not consider
     * extent and scale.
     */
    func getBasemapAttribution(for map:AGSMap) -> String {
        let baseLayerList = map.basemap.baseLayers as Any as! [AGSLayer]
        var attribution: String = ""
        var layerAttribution: String = ""
        
        for layer: AGSLayer in baseLayerList {
            layerAttribution = layer.attribution
            if (attribution != "") {
                attribution += "; "
            }
            attribution += layerAttribution
        }
        return attribution;
    }
    
    /**
     * Update the map attribution displayed based on the current map layer and extent configuration.
     */
    func updateAttribution() {
        self.attributionView.text = self.getBasemapAttribution(for: self.map)
    }
    
    /**
     * Perform all the necessary steps to setup, initialize, and load the map for the first time.
     */
    func setupMap() {
        self.map = AGSMap(basemapType: basemapType, latitude: startLatitude,  longitude: startLongitude, levelOfDetail: startLevelOfDetail)
        //Setup a completion handler until the map loaded then show the attribution label
        self.map.load { (error) -> Void in
            if (error != nil) {
                print(error!)
            } else {
                self.updateAttribution();
            }
        }
        self.mapView.map = self.map
        self.setupAttribution()
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.setupMap()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
}
