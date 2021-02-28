# Effectory Questionnaire Api

This is the backend project that I developed for Effectory. You will find a short explanation in this document about what I tried to do to accomplish this assignment.

## How I Managed Time

For this assignment, I've been given 4 hours. I tried to manage time efficient as much as I could to do the following;

* first 30 min, I tried to understand what the expectations and the requirements are
* 1 hour, I spent this time to model `Domain` based on given JSON file and the requirements _(I was lucky because I worked on a similar project in the past so I could manage this part quickly)_
* 2,5 hours, during this time frame, I created `Tests`, `Api` and `Infrastructure` layer

## My Approach

### Domain
First, I modelled `Domain` because it's heart of the application. After I analyzed the JSON file with the requirements, I modelled the structure as `OOP` way.

### API
With this layer, we tell the world that we have a couple of functionalities in terms of questionnaire. The API does the following;

* Lists questions by subject
* Saves user responses
* Lists results of the calculation

### Infrastructure
This is the persistence layer. I used `EF Core` with `InMemoryDb` and it has repository implementation and other helper classes.

### Test
In this assignment, I followed `TDD` approach and wrote some unit and integration tests to cover possible scenarios.

# Conclusion

First of all, I want to thank you for giving me this chance and I'm happy to be a part of your interview process. I also want to mention some things about my code;

* My code is not production-ready and it should be optimized
* The architecture is not proper, but at least I have separated layers
* In terms of result calculation, I think it should be more discussed, because I couldn't clarify formulas
  For instance calculation of `Average` is missing in my solution or what should be the formula for `Max` and `Min`

### Notes
Please keep in mind that, I just had 4 hours to complete this assignment and I tried to do my best but during this timeframe, some features might not be implementing properly or might not work as expected, but in the end, I think my solution is a good point to enter a discussion. For the real-life scenario, I have ideas how this code should be like and what we could do.

I hope you will like my solution.

Thank you
