function solve(input) {
  const heroes = [];
  const regex = /[ /,]+/gm;

  input.forEach((element) => {
    const [name, level, ...items] = element.split(regex);
    heroes.push({
      name,
      level,
      items,
      printHero() {
        return `Hero: ${this.name}\nlevel => ${
          this.level
        }\nitems => ${this.items.join(', ')}`;
      },
    });
  });

  heroes.sort((a, b) => a.level - b.level);

  heroes.forEach((hero) => {
    console.log(hero.printHero());
  });
}
