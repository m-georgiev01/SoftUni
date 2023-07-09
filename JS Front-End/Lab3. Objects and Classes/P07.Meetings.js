function solve(arr) {
  const meetings = {};

  arr.forEach((element) => {
    [weekday, personName] = element.split(' ');

    if (!meetings.hasOwnProperty(weekday)) {
      meetings[weekday] = personName;
      console.log(`Scheduled for ${weekday}`);
    } else {
      console.log(`Conflict on ${weekday}!`);
    }
  });

  Object.entries(meetings).forEach(([key, value]) => {
    console.log(`${key} -> ${value}`);
  });
}
