# Code was written by: Sasha Andersen

# Password manager assessment for the Software Engineering course at Vic Uni Polytechnic
# Assessment did not require user login credentials or changing stored login credentials


# Function for users to input login credentials, join fields, write into file
# "a" append method has been used so it doesn't overwrite existing content
def addCredentials ():
    print("\nPlease enter your login credentials below")
    URL_R = input("URL/Resource: ")
    uName = input ("Username: ")
    PW = input ("Password: ")
    jointText = (f"\n{URL_R}\n{uName}\n{PW}")
    myFile = open("DigiCore_PWDManager.txt", "a")
    myFile.write(jointText)
    myFile.close()
    print("\nLogin credentials saved.\n")


# Function to retrieve a file, split it into a list then display it
# When written into the file it was formatted to have a \n before each field joined together (to break up each entry). Index is at 1 instead of zero so it skips over the first item which is a blank space.
def viewCredentials ():
    try:
        myFile = open("DigiCore_PWDManager.txt", "r")
        data = myFile.read() 
        myFile.close()
        dataList = data.split("\n")
        print ("\nYour stored login credentials...")
        listIndex = 1
        while listIndex < len(dataList):
            print("\nURL/Resource:", dataList[listIndex], "\nUsername:", dataList[listIndex+1], "\nPassword:", dataList[listIndex+2])
            listIndex += 3
        else:
            print("\nEnd.\n\n")
    except FileNotFoundError:
        print("\nFile doesn't exist yet, please enter 1 to add login credentials first.\n")


print("\nYour DigiCore Password Manager\n")

# Menu for users to input an option and call functions
menu = ''
while True:
    print("Main menu")
    print("[1] Enter 1 to add login credentials")
    print("[2] Enter 2 to view stored login credentials")
    print("[3] Enter 3 to exit the program")
    menu = input("\nPlease enter the number of your choice: ")
    if menu == '1':
            addCredentials()
    elif menu == '2':
            viewCredentials()
    elif menu == '3':
            break
    else:
        print("\nInvalid option, please try again.\n")
print("\nProgram exit.")