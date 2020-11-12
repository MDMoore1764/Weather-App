import { useReducer, useState, useEffect} from 'react';
import './App.css';
import LocationInput from './ScreenComponents/LocationInput';
import TodaysWeather from './ScreenComponents/TodaysWeather';
import SevenDayWeather from "./ScreenComponents/SevenDayWeather";
import NightModeBox from "./ScreenComponents/NightModeBox"
import React from 'react'

import { GetForecastData } from "./API Access/APIAccess";

const App = () => {

    //#region State Handlers

    const [coordinateState, setCoordinatesState] = useState({ Lat: 0, Long: 0 });


    const setCoordinates = ({ Lat, Long }) => {

        setCoordinatesState({ Lat: Lat, Long: Long });
        setLocationFound(true);

        GetForecastData(Lat, Long, setLoadFailed).then((result) => {
            setForecastState(result);
            if (result != null) {
                console.log(result);
                setNightMode(nightMode ? nightMode : !result.Forecast.properties.periods[0].isDaytime);
            }
            setWeatherPeriod(0);
        });

    }

    const [weatherPeriod, setWeatherPeriod] = useState(0);

    const [addressState, addressDispatch] = useReducer(AddressReducer, { Street: "", City: "", State: "", Zip: "" });

    const [locationFound, setLocationFound] = useState(false);

    const [forecastState, setForecastState] = useState(null);

    const [nightMode, setNightMode] = useState(false);

    const [loadFailed, setLoadFailed] = useState(false);

    //#endregion

    //attempt to set location data on page load. If it is not available, we will not change it. Instead, we will default to 0, 0, and wait for user to enter location. 
    useEffect(() => {
        navigator.geolocation.getCurrentPosition((ele) => setLocationFound(true));

        if (locationFound && coordinateState.Lat === 0 && coordinateState.Long === 0) {
            navigator.geolocation.getCurrentPosition((position) => {
                setCoordinates({ Lat: position.coords.latitude, Long: position.coords.longitude });

            });
        }


    });

    const style = {
        background: !nightMode ? "rgb(240, 240, 240)" : "radial-gradient(ellipse at bottom, #0d1E31, #111)"
    };

    //everything is rendered below:
    return (
        <div id="MainBody" style={style} >
            <NightModeBox isDay={!nightMode} setNightMode={setNightMode} forecast={forecastState} />
            <TodaysWeather forecast={forecastState} locationFound={locationFound} isDay={!nightMode} weatherPeriod={weatherPeriod} refresh={() => setCoordinates(coordinateState)} loadFailed={loadFailed} />
            <SevenDayWeather isDay={!nightMode} forecast={forecastState} setPeriod={setWeatherPeriod} />
            <LocationInput setCoordinates={setCoordinates} address={addressState} addressDispatch={addressDispatch} States={States} isDay={!nightMode} setLoadFailed={setLoadFailed} />
        </div>
    );
}



const AddressReducer = (state, action) => {
    switch (action.param) {
        case 'Street':
            {
                return { ...state, Street: action.payload };
            }
        case 'City':
            {
                return { ...state, City: action.payload };
            }
        case 'State':
            {
                //basically, make sure  the initial dropdown option doesn't get added to state.
                if (States.includes(action.payload)) {
                    return { ...state, State: action.payload };
                }
                else {
                    //Makes it blank/unselected fopr highlighting purposes.
                    return { ...state, State: "" };
                }
            }
        case 'Zip':
            {
                return { ...state, Zip: action.payload };
            }
        case 'All':
            {
                return { ...state, Street: action.Street, City: action.City, State: action.State, Zip: action.Zip };
            }
        default: {
            throw new Error();
        }
    }

}

const States = [
    "Alabama",
    "Alaska",
    "Arizona",
    "Arkansas",
    "California",
    "Colorado",
    "Connecticut",
    "Delaware",
    "Florida",
    "Georgia",
    "Hawaii",
    "Idaho",
    "Illinois",
    "Indiana",
    "Iowa",
    "Kansas",
    "Kentucky",
    "Louisiana",
    "Maine",
    "Maryland",
    "Massachusetts",
    "Michigan",
    "Minnesota",
    "Mississippi",
    "Missouri",
    "MontanaNebraska",
    "Nevada",
    "New Hampshire",
    "New Jersey",
    "New Mexico",
    "New York",
    "North Carolina",
    "North Dakota",
    "Ohio",
    "Oklahoma",
    "Oregon",
    "Pennsylvania",
    "Rhode Island",
    "South Carolina",
    "South Dakota",
    "Tennessee",
    "Texas",
    "Utah",
    "Vermont",
    "Virginia",
    "Washington",
    "West Virginia",
    "Wisconsin",
    "Wyoming"
];



export default App;
