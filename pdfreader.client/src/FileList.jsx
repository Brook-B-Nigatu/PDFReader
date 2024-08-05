import PropTypes from 'prop-types'; 


export default function FileList({ fileNames }) {

    return (
        fileNames.map((f, i) => <FileListItem key={i} fileName={f} />)
    );
    
}

function FileListItem({ fileName }) {
    return (
        <p>{fileName}</p>
    );
}

FileListItem.propTypes = {
    fileName: PropTypes.string.isRequired
};
