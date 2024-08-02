import React, { useEffect, useState } from "react";
import { MapContainer, TileLayer, Marker, Circle, LayerGroup } from "react-leaflet";
import Form from 'react-bootstrap/Form';
require('dotenv').config()


import "leaflet/dist/leaflet.css";

const SimpleMap = () => {
    const [stations, setStations] = useState();
    const [lines, setLines] = useState();
    const [pageSize, setPageSize] = useState(10);
    const [selectedLine, setSelectedLine] = useState("");


    const center = {
        latitude: 48.866667,
        longitude: 2.333333,
        name: "Paris",
    };

    useEffect(() => {
        fetchData()
    }, [])

    const handleChangeLine = async (e) => {
       await setSelectedLine(e.target.value);
       fetchTrainStations();
    }

    const stationMarkers = stations === undefined
        ? <p>En cours de chargement </p>
        : stations.map(station =>
            <Marker key={station.name} position={[station.latitude, station.longitude]}> </Marker>
        )
        
    const selectLine = lines === undefined
        ? <p> </p>
        : <Form.Select onChange={handleChangeLine} >
            <option>Selectionner une ligne</option>

            {lines.map((line, i) => 
                <option key={i} value={line}>{line}</option>
            )}
        </Form.Select>


const handleChangePageSize = (e) => {
        setPageSize(e.target.value);
        fetchTrainStations();
    }

    const selectPageSize =
        <Form.Select onChange={handleChangePageSize} >
            <option>Nombre maximal résultats</option>
            <option value={5}> 5</option>
            <option value={10}> 10</option>
            <option value={20}> 20</option>
            <option value={50}> 50</option>
        </Form.Select>



    // TO DO: fix probleme de réactivité => Tjrs one step behind après les Select

    return (
        <div>
            {selectLine}
            {selectPageSize}

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
        await fetchTrainStations();

        const lines = await fetch("https://localhost:44309/api/trainstations/lines", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataLines = await lines.json();
        setLines(dataLines);
    }


    async function fetchTrainStations() {
        console.log(pageSize)     // one step behind : WHY?
        console.log(selectedLine)  // one step behind : WHY?

        const baseUrl = `https://localhost:44309/api/trainstations/pageSize${pageSize}/Filters?`;     // A mettre dans .ENV
        const filters = selectedLine ? `line=${selectedLine}` : "";

        const trainStations = await fetch(baseUrl + filters, {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataStations = await trainStations.json();
        setStations(dataStations);
    }
};

export default SimpleMap;