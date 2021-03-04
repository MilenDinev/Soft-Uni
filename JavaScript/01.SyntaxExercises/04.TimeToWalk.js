function timeToWalk(steps, footprint, speedKmH){
    speedInMetersPerSecond = speedKmH * 1000 / 3600;
    totalDistance = steps * footprint;
    timeRest = Math.floor(totalDistance / 500);
    totalTime = (totalDistance / speedInMetersPerSecond) + (timeRest * 60);

    hours = Math.floor(totalTime/3600).toFixed(0).padStart(2, '0');
    minutes = Math.floor((totalTime - hours * 3600) / 60 ).toFixed(0).padStart(2, '0');
    seconds = (totalTime - hours*3600 - minutes*60).toFixed(0).padStart(2, '0');

    return `${hours}:${minutes}:${seconds}`;
}

console.log(timeToWalk(4000, 0.60, 5));
console.log(timeToWalk(2564, 0.70, 5.5));