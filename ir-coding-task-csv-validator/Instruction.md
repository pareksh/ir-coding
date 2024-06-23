# Pre – Interview Programming Task
## Task Duration:	
We understand your time is valuable, please don’t spend more than 1-2 hours on this task.

## Purpose & Objective:  
A significant portion of the technical interview will be a code review of your submission.

We are looking for a production quality design that is in your opinion, elegant, extensible and maintainable.

We would rather see half the job done well with a good clean code design.

**The task definition is intentionally a bit vague, if you are uncertain about anything, make some sensible assumptions. Submit any assumptions you make with your response.**

## The Task:
A skeleton (non-functional) Web API application based on .Net Core web-api
Implement the 'Validate' endpoint of the 'Validator' controller to return the results of validating user data from a 'data' CSV file
Sample data for validation can be found in the 'sample_data' directory

The following validation rules should be implemented:
* Produce a warning if names are less than four characters
* Produce an error if the code denoting the state is not in the 'states_table'
* Produce a warning if the salary is not a positive integer
* Produce an error if no post code exists
* Produce a warning if the postcode is not valid for the state

**Bonus**
* Add a UI for retrieving validation results


