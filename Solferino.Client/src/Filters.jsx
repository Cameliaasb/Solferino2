import React, { useEffect, useState } from "react";
import Form from 'react-bootstrap/Form';

function Filters({ onFiltersChange }) {
    const [lines, setLines] = useState();
    const [selectedLine, setSelectedLine] = useState();


    useEffect(() => {
        fetchLines()
    }, [])


    useEffect(() => {
        if (selectedLine) {
            onFiltersChange(selectedLine);
        }
    }, [selectedLine, onFiltersChange]);


    const selectLine = lines === undefined
        ? <p> </p>
        : <Form.Select className="col" onChange={(e) => setSelectedLine(e.target.value)} >
            <option value={""}>Selectionner une ligne de train</option>

            {lines.map((line, i) =>
                <option key={i} value={line}>{line}</option>
            )}
        </Form.Select>


    return (
        <div>
            {selectLine}
        </div>
    );




    async function fetchLines() {
        const lines = await fetch("https://localhost:44309/api/trainstations/lines", {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        });
        const dataLines = await lines.json();
        setLines(dataLines);
    }

}

export default Filters;