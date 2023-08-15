function solve(input) {
  const commandRunner = {
    Retake: retakeHorse,
    Trouble: dropHorsePositionByOne,
    Rage: rageHorseTwoPositions,
    Miracle: makeHorseFirst,
    Finish: finishProgram,
  };

  const horses = input.shift().split('|');

  let isFinished = false;
  while (!isFinished) {
    const [command, ...rest] = input.shift().split(' ');

    commandRunner[command](...rest);
  }

  function retakeHorse(overtakingHorse, overtakenHorse) {
    const indexOvertaking = horses.indexOf(overtakingHorse);
    const indexOvertaken = horses.indexOf(overtakenHorse);

    if (indexOvertaking < indexOvertaken) {
      [horses[indexOvertaking], horses[indexOvertaken]] = [
        horses[indexOvertaken],
        horses[indexOvertaking],
      ];

      console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
    }
  }

  function dropHorsePositionByOne(horse) {
    const indexHorseForDrop = horses.indexOf(horse);

    if (indexHorseForDrop === 0) {
      return;
    }

    const endIndexForDrop = indexHorseForDrop - 1;

    const horseToDrop = horses.splice(indexHorseForDrop, 1)[0];
    horses.splice(endIndexForDrop, 0, horseToDrop);

    console.log(`Trouble for ${horseToDrop} - drops one position.`);
  }

  function rageHorseTwoPositions(horse) {
    const indexHorse = horses.indexOf(horse);
    const endIndexForRage =
      indexHorse + 2 > horses.length - 1 ? horses.length - 1 : indexHorse + 2;

    const element = horses.splice(indexHorse, 1)[0];
    horses.splice(endIndexForRage, 0, element);

    console.log(`${element} rages 2 positions ahead.`);
  }

  function makeHorseFirst() {
    const miracleHorse = horses.splice(0, 1)[0];
    horses.splice(horses.length, 0, miracleHorse);

    console.log(`What a miracle - ${miracleHorse} becomes first.`);
  }

  function finishProgram() {
    isFinished = true;

    console.log(horses.join('->'));
    console.log(`The winner is: ${horses[horses.length - 1]}`);
  }
}

solve([
  'Fancy|Lilly',
  'Retake Lilly Fancy',
  'Trouble Lilly',
  'Trouble Lilly',
  'Finish',
  'Rage Lilly',
]);
