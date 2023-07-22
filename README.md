# Task Board
"Task Board" is a simple information system for managing tasks in a task board. Each task consists of title + description.

## The "Task Board" Web app supports the following operations:
· Home page (view tasks count + menu)
· View the boards with tasks
· Search tasks by keyword
· Add new task (title + description)
· Edit task / move to board

## TaskBoard Web App: Automated Selenium UI Tests
· Navigate to “Task Board” and assert that the first task from board "Done" has title "Project skeleton".
· Search tasks by keyword "home" and assert that the first result has title "Home page".
· Search tasks by keyword "missing{randnum}" and assert that no such task is found.
· Try to create a new task, without title, and assert an error is returned.
· Create a new task, holding valid data (name and description), and assert that the new task is added and listed last in the task board.

## TaskBoard Desktop App: Automated Appium UI Tests
· Open the app.
· Connect to your backend API service. The default URL address is https://taskboard.nakov.repl.co/api, you have to change it to yours, that is part of the task /for example: http://{yoursite}/api
· Search for the word "open".
· Assert that the returned result holds board "Open".
