import PropTypes from 'prop-types'; 
import { useState } from 'react';

export default function FileList({ fileNames, setUrl }) {

    return (
        fileNames.map((f, i) => <FileListItem key={i} fileName={f} setUrl={ setUrl } />)
    );
    
}

function FileListItem({ id, fileName, setUrl }) {
    const [fileUrl, setFileUrl] = useState("");
    const fetchFile = async () => {
        const response = await fetch(`api/download/${id}`);
        const blb = await response.blob();
        const url = URL.createObjectURL(blb);
        setFileUrl(url);
        setUrl(url);
    }
    const handleClick = () => {
        if (fileUrl == "") {
            fetchFile();
        }
        else {
            setUrl(fileUrl);
        }
        
    }

    return (
        <button onClick={handleClick}>{fileName}</button>
    );
}

FileListItem.propTypes = {
    id: PropTypes.int.isRequired,
    fileName: PropTypes.string.isRequired,
    setUrl : PropTypes.func.isRequired
};
