# Removing All Local Git Repositories

1. Open Windows Powershell.
2. Change directory to your C; drive (or whatever drive you want to search) by executing the below command.
```
cd C:\
```
3. Run the below command to list all the Git repositories within your user directory. The list will be output to the file GitRepos.txt. **Be sure to update the output file path to match a folder that's on your computer.**
```
Get-ChildItem . -Attributes Directory+Hidden -ErrorAction SilentlyContinue -Filter ".git" -Recurse | Out-file -FilePath C:\Users\lwells\GitRepos.txt
```
4. The file will contain a list of directories that have a ".git" file, which indicates a local repository exists.

      ![image](https://user-images.githubusercontent.com/9041008/158186104-81d986b6-218a-495f-89e8-eb95ee3db3a6.png)

5. Open Git Bash (**NOT Powershell**).
6. Navigate to each of the directories listed in the file and run the command to remove the file.
```
cd /c/Users/lwells/source/repos/Logan/CodeLouisvilleDemo/
rm -rf .git
```
> *When you navigate to the directory, the branch (usually either master or main) should show up in blue next to the current path.
> After deleting, the branch name will no longer be there.*

![image](https://user-images.githubusercontent.com/9041008/158187422-f74428b4-3a43-4549-b3a4-011b94ca576c.png)

7. Optionally, delete all the files in the folder and the folder itself using the normal Windows way to delete.
8. Repeat steps 6 and 7 for each of the repositories in GitRepos.txt that you want to delete.
