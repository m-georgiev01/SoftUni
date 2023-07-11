function printTowns(townsInfo) {
  townsInfo.forEach((element) => {
    let [town, latitude, longitude] = element.split(' | ');

    const townObj = {
      town,
      latitude: Number.parseFloat(latitude).toFixed(2),
      longitude: Number.parseFloat(longitude).toFixed(2),
    };

    console.log(townObj);
  });
}
