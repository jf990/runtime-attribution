using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Threading;

namespace arcgis_runtime_attribution
{
    public partial class MainWindow : Window
    {
        private float mStartLatitude = 40.7576f;
        private float mStartLongitude = -73.9857f;
        private int mStartLOD = 12;
        private BasemapType mBasemapType = BasemapType.Topographic;

        private Map mMap;

        public MainWindow()
        {
            InitializeComponent();
            setupMap();
        }

        private void showError(String message)
        {
            // show some form of an error message the map failed to load
            attribution.Content = message;
        }

        private void OnMapLoadStatusChanged(object sender, Esri.ArcGISRuntime.LoadStatusEventArgs loadStatusEvent)
        {
            Dispatcher.BeginInvoke(
                new ThreadStart(() =>
                {
                    if (loadStatusEvent.Status == Esri.ArcGISRuntime.LoadStatus.Loaded)
                    {
                        updateAttribution();
                    }
                    else if (loadStatusEvent.Status == Esri.ArcGISRuntime.LoadStatus.FailedToLoad)
                    {
                        showError(string.Format("Map {1} not loaded status: {0}", loadStatusEvent.Status.ToString(), mBasemapType.ToString()));
                    }
                }));
        }

        private void setupMap()
        {
            mMap = new Map(mBasemapType, mStartLatitude, mStartLongitude, mStartLOD);
            MyMapView.Map = mMap;
            mMap.LoadStatusChanged += OnMapLoadStatusChanged;
            setupAttribution();
        }

        private void setupAttribution()
        {
            // TODO: perform any view manipulattion to get the attribution text view in order.
        }

        private void updateAttribution()
        {
            attribution.Content = getBasemapAttribution(mMap);
        }

        /**
         * Collect the attribution on all layers assigned to the basemap, starting from highest layer.
         */
        private String getBasemapAttribution(Map map)
        {
            String attributionText = null;
            if (map != null)
            {
                LayerCollection mapLayers = map.Basemap.BaseLayers;
                if (mapLayers != null && mapLayers.Count > 0)
                {
                    String layerAttribution = "";
                    for (int i = mapLayers.Count - 1; i >= 0; i --)
                    {
                        Layer mapLayer = mapLayers.ElementAt(i);
                        layerAttribution = mapLayer.Attribution;
                        if (attributionText == null)
                        {
                            attributionText = layerAttribution;
                        } else
                        {
                            attributionText += "; " + layerAttribution;
                        }
                    }
                }
            }
            return attributionText;
        }
    }
}
