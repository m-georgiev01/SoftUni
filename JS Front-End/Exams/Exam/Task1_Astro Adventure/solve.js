function solve(input) {
  const commandRunner = {
    Explore: explore,
    Refuel: refuel,
    Breathe: rechargeoxygen,
    End: finishProgram,
  };

  let astronauts = {};
  const n = input.shift();

  for (let i = 0; i < n; i++) {
    const [astronautName, oxygen, energy] = input.shift().split(' ');

    astronauts[astronautName] = { astronautName, oxygen, energy };
  }

  let isFinished = false;
  while (!isFinished) {
    const [command, ...rest] = input.shift().split(' - ');

    commandRunner[command](...rest);
  }

  function explore(astronautName, energyNeeded) {
    if (Number(astronauts[astronautName].energy) < Number(energyNeeded)) {
      console.log(`${astronautName} does not have enough energy to explore!`);
      return;
    }

    astronauts[astronautName].energy -= energyNeeded;
    console.log(
      `${astronautName} has successfully explored a new area and now has ${astronauts[astronautName].energy} energy!`
    );
  }

  function refuel(astronautName, amount) {
    const energyBeforeRefuel = astronauts[astronautName].energy;

    Number(astronauts[astronautName].energy) + Number(amount) > 200
      ? (astronauts[astronautName].energy = 200)
      : (astronauts[astronautName].energy =
          Number(astronauts[astronautName].energy) + Number(amount));

    console.log(
      `${astronautName} refueled their energy by ${
        astronauts[astronautName].energy - energyBeforeRefuel
      }!`
    );
  }

  function rechargeoxygen(astronautName, amount) {
    const oxygenBeforeRefuel = astronauts[astronautName].oxygen;

    Number(astronauts[astronautName].oxygen) + Number(amount) > 100
      ? (astronauts[astronautName].oxygen = 100)
      : (astronauts[astronautName].oxygen =
          Number(astronauts[astronautName].oxygen) + Number(amount));

    console.log(
      `${astronautName} took a breath and recovered ${
        astronauts[astronautName].oxygen - oxygenBeforeRefuel
      } oxygen!`
    );
  }

  function finishProgram() {
    isFinished = true;

    Object.values(astronauts).forEach((a) => {
      console.log(
        `Astronaut: ${a.astronautName}, Oxygen: ${a.oxygen}, Energy: ${a.energy}`
      );
    });
  }
}

// solve([
//   '3',
//   'John 50 120',
//   'Kate 80 180',
//   'Rob 70 150',
//   'Explore - John - 50',
//   'Refuel - Kate - 30',
//   'Breathe - Rob - 20',
//   'End',
// ]);

solve([
  '4',
  'Alice 60 100',
  'Bob 40 80',
  'Charlie 70 150',
  'Dave 80 180',
  'Explore - Bob - 60',
  'Refuel - Alice - 30',
  'Breathe - Charlie - 50',
  'Refuel - Dave - 40',
  'Explore - Bob - 40',
  'Breathe - Charlie - 30',
  'Explore - Alice - 40',
  'End',
]);
