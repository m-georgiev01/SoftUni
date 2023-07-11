function printEmployees(employeesInfo) {
  employeesInfo.forEach((employeeName) => {
    const employee = {
      employeeName,
      personalNum: employeeName.length,
      print() {
        return `Name: ${this.employeeName} -- Personal Number: ${this.personalNum}`;
      },
    };

    console.log(employee.print());
  });
}
