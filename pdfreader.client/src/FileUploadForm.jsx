import { useState } from 'react';

export default function FileUploadForm() {
    const [file, setFile] = useState();

    const handleSubmit = async (event) => {
        event.preventDefault();
        const formData = new FormData();
        formData.append('file', file);
        event.target.reset();

        try {
            await fetch("upload", {
                method: "Post",
                body: formData
            });

        }
        catch (e) {
            alert("Error Uploading File");
        }

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