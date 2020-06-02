# Outlook calendar on Blazor:


## Project Objectives:

1 - Practice front end web development. \
2 - Practice [FluentUI](https://developer.microsoft.com/en-us/fluentui). \
3 - Practice one SPA framework; \
4 - Introduce few extra features as the time goes by; \
5 - Add deployment variations (Blazor and Blazor WASM) \
6 - Try bringing to mobile using Xamarin?

## App running images

![Authorized Users](images/blazorCalendar.png?raw=true)
![Authorized Users - Small](images/blazorCalendarSmall.png?raw=true)

## Todo stuff
- [x] :art: Create initial design using FluentUI
- [x] :heart: Create blazor application UI
- [x] :lock: Create MS authentication logic
- [ ] :lock: Fix authentication redirection
- [x] :sparkling_heart: Improve how stacked events look up in the calendar td
- [x] Improve alignment of the calendar table and td
- [ ] Break all ui logic in separated components
- [ ] :ok_hand: Move all C# logic to separated source codes
- [ ] Unit tests and refactor all logic of AddEvent comp
- [ ] Unit tests and refactor all logic of Event list comp
- [ ] Unit tests and refactor all logic of Calendar comp
- [ ] :rocket: Host the blazor wasm as a static site on github
- [x] AddEvent component is floating over the calendar
- [ ] Add more animations to the calendar components
- [ ] Events won't be saved if the user don't select a day
- [x] Add how many events are available when resizing the screen for mobo aps
- [ ] Make the amount of text vary when showing the events as labels
- [ ] Add notification when an event is added
- [ ] Add notification when an event is starting
- [ ] Fix the login and logout redirects
- [ ] Add some sort of webhook when events are added on Windows

## Credits

The project was created following [this](https://www.youtube.com/playlist?list=PLFJQnCcZXWjv89uDubYW7NniK8mEl4sWQ) youtube tutorial series. His full source code (differs from my repo) is available [here](https://github.com/aksoftware98/BlazorOutlookCalendar).

