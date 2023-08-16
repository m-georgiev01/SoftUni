function solve(input) {
  const commandRunner = {
    StopForFuel: stopForFuel,
    Overtaking: overtake,
    EngineFail: engineFail,
    Finish: finishProgram,
  };

  let riders = [];
  const n = input.shift();

  for (let i = 0; i < n; i++) {
    const [rider, fuel, position] = input.shift().split('|');

    riders.push({ rider, fuel, position });
  }

  let isFinished = false;
  while (!isFinished) {
    const [command, ...rest] = input.shift().split(' - ');

    commandRunner[command](...rest);
  }

  function stopForFuel(rider, minimumFuel, changedPosition) {
    const wantedRider = riders.find((r) => r.rider === rider);

    if (Number(wantedRider.fuel) >= Number(minimumFuel)) {
      console.log(`${rider} does not need to stop for fuel!`);
      return;
    }

    wantedRider.position = changedPosition;

    console.log(
      `${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`
    );
  }

  function overtake(overtakingRider, overtakenRider) {
    const overtaking = riders.find((r) => r.rider === overtakingRider);
    const overtaken = riders.find((r) => r.rider === overtakenRider);

    if (overtaking.position < overtaken.position) {
      [overtaking.position, overtaken.position] = [
        overtaken.position,
        overtaking.position,
      ];

      console.log(`${overtakingRider} overtook ${overtakenRider}!`);
    }
  }

  function engineFail(rider, lapsLeft) {
    const searchedRider = riders.find((r) => r.rider === rider);

    riders.splice(riders.indexOf(searchedRider), 1);
    console.log(
      `${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
    );
  }

  function finishProgram() {
    isFinished = true;

    riders.forEach((r) => {
      console.log(`${r.rider}\nFinal position: ${r.position}`);
    });
  }
}
