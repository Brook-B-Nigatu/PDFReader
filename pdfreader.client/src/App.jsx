import { useState } from 'react';
import './App.css';

function App() {
    const [file, setFile] = useState();

    const handleSubmit = async (event) => {
        event.preventDefault();
        const formData = new FormData();
        formData.append('file', file);
        console.log("HHHH");

    }
    const handleFile = (event) => {
        setFile(event.target.files[0]);
    }

    return (
        <form onSubmit={handleSubmit}>
            <input type='file' onChange={handleFile} />
            <button type='submit'>Upload</button>
        </form>
    )
}

export default App;