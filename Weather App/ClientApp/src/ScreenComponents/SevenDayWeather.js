import "../StyleComponents/SevenDayWeather.css";
import Sunny from "../Resources/Images/CardIcons/sunIcon.png";
import Cloudy from "../Resources/Images/CardIcons/cloudIcon.svg";
import Rainy from "../Resources/Images/CardIcons/rainicon.png";
import Hail from "../Resources/Images/CardIcons/hailingIcon.png";
import PartlyCloudy from "../Resources/Images/CardIcons/Partly Cloudy.png";
import Sleet from "../Resources/Images/CardIcons/sleetIcon.png";
import Snow from "../Resources/Images/CardIcons/snowingIcon.jpg";
import Thunder from "../Resources/Images/CardIcons/thundericon.png";


import React from 'react'


const GetDayFromInt = (num) => {
    switch (num) {
        case 0: {
            return "Sunday";
        }
        case 1: {
            return "Monday";
        }
        case 2: {
            return "Tuesday";
        }
        case 3: {
            return "Wednesday";
        }
        case 4: {
            return "Thursday";
        }
        case 5: {
            return "Friday";
        }
        case 6: {
            return "Saturday";
        }
        default: {
            //it might as well be a Friday.
            return "Friday";
        }
    }
}

const TempUnits = ['F', 'C'];

const GetIconFromShortCast = (shortCast) => {
    //check for key words in the short forecast. If any match, return corresponding image
    shortCast = shortCast.toLowerCase();
    if (shortCast.includes("blizzard")) {
        return Snow;
    }
    else if (shortCast.includes("hail")) {
        return Hail;
    }
    else if (shortCast.includes("sleet")) {
        return Sleet;
    }
    else if (shortCast.includes("snow")) {
        return Snow;
    }
    else if (shortCast.includes("thunder")) {
        return Thunder;
    }
    else if (shortCast.includes("rain")) {
        return Rainy;
    }
    else if (shortCast.includes("partly cloudy") || shortCast.includes("partly sunny")) {
        return PartlyCloudy;
    }
    else if (shortCast.includes("cloud")) {
        return Cloudy;
    }
    else if (shortCast.includes("sun")) {
        return Sunny;
    }
    else {
        return Sunny;
    }
}

const SevenDayWeather = (props) => {

    const setPeriodChangeGlow = (period) => {
        props.setPeriod(period);
        document.querySelectorAll(".forecast-day-token").forEach((element) => {
            element.classList.remove("glow");
        });
        document.querySelector(`.day-${period}`).classList.add("glow");
    }

    const RenderDays = () => {
        if (props.forecast === null || props.forecast === undefined) {
            return (
                <div className="forecast-day">
                </div>
            );
        }
        let dayOfWeek = 0;
        let count = 0;
        let days = props.forecast.Forecast.properties.periods.map((element) => {

            if (element.isDaytime || count === 0) {
                if (dayOfWeek >= 6) {
                    dayOfWeek = 0;
                }
                else {
                    dayOfWeek++;
                }

                if (count === 0) {

                    let today = new Date(props.forecast.Forecast.properties.generatedAt);
                    dayOfWeek = today.getDay();
                }

                if (count < 14) {
                    let temp = count;
                    count++;

                    return (
                        <div className={`forecast-day-token day-${temp} ${temp === 0 ? "glow" : ""}`} key={temp} style={style} onClick={() => setPeriodChangeGlow(temp)}>
                            <p className="forecast-day">{GetDayFromInt(dayOfWeek)}</p>
                            <img className="forecast-day-background" src={GetIconFromShortCast(props.forecast.Forecast.properties.periods[temp].shortForecast)} alt="" />
                            <p ><span className="forecast-day-temperature">{props.forecast.Forecast.properties.periods[temp].temperature}</span><span className="forecast-day-unit">{TempUnits[props.forecast.Forecast.properties.periods[temp].temperatureUnit]}</span></p>
                        </div>
                    );
                }
            }
            count++;
            return null;
        });

        return days;
    }

    const style = {
        // border: props.isDay ? "2px solid rgba(0, 0, 0, 0.05)" : "1px solid rgba(255, 255, 255, 0.8)"
    }

    return (
        <div className="main-container container d-flex" style={style}>
            {RenderDays()}
        </div>
    );
}

export default SevenDayWeather;
