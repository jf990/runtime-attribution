using System;using System.Collections.Generic;using System.ComponentModel;using System.Linq;using System.Text;using System.Threading;using System.Diagnostics;using System.ServiceModel;using System.Runtime.CompilerServices;using Esri.ArcGISRuntime.Data;using Esri.ArcGISRuntime.Mapping;using Esri.ArcGISRuntime.Location;using Esri.ArcGISRuntime.Security;using Esri.ArcGISRuntime.Symbology;using Esri.ArcGISRuntime.Tasks;using Esri.ArcGISRuntime.UI;

namespace arcgis_runtime_attribution.Shared
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        private Map _map;        private float mStartLatitude = 40.7576f;        private float mStartLongitude = -73.9857f;        private int mStartLOD = 12;        private BasemapType mBasemapType = BasemapType.NationalGeographic;        private string _attribution;

        public MapViewModel()        {            SetupMap();        }

        /// <summary>
        /// Gets or sets the map
        /// </summary>
        public Map Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the attribution text string
        /// </summary>
        public string attribution        {            get { return _attribution; }            set { _attribution = value; OnPropertyChanged(); }        }

        /// <summary>
        /// Raises the <see cref="MapViewModel.PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Performs necessary steps to configure the Map
        /// </summary>
        private async void SetupMap()        {            _map = new Map(mBasemapType, mStartLatitude, mStartLongitude, mStartLOD);            await _map.LoadAsync();            if (_map.LoadStatus == Esri.ArcGISRuntime.LoadStatus.Loaded)            {                UpdateAttribution();            }        }

        /// <summary>
        /// Update the attribution string from the current state of the Map. Also updates the form binding.
        /// </summary>
        private void UpdateAttribution()        {            attribution = getBasemapAttribution(_map);        }

        /// <summary>
        /// Collect the attribution on all layers assigned to the basemap, starting from highest layer.
        /// </summary>
        private String getBasemapAttribution(Map map)        {            String attributionText = null;            if (map != null)            {                LayerCollection mapLayers = map.Basemap.BaseLayers;                if (mapLayers != null && mapLayers.Count > 0)                {                    String layerAttribution = "";                    for (int i = mapLayers.Count - 1; i >= 0; i--)                    {                        Layer mapLayer = mapLayers.ElementAt(i);                        layerAttribution = mapLayer.Attribution;                        if (attributionText == null)                        {                            attributionText = layerAttribution;                        }                        else                        {                            attributionText += "; " + layerAttribution;                        }                    }                }            }            return attributionText;        }    }
}