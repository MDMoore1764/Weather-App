import React from 'react'

const NightModeBox = (props) => {

    const textStyles = {
        color: props.isDay ? "rgb(20, 12, 43)" : "rgb(245, 245, 245)"
    }

    const buttonStyle={
        backgroundColor: props.isDay? "rgb(20, 12, 43)" : "rgb(245, 245, 245)"
    }

    if (props.forecast != null) {
        return (
            <div className="night-mode-box">
                <button value={props.isDay} onClick={() => props.setNightMode(props.isDay)} className="night-mode-button" style = {buttonStyle}/><span className="night-mode-text" style = {textStyles}>{!props.isDay ? "Enable Day Mode" : "Enable Night Mode"}</span>
            </div>
        );
    }
    else {
        return null;
    }

}

export default NightModeBox;
