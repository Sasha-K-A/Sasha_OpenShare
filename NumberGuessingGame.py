import random

# Code was written by: Sasha Andersen

print("\nGuess the number game!\n")

def game ():
    print("\nGuess what number I am thinking of?")
    print("Between 0 and 5 inclusive\n")
    number = 6
    while number < 0 or number > 5:
        try:
            number = int(input ("Enter your guess: "))
        except:
            print ("Invalid option, your guess must be a whole number\n")
        if number < 0 or number > 5:
            print ("\nI suggest you guess between 0 and 5 inclusive...")
    randomNumber = random.randint(0,5)
    if number == randomNumber:
        print ("\nWINNER")
        print ("Your guess,", number, ",was correct!\n\n")
    elif number != randomNumber:
        print ("\nBetter luck next time!")
        print ("Your guess ", number, " was incorrect")
        print ("The correct answer for this game was", randomNumber, "\n\n")

menu = ''
while True:
    print("[1] Enter 1 to play a new game")
    print("[2] Enter 2 to exit the game")
    menu = input("\nPlease enter the number of your choice: ")
    if menu == '1':
            game ()
    elif menu == '2':
            break
    else:
        print("\nInvalid option, please try again.\n")
print("\nGame closed.")