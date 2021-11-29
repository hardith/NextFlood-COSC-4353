import React, { useEffect, useRef, useState } from 'react'
import ReactMapGL, { Popup, GeolocateControl}  from 'react-map-gl'
import "mapbox-gl/dist/mapbox-gl.css"
import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css"
import DeckGL, { GeoJsonLayer } from "deck.gl";
import Geocoder from "react-map-gl-geocoder";
import PINSJSON from '../assets/markerdata.json';
import Pins from "./Pins"
import MarkerPopup from './MarkerPopup';
import AddForm from './AddMarkerForm';

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
  const [popupInfo, setPopupInfo] = useState(null);
  const [addMarker, setAddMarker] = useState(false);
  const [markerData, setMarkerData] = useState(PINSJSON)
  const [newLatitude, setNewLatitude] = useState(0)
  const [newLongitude, setNewLongitude] = useState(0)

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
    console.log(viewport)
    return setViewport({
      ...viewport,
      ...geocoderDefaultOverrides
    });
  }

  const onSubmitAddNewMarker = (formValues) => {
    console.log(formValues)
    console.log("hello");
  }

  useEffect(()=>{
    
  },[newLatitude])

  return (
		<>
			<ReactMapGL
				ref={mapRef}
				mapStyle="mapbox://styles/mapbox/streets-v11"
				mapboxApiAccessToken={process.env.REACT_APP_MAPBOX_TOKEN}  
				{...viewport} 
				width="100vw" 
				height="91vh" 
        // style={{zIndex:1000}}
				onViewportChange={setViewport}
        onClick={x => { 
          console.log(x.srcEvent)
          x.srcEvent.which === 1 && // check if left click
          // mapDispatch({ type: "ADD_MARKER", 
          // payload: { marker: x.lngLat } });
          setAddMarker(true)
          setNewLongitude(x.lngLat[0])
          setNewLatitude(x.lngLat[1])
        }
        } 
			>
        {addMarker && (
           <Popup
          //  style={{zIndex:5000}}
           tipSize={5}
           anchor="top"
           longitude={newLongitude}
           latitude={newLatitude}
           closeOnClick={false}
           onClose={()=> {setAddMarker(false)}}
         >
           <AddForm onSubmitAddNewMarker={onSubmitAddNewMarker}/>
         </Popup>
        )
        }
        <Pins data={markerData} onClick={setPopupInfo} />
        {popupInfo && (
          <Popup
            tipSize={5}
            anchor="top"
            longitude={Number(popupInfo.longitude)}
            latitude={Number(popupInfo.latitude)}
            closeOnClick={false}
            onClose={setPopupInfo}
          >
            <MarkerPopup info={popupInfo} />
          </Popup>
        )}
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
				{/* <DeckGL {...viewport} layers={[searchResultLayer]} /> */}
			</ReactMapGL>	
		</>
  );
}

export default MapBox;