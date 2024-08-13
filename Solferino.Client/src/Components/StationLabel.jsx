import React from "react";


const StationLabel = ({ station }) => {
    return (
        <div>
            <p className="fs-5 fw-bolder mb-0">  {station.name} </p>
            <p> {station.nbOfPassengers} passagers</p>
            <div className="d-flex gap-1 align-items-start">
                {station.lines.map((line, i) =>
                    <div key={i} className="rounded-pill badge bg-info"> {line} </div>
                )}
            </div>
        </div>
    )


}

export default StationLabel;