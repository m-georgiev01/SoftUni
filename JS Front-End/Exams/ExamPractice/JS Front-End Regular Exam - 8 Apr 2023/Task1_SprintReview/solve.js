function solve(input) {
  class Assignee {
    #tasks = [];

    constructor(name, task) {
      this.name = name;
      this.#tasks.push(task);
    }

    addNewTask(task) {
      this.#tasks.push(task);
    }

    getTask(taskId) {
      return this.#tasks.find((t) => t.taskId === taskId);
    }

    getTasksWithGivenStatus(status) {
      return this.#tasks.filter((t) => t.status === status);
    }

    removeTask(index) {
      this.#tasks.splice(index, 1);
    }

    getTasksLenght() {
      return this.#tasks.length;
    }
  }

  class Task {
    constructor(taskId, title, status, estimatedPoints) {
      this.taskId = taskId;
      this.title = title;
      this.status = status;
      this.estimatedPoints = estimatedPoints;
    }
  }
  const innitialState = [];

  const n = input.shift();
  for (let i = 0; i < n; i++) {
    const [assigneeName, taskId, title, status, estimatedPoints] = input
      .shift()
      .split(':');

    const task = new Task(taskId, title, status, estimatedPoints);

    //if assignee is already in the initial state
    let assignee = innitialState.find((a) => a.name === assigneeName);
    if (assignee) {
      assignee.addNewTask(task);
      continue;
    }

    assignee = new Assignee(assigneeName, task);

    innitialState.push(assignee);
  }

  input.forEach((command) => {
    const [currCommand, assignee, taskId, ...taskInfo] = command.split(':');

    switch (currCommand) {
      case 'Add New':
        const [title, status, estimatedPoints] = taskInfo;

        addNew(assignee, taskId, title, status, estimatedPoints);
        break;

      case 'Change Status':
        const newStatus = taskInfo[0];

        const wantedAssignee = innitialState.find((a) => a.name === assignee);

        if (!wantedAssignee) {
          console.log(`Assignee ${assignee} does not exist on the board!`);
          return;
        }

        const wantedTask = wantedAssignee.getTask(taskId);
        if (!wantedTask) {
          console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
          return;
        }

        wantedTask.status = newStatus;
        break;

      case 'Remove Task':
        const wantedAssign = innitialState.find((a) => a.name === assignee);

        if (!wantedAssign) {
          console.log(`Assignee ${assignee} does not exist on the board!`);
          return;
        }

        if (taskId < 0 || taskId > wantedAssign.getTasksLenght() - 1) {
          console.log('Index is out of range!');
          return;
        }

        wantedAssign.removeTask(taskId);
        break;
    }
  });

  let toDoTasksTotalPoints = 0;
  let inProgressTasksTotalPoints = 0;
  let codeReviewTasksTotalPoints = 0;
  let doneTasksTotalPoints = 0;

  innitialState.forEach((assignee) => {
    toDoTasksTotalPoints += assignee
      .getTasksWithGivenStatus('ToDo')
      .reduce((acc, curr) => {
        return acc + Number(curr.estimatedPoints);
      }, 0);

    inProgressTasksTotalPoints += assignee
      .getTasksWithGivenStatus('In Progress')
      .reduce((acc, curr) => {
        return acc + Number(curr.estimatedPoints);
      }, 0);

    codeReviewTasksTotalPoints += assignee
      .getTasksWithGivenStatus('Code Review')
      .reduce((acc, curr) => {
        return acc + Number(curr.estimatedPoints);
      }, 0);

    doneTasksTotalPoints += assignee
      .getTasksWithGivenStatus('Done')
      .reduce((acc, curr) => {
        return acc + Number(curr.estimatedPoints);
      }, 0);
  });

  console.log(`ToDo: ${toDoTasksTotalPoints}pts`);
  console.log(`In Progress: ${inProgressTasksTotalPoints}pts`);
  console.log(`Code Review: ${codeReviewTasksTotalPoints}pts`);
  console.log(`Done Points: ${doneTasksTotalPoints}pts`);

  if (
    doneTasksTotalPoints >=
    toDoTasksTotalPoints +
      inProgressTasksTotalPoints +
      codeReviewTasksTotalPoints
  ) {
    console.log('Sprint was successful!');
  } else {
    console.log('Sprint was unsuccessful...');
  }

  function addNew(assignee, taskId, title, status, estimatedPoints) {
    const wantedAssignee = innitialState.find((a) => a.name === assignee);

    if (!wantedAssignee) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }
    const task = new Task(taskId, title, status, estimatedPoints);
    wantedAssignee.addNewTask(task);
  }
}

solve([
  '4',
  'Kiril:BOP-1213:Fix Typo:Done:1',
  'Peter:BOP-1214:New Products Page:In Progress:2',
  'Mariya:BOP-1215:Setup Routing:ToDo:8',
  'Georgi:BOP-1216:Add Business Card:Code Review:3',
  'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
  'Change Status:Georgi:BOP-1216:Done',
  'Change Status:Will:BOP-1212:In Progress',
  'Remove Task:Georgi:3',
  'Change Status:Mariya:BOP-1215:Done',
]);
