# Code was written by: Sasha Andersen

def addition ():
    num = float (input("\nEnter your number: "))
    total = 0
    answer = 0 #what is this for?
    while num != 0:
        answer = answer + num
        total += 1
        num = float (input ("Enter another number (0 to calculate): "))
        return [answer, total]

def subtraction ():
    print("to be completed")

while True:
    list = []
    print ("Calculator\n")
    print (" Enter 'a' for addition")
    print (" Enter 's' for substraction")
    print (" Enter 'm' for multiplication")
    print (" Enter 'v' for average")
    print (" Enter 'q' for quit")
    c = input("\nPlease enter your choice: ")
    if c != 'q':
        if c == 'a':
            list = addition()
            print("Ans = ", list[0], " total inputs ",list[1])
        elif c == 's':
            list = subtraction()
            print("Ans = ", list[0], " total inputs ",list[1])
        elif c == 'm':
            #list = multiplication()
            #print("Ans = ", list[0], " total inputs ",list[1])
            print ("to be completed")
        elif c == 'v':
            #list = average()
            #print("Ans = ", list[0], " total inputs ",list[1])
            print ("to be completed")
        else:
            print ("Sorry, invalid character")
    else:
        break
