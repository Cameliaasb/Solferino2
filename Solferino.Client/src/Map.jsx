import React, { useEffect, useState } from "react";
import { MapContainer, TileLayer, Marker, Circle, LayerGroup } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import L from "leaflet";

const SimpleMap = () => {
    const [stations, setStations] = useState();

    const center = {
        latitude: 48.866667,
        longitude: 2.333333,
        name: "Paris",
    };
    console.log(stations)

    useEffect(() => {
        fetchData()
    }, [])

    const stationMarkers = stations === undefined
        ? <p>En cours de chargement </p>
        : stations.map(station =>
            <Marker key={station.name} position={[station.latitude, station.longitude]}> </Marker>
        )
        




    return (
        <MapContainer center={[center.latitude, center.longitude]} zoom={9}  style={{ height: "80vh", width: "80vw" }}>
            <TileLayer
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
            <Marker position={[center.latitude, center.longitude]}> </Marker>
            {stationMarkers}
        </MapContainer>
    );


    async function fetchData() {
        const response = await fetch("https://localhost:44309/api/trainstations/pageSize3", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const data = await response.json();
        setStations(data);
        console.log(data);
    }
};

export default SimpleMap;