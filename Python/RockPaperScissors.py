# This code was completed by Sasha Andersen on 19/10/2022
import random
print("Rock, Paper, Scissors Game")

# Function for playing the game
def game ():
    print("[1] Rock")
    print("[2] Paper")
    print("[3] Scissors")
    userInput = int(input("Choose your weapon of choice and enter that number: "))
    computerInput = 1
    #random.randint(1,3)
    print(f"The computer choose {computerInput} as it's weapon")
    
    win = ("\nYou win! You defeated the computer. But can you win again?")
    loose = ("\nOh no! You were defeated by the computer. I'm sure you can beat it next time!")
    draw = ("\nIt was too close to call, a draw! Better try again.")

    if userInput == 1:
        if computerInput == 3:
            print (win)
        elif computerInput == 2:
            print (loose)
        else:
            print (draw)

    if userInput == 2:
        if computerInput == 1:
            print (win)
        elif computerInput == 3:
            print (loose)
        else:
            print (draw)
    
    if userInput == 3:
        if computerInput == 2:
            print (win)
        elif computerInput == 1:
            print (loose)
        else:
            print (draw)

# Function for viewing the rules
def rules ():
    print ("You have three weapons of choice...")
    print ("Rock, paper or scissors\n")
    print ("Rock beats scissors")
    print ("Scissors beats paper")
    print ("Paper beats rock\n")
    print ("Choose wisely")

# Menu for users to input an option and call functions
menu = ''
while True:
    print("\nMain menu")
    print("[1] Start a new game")
    print("[2] View the rules")
    print("[3] End game")
    menu = input("\nPlease enter the number of your choice: ")
    if menu == '1':
            game()
    elif menu == '2':
            rules()
    elif menu == '3':
            break
    else:
        print("\nInvalid option, please try again.\n")
print("\nProgram exit.")




