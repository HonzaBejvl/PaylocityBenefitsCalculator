# Introduction

Welcome to my programming assignment submission. This project represents a focused effort over approximately 5 hours, primarily during the late hours of February 11th to 12th. It's important to note that this codebase was developed under time constraints and is intended as a starting point for discussion rather than a final, production-ready solution.

Throughout the development process, I have aimed to tackle the core requirements of the assignment, implementing key functionalities and addressing the problem statement to the best of my ability within the allocated time. While the result may not reflect what I would consider ready for a production environment or a pull request (PR) in a professional setting, it showcases my approach to problem-solving and coding under a tight deadline.

# What are we looking for?

## understanding of business requirements ✅

I would definitelly have questions during refinement meeting. There are edge cases with birth days, when to divide the salary etc..

## correct implementation of requirements ✅

## test coverage for the cost calculations ✅ 

here I would need more time to write more tests

## code/architecture quality

Codestyle is poor, I'm missing a lot of xml docs, almost everything is in Api project

## plan for future flexibility ✅

The cost rule pattern should be flexible enought.

## address "task" code comments ✅

Integration tests are green.
I made decission the data into db. It may seem like overkill, but I already had my Azure subscription so it was a matter of a few clicks + setting up the Model project also took just few minutes (I also totally ignored security, the db is public for 0.0.0.0-255.255.255.255, sql password is stored in appsettings etc.). I felt this was easier then just somehow mocking Employee and Dependent repositories.

## easy to run your code (if non-standard, provide directions) ✅

# What should you not waste time on?

## authentication/authorization ✅

## input sanitization ✅

## logging ✅

## adding multiple projects to represent layers... putting everything in the API project is fine ✅

# TODO

Xml docs, more tests, better tests (I don't like the IntegrationTests implementation), enviroment configs, logging, implement rounding, bettter swagger annotations, cleanup project structure, refactor out contracts, do not include password in db cs.
