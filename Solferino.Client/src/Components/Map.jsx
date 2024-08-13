import React, { useEffect, useState } from "react";
import { MapContainer, TileLayer, Circle, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import Filters from "./Filters";
import StationLabel from "./StationLabel"

const SimpleMap = () => {
    const [stations, setStations] = useState();
    const [filters, setFilters] = useState({ line: "A", dayType: "All", year: "All", timeRange: "All" });


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
        if (nbOfPassengers > 10000) return 1000;
        if (nbOfPassengers > 5000) return 750;
        if (nbOfPassengers > 1000) return 500;
        if (nbOfPassengers > 500) return 250;
        else return 100;
    }


    const getColor = (nbOfPassengers) => {
        if (nbOfPassengers > 10000) return "indigo";
        if (nbOfPassengers > 5000) return "darkmagenta ";
        if (nbOfPassengers > 1000) return "mediumslateblue ";
        if (nbOfPassengers > 500) return "darkorchid ";
        if (nbOfPassengers > 0) return "darkorchid ";
        else return "red ";
    }

    const stationMarkers = stations === undefined
        ? <p>En cours de chargement </p>
        : stations.map(station =>
            <Circle key={station.name}
                center={[station.latitude, station.longitude]}
                radius={getRadius(station.nbOfPassengers)}
                pathOptions={{ color: getColor(station.nbOfPassengers), fillColor: getColor(station.nbOfPassengers) }}
            >
                <Popup>
                    <StationLabel station={station} />
                </Popup>
            </Circle>
        )



    return (
        <div className="container">
            <p> Nombre de passagers moyen par tranche horaire  </p>
            
            <Filters onFiltersChange={setFilters} />

            <MapContainer center={[center.latitude, center.longitude]} zoom={9} style={{ height: "60vh", width: "60vw" }} >
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />

                {stationMarkers}

            </MapContainer>
        </div>
    );



    async function fetchTrainStations() {

        const baseUrl = `https://localhost:44309/api/trainstations?`;     // A mettre dans .ENV
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