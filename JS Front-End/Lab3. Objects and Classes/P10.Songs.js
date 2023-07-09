function songs(input) {
  class Song {
    constructor(type, name, time) {
      this.type = type;
      this.name = name;
      this.time = time;
    }
  }

  const typeToDisplay = input.pop();
  const [_, ...songs] = input;

  const result = songs
    .map((songAsText) => {
      const [type, name, length] = songAsText.split('_');
      return new Song(type, name, length);
    })
    .filter((song) => {
      if (typeToDisplay === 'all') {
        return song;
      }

      return song.type === typeToDisplay;
    })
    .map((song) => song.name)
    .join('\n');

  console.log(result);
}
