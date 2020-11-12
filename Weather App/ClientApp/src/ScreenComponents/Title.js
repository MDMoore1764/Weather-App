
import "../StyleComponents/Title.css"

const Title = (props) => {
    return (
        <div className="title-container">
            <div className="title-body jumbotron jumbotron-fluid">
                <h1>Your Weather Forecast</h1>
                <h6>
                    Location {props.LocationFound ? "found" : "not found"}
                </h6>
            </div>
        </div>
    );
}

export default Title;