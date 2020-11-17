import React from 'react'
import "../StyleComponents/TodaysWeather.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSync } from '@fortawesome/free-solid-svg-icons'


const TodaysWeather = (props) => {

    const currentForecast = props.forecast;
    const styles = {
        background: props.isDay ? "rgb(210, 225, 235)" : "radial-gradient(ellipse at bottom, #14202c 0%, rgb(20, 12, 43) 100%)",
        color: props.isDay ? "rgb(20, 12, 43)" : "rgb(245, 245, 245)",
        border: props.isDay ? "2px solid rgba(0, 0, 0, 0.05)" : "1px solid rgba(255, 255, 255, 0.8)"
    };

    const NullDisplay = () => {
        return (
            <div className="variable-body" style={{ textAlign: "center" }}>
                <p>Unable to fetch location. Please try again later.</p>
            </div>
        );
    }

    const LoadingDisplay = () => {
        return (
            <div className="variable-body" style={{ textAlign: "center" }}>
                {props.locationFound ? <p>Loading Location Data</p> : <p>Please enter a location or enable your location to see local forecast</p>}
            </div>
        );
    }


    const TempUnits = ['F', 'C'];

    const StarryNight = () => {
        return (
            <div className="variable-body" style={{ height: "0px" }}>
                <div className="night">
                    <div className="star"></div>
                    <div className="star"></div>
                    <div className="star"></div>
                    <div className="star"></div>
                    <div className="star"></div>
                </div>
                <div className="stars"></div>
                <div className="twinkling"></div>
            </div>

        );
    }
    const Display = () => {
        if (currentForecast == null) {
            return null;
        }
        else {
            console.log(currentForecast);
            let windSpeedValue = currentForecast.Forecast.properties.periods[props.weatherPeriod].windSpeed.substring(0, 2).trim();
            //let windSpeedUnit = currentForecast.Forecast.properties.periods[0].windSpeed.substring(2).trim();

            let windDirection = { North: "North", NorthEast: "North-East", East: "East", SouthEast: "South-East", South: "South", SouthWest: "South-West", West: "West", NorthWest: "North-West" };

            const GetWindDirection = (abbreviation) => {
                let abb = abbreviation.toLowerCase();
                switch (abb) {
                    case ("n"): {
                        return windDirection.North;
                    }
                    case ("ne"): {
                        return windDirection.NorthEast
                    }
                    case ("e"): {
                        return windDirection.East
                    }
                    case ("se"): {
                        return windDirection.SouthEast
                    }
                    case ("s"): {
                        return windDirection.South
                    }
                    case ("sw"): {
                        return windDirection.SouthWest
                    }
                    case ("w"): {
                        return windDirection.West
                    }
                    case ("nw"): {
                        return windDirection.NorthWest
                    }
                    default: {
                        return abbreviation;
                    }
                }
            }

            const monthNames = ["January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            ];

            const MinConvert = (num) => {
                if (num < 10) {
                    return "0" + num;
                }
                else {
                    return num;
                }
            }
            let am = true;
            const HourConvert = (hour) => {
                //0 = midnight, 23 == 11 pm
                if (hour > 11) {
                    am = false;
                }
                else {
                    am = true;
                }
                if (hour > 12) {
                    return hour - 12;
                }
                else {
                    return hour;
                }
            }

            const GetShorterForecast = (fc) => {
                //search for and remove unimportant words
                fc = fc.replaceAll("Showers", "");
                fc = fc.replaceAll("Slight", "");

                return fc;
            }

            let now = new Date();
            return (
                <div className="variable-body">
                    <div className="todays-weather-internal">
                        <div className="refresh-button-container" onClick={props.refresh} >
                            <FontAwesomeIcon icon={faSync} className="fa-lg refresh-button" alt="refresh button" />
                            <p className="refresh-text">Updated {monthNames[now.getMonth()]}, {now.getDate()} at {HourConvert(now.getHours())}:{MinConvert(now.getMinutes())} {am ? "am" : "pm"}</p>
                        </div>
                        <div className="header-container">
                            <p className="name">{currentForecast.Forecast.properties.periods[props.weatherPeriod].name}</p>
                            <p className="location">{currentForecast.properties.relativeLocation.properties.city}, {currentForecast.properties.relativeLocation.properties.state}</p>
                        </div>

                        <div className="image-context-container">
                            <div className="weather-temp-container">
                                <p className="shortForecast title" >{GetShorterForecast(currentForecast.Forecast.properties.periods[props.weatherPeriod].shortForecast)}</p>
                                <div className="weather-container">
                                    <div className="image-container">
                                        <img className="icon" src={currentForecast.Forecast.properties.periods[props.weatherPeriod].icon} alt="icon" />
                                    </div>
                                    <div className="temperature-container">
                                        <p className="temperature">{currentForecast.Forecast.properties.periods[props.weatherPeriod].temperature}</p>
                                        <p className="unit temperatureUnit">{TempUnits[currentForecast.Forecast.properties.periods[props.weatherPeriod].temperatureUnit]}</p>
                                    </div>
                                </div>
                            </div>
                            <div className="spacing-container"></div>


                            <div className="wind-container">
                                <p className="windSpeedTitle title">{GetWindDirection(currentForecast.Forecast.properties.periods[props.weatherPeriod].windDirection)} Winds<span className="windDirection"></span></p>
                                <p className="windSpeed"> <span className="windSpeedValue">{windSpeedValue}</span>
                                    <span className="unit">mph</span>
                                </p>
                            </div>

                        </div>
                        <div className="detailedForecast">
                            <p className="name">Details</p>
                            <p className="details"> {currentForecast.Forecast.properties.periods[props.weatherPeriod].detailedForecast}</p>
                        </div>

                    </div>
                </div>

            );
        }
    }



    return (
        <div className="container d-flex todays-weather-container" style={styles}>
            {!props.isDay ? StarryNight() : null}
            {props.loadFailed ? NullDisplay() : (currentForecast === null || currentForecast === undefined) ? LoadingDisplay() : Display()}
        </div>
    );
}


export default TodaysWeather;