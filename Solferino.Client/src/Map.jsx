import React, { useEffect } from "react";
import { MapContainer, TileLayer } from "react-leaflet";
import "leaflet/dist/leaflet.css";

const SimpleMap = () => {

    const center = {
        latitude: 48.866667,
        longitude: 2.333333,
        name: "Paris",
    };
    console.log(fetchData())

    return (
        <div>
            <MapContainer center={[center.latitude, center.longitude]} zoom={9}  style={{ height: "80vh", width: "80vw" }}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
            </MapContainer>
        </div>
    );


    async function fetchData() {
        const response = await fetch("https://localhost:44309/api/trainstations/pageSize3", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const data = await response.json();
        return data;
    }
};

export default SimpleMap;