# Rob6
2D game develop using unity

# Basic guide good practice

## Code formatting

### Name formatting

* The name of the variable and the method we are using the Camel case format which consist to begin every word with an uppercase except for the first word.
 Example: <code>variableAndMethodName</code>

* The name of the files are similar to the variable and method name but the first word will also begin with an uppercase.
Example: <code>FileName</code>

* The name of folder will be in lower case and short but meaningful.
Example: <code>foldername</code>

* The constant variable will be written in uppercase and word will be separated by an underscore.
Example: <code>CONSTANT_NAME</code>



### Code indentation

* The indentation will be the same as Epitech indentation except the space we will be using 4 instead of 8.

### Code documentation

For the code documentation, we will be using the [JavaDoc](https://en.wikipedia.org/wiki/Javadoc) read this to understand how document your method and class.
For version format we will be using the date format YY.MM.DD in the @version and @since.

### Git and github

You will never have to work/push on the master branch and develop branch, you will need to create a new one for the task you have to do.
Every branch must be link to an issue.
* If it's a bug the branch name will be fix/ROB6#numberoftheissue-description for Example <code>fix/ROB6#1-physics</code>
* If it's a feature the branch name will be feature/ROB6#numberoftheissue-description for Example <code>feature/ROB6#10-database-update</code>

### Pull request

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

### How to report a bug

To report a bug you need to create an issue and assign it with the tag bug.
In order to do a good bug report you need to fill the following form:
``` 
What steps will reproduce the problem?
 
What is the expected result?
 
What happens instead?
 
Please provide any additional information below.
Attach a screenshot if possible
```

 ## How to use Unity3D for Rob.6

- Basics :

    1. : Build a map with platform prefabs and place your Rob
    2. Second : You must delete the default main camera and add the prefabs named  **main camera**. In the inspector search the script **camera change** and in **current** drag and drop the first Rob on your scene (the start rob)

    3. Third : Add the **playerManager** prefabs too your scene. Then find in the inspector the **cursor** script and drag and drop the **main camera** in the **cam** tab. Do the same with your start rob on the **spawn** tab.
Click on **players** and note in the **size** tab the number of rob in your scene and then fill the array by dragging and dropping all your robs in the array’s tabs ;  

   4. Fourth : add the **gameControl** prefab to your scene

- Pause menu :
Add the **pause menu** prefab to your scene  and ine the <Menu> tab drag and dope **pauseMenu** child.

- Lights :
To add lights on your scene you must first go to the <window> tab and select the **lighting** and **settings**. Choose black as the **Ambient color**

Now drag and drop some lights prefabs. If you want an inside light choose the **inside** layer on the Culling mask and if you want an outside light choose the **outside** layer on the culling mask
(if you want an object to be inside or outside just select the matching layer on your gameObject)

- Different Robs :
    - Every robs :
Drab and drop th <nb scrap> text from the <pause menu> too the **nb scrap** tab on the **player controller** scripts
In the **rob.h** tab on the same script, enter the number on **rob.h** in your scene and fill the array with all **your rob.h**

