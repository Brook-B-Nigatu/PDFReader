import FileUploadForm from "./FileUploadForm";
import FileList from "./FileList";
import { useState, useEffect } from 'react';


export default function Home() {

    const [fileNames, setFileNames] = useState([]);

    useEffect(
        () => { getFileNames() },
        []
    );


    async function getFileNames() {
        const response = await fetch("api/download");

        setFileNames(await response.json());
    }

    return (
        <div>
            <FileUploadForm />
            <FileList fileNames={fileNames} />
        </div>
     )
}