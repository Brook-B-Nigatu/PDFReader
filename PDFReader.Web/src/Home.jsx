import FileUploadForm from "./FileUploadForm";
import FileList from "./FileList";
import DisplayPdf from "./DisplayPdf";
import { useState, useEffect } from 'react';



export default function Home() {

    const [fileNames, setFileNames] = useState([]);
    const [activeFileUrl, setActiveFileUrl] = useState("");

    useEffect(
        () => { getFileNames() },
        []
    );

    useEffect(
        () => { console.log(activeFileUrl); },
        [activeFileUrl]
    );


    async function getFileNames() {
        const response = await fetch("api/download");

        setFileNames(await response.json());
    }

    return (
        <div>
            <FileUploadForm />
            <FileList fileNames={fileNames} setUrl={setActiveFileUrl} />
            <DisplayPdf url={activeFileUrl} />
        </div>
     )
}