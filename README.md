# ListMutationRemover
## Remove list mutations

Before:
![image](https://user-images.githubusercontent.com/40608267/91338149-7c0a7600-e7a2-11ea-9045-18fe013e69e8.png)
![image](https://user-images.githubusercontent.com/40608267/91338114-6c8b2d00-e7a2-11ea-8902-adaeb556d41a.png)

After (conversions get applied, so the numbers might not look the same, but in reality they really are).:
![image](https://user-images.githubusercontent.com/40608267/91338211-993f4480-e7a2-11ea-91ad-6e1c6ef680f3.png)


Yes, i am aware of the DnSpy-generated folder. I was pretty lazy and wasn't up to making a new project so I just used CodeCracker's constant decrypter to write my new code. You might even notice some methods that aren't even used in the source LOL


# How it works
- First, it gets every (List.ADD) from the internal <MODULE> and adds it to an arraylist.
- Then for every time an access variable is called for the List, we get ONLY the *index number* (not value).
- After that, we find the number inside our arraylist using our index
- Finally, we replace everything with nops except 1 OpCode, where we just leave the returned number

