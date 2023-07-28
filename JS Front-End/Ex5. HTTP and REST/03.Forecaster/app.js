function attachEvents() {
  document
    .querySelector('#submit')
    .addEventListener('click', getWeatherForLocation);
}

const weatherSymbols = {
  Sunny: '☀',
  'Partly sunny': '⛅',
  Overcast: '☁',
  Rain: '☂',
};

const API_URL = 'http://localhost:3030/jsonstore/forecaster/';

const service = {
  async getLocations() {
    return (await fetch(`${API_URL}/locations`)).json();
  },
  async getCurrentConditions(code) {
    return (await fetch(`${API_URL}/today/${code}`)).json();
  },

  async getUpcomingWeather(code) {
    return (await fetch(`${API_URL}/upcoming/${code}`)).json();
  },
};

async function getWeatherForLocation() {
  const locationName = document.querySelector('#location').value;
  const locationResponse = await service.getLocations();

  const location = locationResponse.find(
    (l) => l.name.toLowerCase() === locationName.toLowerCase()
  );

  const [currentConditions, upcomingWeather] = await Promise.all([
    service.getCurrentConditions(location.code),
    service.getUpcomingWeather(location.code),
  ]);

  //make forecast container visible
  document.querySelector('#forecast').style.display = 'block';

  document
    .querySelector('#current')
    .appendChild(createCurrentWeatherContainer(currentConditions));

  document
    .querySelector('#upcoming')
    .appendChild(createUpcomingWeatherContainer(upcomingWeather.forecast));
}

function createCurrentWeatherContainer(currentConditions) {
  const forecastsContainer = document.createElement('div');
  forecastsContainer.classList.add('forecasts');

  forecastsContainer.appendChild(
    createSpanElement(
      ['condition', 'symbol'],
      weatherSymbols[currentConditions.forecast.condition]
    )
  );

  forecastsContainer.appendChild(
    createSpanContainerForCurrentConditions(currentConditions)
  );

  return forecastsContainer;
}

function createUpcomingWeatherContainer(forecastArray) {
  const forecastsContainer = document.createElement('div');
  forecastsContainer.classList.add('forecast-info');

  forecastArray.forEach((forecastObject) => {
    forecastsContainer.appendChild(
      createSpanContainerForUpcomingConditions(forecastObject)
    );
  });

  return forecastsContainer;
}

function createSpanElement(classArray, textContent) {
  const span = document.createElement('span');
  span.classList.add(...classArray);
  span.textContent = textContent;

  return span;
}

function createSpanContainerForCurrentConditions(currentConditions) {
  const conditionsSpanContainer = createSpanElement(['condition']);

  conditionsSpanContainer.appendChild(
    createSpanElement(['forecast-data'], currentConditions.name)
  );

  conditionsSpanContainer.appendChild(
    createSpanElement(
      ['forecast-data'],
      `${currentConditions.forecast.low}°/${currentConditions.forecast.high}°`
    )
  );

  conditionsSpanContainer.appendChild(
    createSpanElement(['forecast-data'], currentConditions.forecast.condition)
  );

  return conditionsSpanContainer;
}

function createSpanContainerForUpcomingConditions(forecastObject) {
  const conditionsSpanContainer = createSpanElement(['upcoming']);

  conditionsSpanContainer.appendChild(
    createSpanElement(['symbol'], weatherSymbols[forecastObject.condition])
  );

  conditionsSpanContainer.appendChild(
    createSpanElement(
      ['forecast-data'],
      `${forecastObject.low}°/${forecastObject.high}°`
    )
  );

  conditionsSpanContainer.appendChild(
    createSpanElement(['forecast-data'], forecastObject.condition)
  );

  return conditionsSpanContainer;
}

attachEvents();
