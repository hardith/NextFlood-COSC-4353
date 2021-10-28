import React, { useEffect, useRef, useState } from 'react'
import ReactMapGL, {GeolocateControl}  from 'react-map-gl'
import "mapbox-gl/dist/mapbox-gl.css"
import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css"
import DeckGL, { GeoJsonLayer } from "deck.gl";
import Geocoder from "react-map-gl-geocoder";

const geolocateControlStyle= {
  right: 10,
  top: 10,
  zIndex:100
};

const MapBox = () => {
  const [viewport, setViewport] = React.useState({
    longitude: -122.45,
    latitude: 37.78,
    zoom: 0,
		transitionDuration: 100
  });
	const [searchResultLayer, setSearchResult ] = useState(null)
	const mapRef = useRef()

	const handleOnResult = event => {
    // console.log(event.result)
    setSearchResult( new GeoJsonLayer({
        id: "search-result",
        data: event.result.geometry,
        getFillColor: [255, 0, 0, 128],
        getRadius: 1000,
        pointRadiusMinPixels: 10,
        pointRadiusMaxPixels: 10
      })
    )
  }

	const handleGeocoderViewportChange = viewport => {
    const geocoderDefaultOverrides = { transitionDuration: 1000 };
    console.log("Updating")

    return setViewport({
      ...viewport,
      ...geocoderDefaultOverrides
    });
  }

  return (
		<>
			<ReactMapGL
				ref={mapRef}
				mapStyle="mapbox://styles/mapbox/streets-v11"
				mapboxApiAccessToken={process.env.REACT_APP_MAPBOX_TOKEN}  
				{...viewport} 
				width="100vw" 
				height="91vh" 
				onViewportChange={setViewport} 
			>
				<GeolocateControl
					style={geolocateControlStyle}
					positionOptions={{enableHighAccuracy: true}}
					trackUserLocation={true}
					auto
      	/>
				<Geocoder 
            mapRef={mapRef}
            onResult={handleOnResult}
            onViewportChange={handleGeocoderViewportChange}
            mapboxApiAccessToken={process.env.REACT_APP_MAPBOX_TOKEN}
            position='top-left'
          />
				<DeckGL {...viewport} layers={[searchResultLayer]} />
			</ReactMapGL>	
		</>
  );
}

export default MapBox;