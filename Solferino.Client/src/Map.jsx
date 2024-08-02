import React, { useEffect, useState } from "react";
import { MapContainer, TileLayer, Marker, Circle, LayerGroup } from "react-leaflet";
import Form from 'react-bootstrap/Form';


import "leaflet/dist/leaflet.css";

const SimpleMap = () => {
    const [stations, setStations] = useState();
    const [lines, setLines] = useState();
    const [selectedLine, setSelectedLine] = useState("");


    const center = {
        latitude: 48.866667,
        longitude: 2.333333,
        name: "Paris",
    };

    useEffect(() => {
        fetchData()
    }, [])

    const handleChange = (e) => {
        setSelectedLine(e.target.value);
    }

    const stationMarkers = stations === undefined
        ? <p>En cours de chargement </p>
        : stations.map(station =>
            <Marker key={station.name} position={[station.latitude, station.longitude]}> </Marker>
        )
        
    const lineOptions = lines === undefined
        ? <p> </p>
        : <Form.Select onChange={handleChange} >
            <option>Selectionner une ligne</option>

            {lines.map((line, i) => 
                <option key={i} value={line}>{line}</option>
            )}
        </Form.Select>




    return (
        <div>
            {lineOptions}

            <MapContainer center={[center.latitude, center.longitude]} zoom={9}  style={{ height: "80vh", width: "80vw" }}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                <Marker position={[center.latitude, center.longitude]}> </Marker>
                {stationMarkers}
            </MapContainer>
        </div>
    );


    async function fetchData() {
        const trainStations = await fetch("https://localhost:44309/api/trainstations/pageSize3", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataStations = await trainStations.json();
        setStations(dataStations);


        const lines = await fetch("https://localhost:44309/api/trainstations/lines", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataLines = await lines.json();
        setLines(dataLines);
        console.log(dataLines)
    }
};

export default SimpleMap;