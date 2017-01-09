using System;

namespace arcgis_runtime_attribution.Shared
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        private Map _map;

        public MapViewModel()

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
        public string attribution

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
        private async void SetupMap()

        /// <summary>
        /// Update the attribution string from the current state of the Map. Also updates the form binding.
        /// </summary>
        private void UpdateAttribution()

        /// <summary>
        /// Collect the attribution on all layers assigned to the basemap, starting from highest layer.
        /// </summary>
        private String getBasemapAttribution(Map map)
}