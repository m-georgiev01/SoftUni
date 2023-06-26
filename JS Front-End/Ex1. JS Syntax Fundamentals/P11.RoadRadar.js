function checkIsInSpeedLimit (currSpeed, area) {
    const areaLimits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    }

    const currSpeedLimit = areaLimits[area];
    const speedOverLimit = currSpeed - currSpeedLimit;

    if (speedOverLimit <= 0) {
        console.log(`Driving ${currSpeed} km/h in a ${currSpeedLimit} zone`);
        return;
    }

    const speedingMsg = 
        speedOverLimit <= 20
        ? 'speeding'
        : speedOverLimit <= 40
        ? 'excessive speeding'
        : 'reckless driving';

    console.log(`The speed is ${speedOverLimit} km/h faster than the allowed speed of ${currSpeedLimit} - ${speedingMsg}`);
}