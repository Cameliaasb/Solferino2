import React, { useEffect, useState } from "react";
import { MapContainer, TileLayer, Circle, Popup } from "react-leaflet";
import Form from 'react-bootstrap/Form';
import "leaflet/dist/leaflet.css";
import Filters from "./Filters";

const SimpleMap = () => {
    const [stations, setStations] = useState();
    const [filters, setFilters] = useState({ line: "All", dayType: "All", year: "All", timeRange: "All" });


    const center = {
        latitude: 48.866667,
        longitude: 2.333333,
        name: "Paris",
    };

    useEffect(() => {
         fetchTrainStations();
    }, [])


    useEffect(() => {
        if (filters) {
            fetchTrainStations();
        }
    }, [filters]);

    const getRadius = (nbOfPassengers) => {
        if (nbOfPassengers > 100000) return 600;
        if (nbOfPassengers > 10000) return 400;
        if (nbOfPassengers > 1000) return 200;
        if (nbOfPassengers > 100) return 100;
        else return 50;

    }

    const stationMarkers = stations === undefined
        ? <p>En cours de chargement </p>
        : stations.map(station =>
            <Circle key={station.name} center={[station.latitude, station.longitude]} radius={getRadius(station.nbOfPassengers)}>
                <Popup>
                    <h6 className="font-weight-bold">  {station.name} </h6>
                    <p> {station.nbOfPassengers} passagers </p>
                </Popup>
            </Circle>
        )



    return (
        <div>
            <Form>
                <Filters onFiltersChange={setFilters} />
            </Form>

            <MapContainer center={[center.latitude, center.longitude]} zoom={9} style={{ height: "80vh", width: "80vw" }}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />

                {stationMarkers}

            </MapContainer>
        </div>
    );



    async function fetchTrainStations() {

        const baseUrl = `https://localhost:44309/api/trainstations/Filters?`;     // A mettre dans .ENV
        const lineFilter = filters.line != "All" ? `line=${filters.line}&` : "";
        const dayTypeFilter = filters.dayType != "All" ? `day=${filters.dayType}&` : "";
        const timeRangeFilter = filters.timeRange != "All" ? `timeRange=${filters.timeRange}&` : "";
        const yearFilter = filters.year != "All" ? `year=${filters.year}&` : "";

        const url = baseUrl + lineFilter + dayTypeFilter + timeRangeFilter + yearFilter;

        const trainStations = await fetch(url, {
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