**Overview** <br />
This .NET 6 project is an API that allows users to search for movie names and retrieve detailed information along with available video URLs.
The movie details are sourced from the OMDb API, and video URLs are fetched from YouTube. The project follows a clean architecture design.

**Features** <br />
**Movie Search**: Users can search for movie names. <br />
**Detailed Information**: Retrieve detailed movie information from OMDb API. <br />
**Video URLs**: Fetch available video URLs from YouTube. <br />
**Clean Architecture**: The project is structured using the clean architecture design principles. <br />

**Configuration** <br />
Configure the application by editing the appsettings.json file in the root directory.

**Project Structure** <br />
The project follows a clean architecture design:

**src**: Contains the main source code. <br />
**Application**: Application-specific logic, and Domain entities. <br />
**Infrastructure**: External dependencies, third-party integrations, and data access. <br />
**Presentation**: Presentation layer (API controllers). <br />

**Dependencies** <br />
- OMDB <br />
- YouTube <br />

**Technical Decisions** : <br /> 

**Clean Architecture Usage** <br />
- I used clean architecture as it promotes a clear separation of concerns by organizing code into distinct layers.
- This allows to maintain a modular and scalable codebase.
- As the core business logic independent of external frameworks, this ensures flexibility in adopting new technologies and frameworks without affecting the core functionality.
- For example, if we want to switch from using Youtube to Vimeo streaming service, this can be done smoothly and without any effect or other layers or the business logic, this makes extending the application easier.

**Caching** <br />
- I implemented In-Memory caching using decorator pattern.
- Decorator pattern allows us to add extra functionality to an object by wrapping it with one or more objects.
- So chaching is added to the needed services without changing the service.

**Exception Handling** <br />
- I created a custom exception middleware to handle errors.

**Mapping** <br />
- I used AutoMapper to map models.

**Validations** <br />
- I assumed that if there are no movie details coming from the movie details service (OMDB), so I'm not going trigger the call to check the movie videos.
- I assumed that movie videos are not mandatory, so if the movie videos service (YouTube) returned nothing, the application is going to continue normally.
 

**Improvements** <br />
**Precise Search** <br />
- Movie videos search can be better, for as the movie name only sometimes can be generic.
- For example, if the user search for "Mission Impossible", the Movie Details Service (OMDB) will return result for "Mission Impossible 1", while Movie Videos Service (YouTube) will return the top videos which is about the latest mission impossible movie (2023).
- A fix would be to include more meta information besides the movie name at the Movie Videos Service (Youtube), to make the results more accurate.
- For example, to include the releasse year of the movie with the movie name, so when the user search with "Mission Impossible", the Movie Details Service returns the first part, the Movie Videos Service will search with "Mission Impossible 1996"
