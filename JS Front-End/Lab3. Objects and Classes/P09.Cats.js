function solve(catsInfo) {
  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  catsInfo.forEach((element) => {
    const [name, age] = element.split(' ');
    const cat = new Cat(name, age);
    cat.meow();
  });
}
