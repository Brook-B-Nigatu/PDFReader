import PropTypes from "prop-types";


export default function DisplayPdf({ url }) {
    return (
        <iframe src={url}/>
    )
}

DisplayPdf.propTypes = {
    url : PropTypes.string.isRequired
}
