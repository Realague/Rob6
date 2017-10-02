# Rob6
2D game develop using unity

## Basic guide good practice

### Code formatting

#### Name formatting

* The name of the variable and the method we are using the Camel case format which consist to begin every word with an uppercase except for the first word.
 Example: <code>goodVariableAndMethodName</code>

* The name of the files are similar to the variable and method name but the first word will also begin with an uppercase.
Example: <code>GoodFileName</code>

* The constant variable will be written in uppercase and word will be separated by an underscore.
Example: <code>GOOD_CONSTANT_NAME</code>

* The name of folder will be in lowercase and short but meaningful.
Example: <code>foldername</code>

#### Code indentation

* The indentation will be the same as Epitech indentation.

#### Code documentation

For the code documentation, we will be using the [JavaDoc](https://en.wikipedia.org/wiki/Javadoc) read this to understand how document your method and class.
For version format we will be using the date format DD.MM.YYYY in the @version and @since.

### Git and github

You will never have to work/push on the master branch and develop branch, you will need to create a new one for the task you have to do.
Every branch must be link to an issue.
* If it's a bug the branch name will be fix/ROB6#numberoftheissue for Example <code>fix/ROB6#1</code>
* If it's a feature the branch name will be feature/ROB6#numberoftheissue for Example <code>feature/ROB6#10</code>

#### Pull request

Once your task is finished you need to create a pull request.

In order to do this you need to give a title short but meaningful.

If it's a bug describe what you have done to fix it.
Then in the description list the change you have done and at the end give the name of the issue.

Example of pull request:

```
Improved menu
 
* Removed the old menu system (using the mouse in the menu)
* Changed the button language localization
* Added the new menu system (work with the keys instead of the mouse)
Issue: ROB6#1
```

#### How to report a bug

To report a bug you need to create an issue and assign it with the tag bug.
In order to do a good bug report you need to fill the following form:
``` 
What steps will reproduce the problem?
 
What is the expected result?
 
What happens instead?
 
Please provide any additional information below.
Attach a screenshot if possible
```
