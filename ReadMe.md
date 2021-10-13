# HOW TO RUN SOLUTION

- Open the solution using Visual Studio.
- To start solution without debugging, **press Ctrl + F5**. The solution should start running and a "Tea Round Picker" web browser will pop up.
- Follow the instruction on the web page to populate the list of tea drinkers/participants.
- Once you've entered the desired amount of tea drinkers, click the "Get Tea Maker" button.
- A tea maker will be selected.

# MODIFYING THE LIST OF PARTICIPANTS
## Deleting Participants
- To delete a participant, click the "Delete" button next to your desired participant.
- The selected participant will be deleted from the list.

## Editing Participant Information
- To edit a participant information, click the "Edit" button next to your desired participant.
- The Edit Form will be displayed.
- Make the desired changes to the selected particpant. Then click the "Save" button.
- The selected participant's information will be updated with the new information.

## Editing Option
- Change the participant's name (TextBox).
- Change the participant's drink preference (TextBox).
- Confirm if the participant takes part in a round of tea (CheckBox labelled "Wants A Drink?").

# WHAT I'D DO DIFFERENTLY, IF I HAD MORE TIME
## REDO MY DBCONTEXT
- Replace the current database context "ParticipantContext" with my own definition of a database context IDbContext.
- Using Inheritance, I will create a new database context (i.e. MyDbContext : IDbContext).
- With this implementation, I will be able to Mock the database context and perform a better unit test.

## IMPROVE FAIRNESS
- I will look at improving the fairness of the tea round picker, so over a given time every participant makes an equal amount of drinks.

## IMPROVE UI and USER EXPERIENCE
- Add more features to web page.

# Thanks for visiting my page.

If you have any questions, please feel free to contact me via email: michaelobikwee@yahoo.co.uk.
