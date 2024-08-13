import React, { useEffect, useState } from "react";
import Form from 'react-bootstrap/Form';

function Filters({ onFiltersChange }) {
    const [lines, setLines] = useState();
    const [years, setYears] = useState();

    const [filters, setFilters] = useState({ line: "All", dayType: "All", year: "All", timeRange: "All" })

    const [selectedLine, setSelectedLine] = useState();
    const [selectedDayType, setSelectedDayType] = useState();
    const [selectedTimeRange, setSelectedTimeRange] = useState();
    const [selectedYear, setSelectedYear] = useState();




    useEffect(() => {
        fetchLines();
        fetchYears();

    }, [])


    useEffect(() => {
        if (filters) {
            onFiltersChange(filters);
        }
    }, [filters, onFiltersChange]);



    // LINE FILTER
    useEffect(() => {
        if (selectedLine) {
            setFilters({ ...filters, line: selectedLine })
        }
    }, [selectedLine]);

    const selectLine = lines === undefined
        ? <p> </p>
        : <Form.Select className="col" onChange={(e) => setSelectedLine(e.target.value)} >
            <option value={"All"}>Ligne de train</option>

            {lines.map((line, i) =>
                <option key={i} value={line}>{line}</option>
            )}
        </Form.Select>

    // DAY FILTER
    useEffect(() => {
        if (selectedDayType) {
            setFilters({ ...filters, dayType: selectedDayType })
        }
    }, [selectedDayType]);
    const dayTypeOptions = ["Lundi-Vendredi", "Samedi", "Dimanche"]
    const selectDayType = <Form.Select className="col" onChange={(e) => setSelectedDayType(e.target.value)}>
             <option value={"All"}>Type de jour</option>
            {dayTypeOptions.map((option, i) =>
                <option key={i} value={i}>{option}</option>
            )}
    </Form.Select>

    // TIMERANGE FILTER
    useEffect(() => {
        if (selectedTimeRange) {
            setFilters({ ...filters, timeRange: selectedTimeRange })
        }
    }, [selectedTimeRange]);
    const timeRangeOptions = ["Avant 6h", "Entre 6h et 10h", "Entre 10h et 16h", "Entre 16h et 20h", `Apr${'\u00e8'}s 20h`]
    const selectTimeRange= <Form.Select className="col" onChange={(e) => setSelectedTimeRange(e.target.value)}>
        <option value={"All"}>Tranche horaire</option>
        {timeRangeOptions.map((option, i) =>
            <option key={i} value={i}>{option}</option>
        )}
    </Form.Select>


     // YEAR FILTER
    useEffect(() => {
        if (selectedYear) {
            setFilters({ ...filters, year: selectedYear })
        }
    }, [selectedYear]);
    const selectYear = years === undefined
        ? <p> </p>
        : <Form.Select className="col" onChange={(e) => setSelectedYear(e.target.value)}>
            <option value={"All"}>Ann{'\u00e9'}e</option>
                {years.map((option) =>
                <option key={option} value={option}>{option}</option>
            )}
         </Form.Select>



    return (
        <div className="d-flex justify-content-center gap-3 my-4" >
            {selectLine}
            {selectDayType}
            {selectTimeRange}
            {selectYear }
        </div>
    );




    async function fetchLines() {
        const lines = await fetch("https://localhost:44309/api/data/lines", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataLines = await lines.json();
        setLines(dataLines);
    }


    async function fetchYears() {
        const years = await fetch("https://localhost:44309/api/data/years", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataYears = await years.json();
        setYears(dataYears);
    }

}

export default Filters;