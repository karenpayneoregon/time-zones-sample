# About

Code to obtain timezone(s) for the computer running. 

In InternetHelpers.CurrentTimeFromWeb() a variable for HttpClient has a timeout set which is used to ensure there are no long waits for reading a response from a given site and may be removed if this is not an issue. Note, do not set the timeout too low else failure will happen.

## Reason for this library

- Useful if a requirement needs timezones
- A learning exercise.
