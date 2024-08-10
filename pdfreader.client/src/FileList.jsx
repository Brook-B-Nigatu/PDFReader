import PropTypes from 'prop-types'; 


export default function FileList({ fileNames, setUrl }) {

    return (
        fileNames.map((f, i) => <FileListItem key={i} fileName={f} setUrl={ setUrl } />)
    );
    
}

function FileListItem({ fileName, setUrl }) {
    const fetchFile = async () => {
        const response = await fetch(`api/download/${fileName}`);
        const blb = await response.blob();
        const url = URL.createObjectURL(blb);
        await setUrl(url);
    }

    return (
        <button onClick={fetchFile}>{fileName}</button>
    );
}

FileListItem.propTypes = {
    fileName: PropTypes.string.isRequired,
    setUrl : PropTypes.func.isRequired
};
