import React from 'react'
import '../StyleComponents/LocationInput.css'
import {GetCoordinateData} from "../API Access/APIAccess";

const LocationInput = (props) => {

    const RenderStateOptions = () => {
        var optionList = props.States.map((element) => {
            return <option key={element} className="dropdown-item">{element}</option>;
        });
        return (
            optionList
        );
    }

    let SubmitInformation = async () => {
        const data = await GetCoordinateData(props.address, props.setLoadFailed);
        if(data == null) return;
        props.setCoordinates({Lat: data.y, Long: data.x});
    }

    let ResetForm = () =>{
        props.addressDispatch({param: 'All', Street: "", City: "", State: "", Zip: ""});
    }

    const stylesNoBack = {
        //backgroundColor: props.isDay ? "rgb(232, 237, 255)" : "rgb(20, 12, 43)",
        color: props.isDay ? "rgb(20, 12, 43)" : "rgb(245, 245, 245)"
    };

    const borderStyle = {
            border: props.isDay? "2px solid rgba(0, 0, 0, 0.05)" : "1px solid rgba(255, 255, 255, 0.8)"

    }

    return (
        <div className="d-flex-column" >

            <div className="location-input-body col-sm-10 col-md-8 col-lg-6 col-xl-5 container-fluid mt-2" style = {borderStyle}>
                <p className="pt-2 pb-2 mb-0" style = {stylesNoBack}>Enter a location to see local weather</p>

                <div className="input-container mt-0">
                    <form className="location-input-group">
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3">Street</span>
                            </div>
                            <input type="text" className="form-control" id="basic-url" aria-describedby="basic-addon3" onChange={(event) => props.addressDispatch({ param: 'Street', payload: event.target.value })} value={props.address.Street} />
                        </div>
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3">City</span>
                            </div>
                            <input type="text" className="form-control" id="basic-url" aria-describedby="basic-addon3" onChange={(event) => props.addressDispatch({ param: 'City', payload: event.target.value })} value={props.address.City} />
                        </div>

                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3" > State</span>
                            </div>
                            <select className="form-control"  onChange={(event) => props.addressDispatch({ param: 'State', payload: event.target.value })} value={props.address.State}>
                                <option className="dropdown-item">Select Your State</option>
                                {RenderStateOptions()}
                            </select>
                        </div>

                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3">Zip Code</span>
                            </div>
                            <input type="text" className="form-control" id="basic-url" aria-describedby="basic-addon3" onChange={(event) => props.addressDispatch({ param: 'Zip', payload: event.target.value })} value={props.address.Zip} />
                        </div>
                    </form>
                </div>
                <div className="button-container d-flex">
                    <button className="btn reset-btn" onClick={ResetForm}>Reset</button>
                    <button className="btn search-btn" onClick={SubmitInformation}>Search!</button>

                </div>
            </div>
        </div>


    );

    
}





export default LocationInput;