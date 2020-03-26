Compilation Instructions:
-Download unity version 2019.3.6f1 or higher
-Click on Clone or Download
-In powershell(for windows): git clone <clone link>
-Go to your downloaded GraduationCup folder
-Open powershell there and 
-git checkout -b branch_name (never work from master branch)
-Open unity and open GraduationCup folder
-Go to Assets-> Show in explorer->Assets-> Assets-Main Menu->Scenes->Menu.unity
-Hit play on unity


Github helpful instructions:
# GraduationCup
For first-time user:

•	git clone link 

Before you start working: 

//to update your local repo

•	git fetch 		//check for updates in github

git pull			//get the updates in github 

//create a new branch for each feature/task

•	git checkout -b branch-name

After completing your work:
•	git add .             (1)

git commit -m “message”           (2)

Push your changes to the github

•	git push -u origin branch-name 		//first time

or 

git push					//from second time          (3)

To merge the branch into the master (4) All steps below serially

•	git checkout master         

•	git fetch

•	git pull

•	git merge branch-name

•	git push
