export const GetForecastData = async (Lat, Long, setLoadFailed) => {
    const data = await fetch(`forecast?latitude=${Lat}&longitude=${Long}`, { mode: 'cors' }).then(res => res.json()).catch(() => setLoadFailed(true));
    return data;
}

export const GetCoordinateData = async (address, setLoadFailed) => {

    if (address.Street === "") {
        return null;
    }
    else if (address.Zip === "" && (address.City === "" || address.State === "")) {
        return null;
    }
    else {
        const data = await fetch(`coordinate?street=${address.Street}&city=${address.City}&state=${address.State}&zip=${address.Zip}`, { mode: 'cors' }).then(res => res.json()).catch(() => setLoadFailed(true));

        return data;
    }
}

