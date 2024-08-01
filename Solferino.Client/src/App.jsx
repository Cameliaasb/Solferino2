import { useEffect, useState } from 'react';
import './App.css';
import SimpleMap from './Map';


function App() {
    
    return (
        <div>
            <h1 id="tableLabel">Carte des transiliens</h1>
            <SimpleMap />
        </div>
    );

}

export default App;