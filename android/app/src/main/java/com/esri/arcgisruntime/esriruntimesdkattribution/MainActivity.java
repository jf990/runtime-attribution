package com.esri.arcgisruntime.esriruntimesdkattribution;

import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.util.TypedValue;
import android.view.Gravity;
import android.widget.TextView;

import com.esri.arcgisruntime.geometry.Point;
import com.esri.arcgisruntime.geometry.SpatialReference;
import com.esri.arcgisruntime.layers.Layer;
import com.esri.arcgisruntime.loadable.LoadStatus;
import com.esri.arcgisruntime.mapping.ArcGISMap;
import com.esri.arcgisruntime.mapping.Basemap;
import com.esri.arcgisruntime.mapping.LayerList;
import com.esri.arcgisruntime.mapping.view.MapView;


public class MainActivity extends AppCompatActivity {

    private Basemap.Type mBasemapType = Basemap.Type.TOPOGRAPHIC;
    private double mStartLatitude = 40.7576;
    private double mStartLongitude = -73.9857;
    private int mStartLevelOfDetail = 11;

    private ArcGISMap mMap = null;
    private MapView mMapView;


    /**
     * Internal function to display an error message.
     * @param errorMessage
     */
    private void showError(String errorMessage) {
        Log.d("showError", errorMessage);
        TextView attributionTextView = (TextView) findViewById(R.id.mapAttribution);
        if (attributionTextView != null) {
            attributionTextView.setText(errorMessage);
        }
    }

    /**
     * Configure the TextView we are going to use to display any map attributions.
     */
    private void setupAttribution() {
        TextView attributionTextView = (TextView) findViewById(R.id.mapAttribution);
        if (attributionTextView != null) {
            attributionTextView.setTextColor(Color.parseColor("#323232"));
            attributionTextView.setTextSize(TypedValue.COMPLEX_UNIT_SP, 10);
            attributionTextView.setGravity(Gravity.LEFT);
            attributionTextView.setSingleLine(true);
            attributionTextView.setEllipsize(TextUtils.TruncateAt.END);
        }
    }

    /**
     * Determine the map attribution from the basemap collection of layers by iterating the layers
     * and concatenating all attributions. This is the quick-and-dumb method that does not consider
     * extent and scale.
     */
    private String getBasemapAttribution(ArcGISMap map) {
        String attributionText = null;
        if (map != null) {
            LayerList mapLayers = map.getBasemap().getBaseLayers();
            if (mapLayers != null && ! mapLayers.isEmpty()) {
                try {
                    String layerAttribution;
                    for (int i = mapLayers.size() - 1; i >= 0; i --) {
                        Layer mapLayer = mapLayers.get(i);
                        layerAttribution = mapLayer.getAttribution();
                        if (attributionText == null) {
                            attributionText = layerAttribution;
                        } else {
                            attributionText += "; " + layerAttribution;
                        }
                    }
                } catch (Exception genericException) {
                    showError("updateAttribution cant cast the layer");
                }
            }
        }
        return attributionText;
    }

    /**
     * Update the map attribution displayed based on the current map layer and extent configuration.
     */
    private void updateAttribution() {
        if (mMap != null) {
            TextView attributionTextView = (TextView) findViewById(R.id.mapAttribution);
            if (attributionTextView != null) {
                String attributionText = getBasemapAttribution(mMap);
                if (attributionText != null) {
                    attributionTextView.setText(attributionText);
                }
            }
        }
    }

    /**
     * Perform all the necessary steps to setup, initialize, and load the map for the first time.
     */
    private void configureInitialMapView() {

        if (mMapView != null) {
            mMap = new ArcGISMap(mBasemapType, mStartLatitude, mStartLongitude, mStartLevelOfDetail);
            mMap.addDoneLoadingListener(new Runnable() {
                @Override
                public void run() {
                    if (mMap.getLoadStatus() == LoadStatus.LOADED) {
                        updateAttribution();
                    } else if (mMap.getLoadStatus() == LoadStatus.FAILED_TO_LOAD) {
                        Log.d("Network error", "Cannot load the map.");
                    }
                }
            });
            mMapView.setMap(mMap);
            setupAttribution();
        }
    }

    private void setupMap(MapView mapView) {
        if (mapView != null) {
            ArcGISMap map = new ArcGISMap(Basemap.createImageryWithLabels());
            SpatialReference spatialReference = SpatialReference.create(102100);
            Point centerPoint = new Point(-8262476.527867007, 5007669.474234587, spatialReference);
            double scale = 4513.988705;
            mapView.setMap(map);
            mapView.setViewpointCenterAsync(centerPoint, scale);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mMapView = (MapView) findViewById(R.id.mapView);
        setupMap(mMapView);
    }

    @Override
    protected void onPause(){
        if (mMapView != null) {
            mMapView.pause();
        }
        super.onPause();
    }

    @Override
    protected void onResume(){
        super.onResume();
        if (mMapView != null) {
            mMapView.resume();
        }
    }
}
