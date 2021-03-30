# Python:   2.7.13

# Author:   Daniel Wallace

# Purpose:  The Tech Academy Python Drill - Dice rolling game that tells your future! 
# Assignment: Include all required elements, which are comment highlighted throughout.
# There's one way to break the code...you can't enter a non integer value into the input for task 6, your lottery guesses.

from random import randint
import time

#11. Create a tuple...
playerTasks = (
    [1, '\nRoll a 12 sided die then a 20 sided die. Multiply them and find your yearly salary in K\'s per year. Doubles pay varying bonuses!'],
    [2, '\nNext, roll a 20 sided die 2x, multiply the results. Then, roll a 6 sided die and divide. That\'s your hourly earning.'],
    [3, '\nRoll a 6 sided die 2X. Subtract the smaller from larger to see how many time you will be married.'],
    [4, '\nNow, roll a 6 sided die 2X. Sum the results to find out how many children you will have.'],
    [5, '\nRoll a 4 sided die. If it\'s 1 or 3, you have a dog. If it\'s 2 or 4, you have a cat.'],
    [6, '\nEnter a number between 1 and 20 then roll a 20 sided die. If you guess correctly, you\'ll win the lottery! You have 3 tries.'],
    [7, '\nLast, just for fun, press H to see your personal hipster power phrase.']
)

#11. Create a tuple...    
hipWords = ('brooklyn', 'locavore', 'artisan', 'craft beer', 'vegan', 'biodiesal', 'gentrify',
                'etsy', 'post ironic', 'drinking vinegar', 'shabby chic', 'cliche', 'single origin coffee',
                'leggings', 'microdosing', 'vaporware', 'organic', 'kickstarter', 'air-plant', 'tattoo',
                'occupy', 'lyft', 'pinterest', 'green juice', 'cardigan', 'butcher', 'thundercats',
                'gastropub', 'cleanse', 'mustache', 'asymmetrical', 'hoodie', 'unicorn', 'schlitz',
                'pbr', 'turmeric', 'lumber-sexual', 'vhs', 'small-batch', 'bitters', 'taxidermy',  'put a bird on it')


def start():
    playerName = raw_input('\nHi player, what can I call you? ').capitalize()
    #4. Use the print function and .format() notation to print out the variable you assigned
    print('\nWelcome {}. We are going to play a few dice games to predict your future.').format(playerName)
    results = questions(playerName)
    time.sleep(4)
    print('\n')
    print('\n')
    print('\n')
    print('\nSo, {} Let\'s review...').format(playerName)
    
    # 9. Use of a for loop
    #10 (cont) and iterate through that list using a for loop to print each item out on a new line...
    for result in results:
        print result
    print '\nThe Dice have spoken!'


def diceRoll(rollNum, sides=6):
    #1. Assign an integer to a variable
    rollCount = 0
    rollList = []
    #8. Use of a while loop
    while rollCount < rollNum:
        rollDetect = raw_input('\nType R and Enter to roll.').lower()
        if rollDetect == 'r':
            rollResult = randint(1,sides)
            rollList.append(rollResult)
            print ('\nYou rolled a {}.').format(rollResult)  
            # used the += operator
            rollCount += 1
        else:     
            print '\nI\'m sorry, you need to press R to roll. Try Again!'
    return rollList


def questions(playerName):

    #10. Create a list ... 
    playerResults = []

    # 9. Use of a for loop
    #11 (cont) ...and iterate through it using a for loop to print each item out on a new line
    for task in playerTasks:
        print task[1]
        
        #7. Use of conditional statements: if, elif, else
        if task[0] == 1:
            rollResult1 = diceRoll(1, 12)
            rollResult2 = diceRoll(1, 20)
            #use * operator
            #2. Assign a string to a variable
            calcResult = '\nYou will earn a salary of ' + str(rollResult1[0] * rollResult2[0]) + ' K per year.'
            #use % operator
            #use and
            if rollResult1[0] == rollResult2[0] and (rollResult1[0] % 2) != 0:
                calcResult = calcResult + '\nYou also made a bonus of 10K'
            elif rollResult1[0] == rollResult2[0]:
                calcResult = calcResult + '\nYou also made a bonus of 10K'
            print calcResult
            time.sleep(2)
            
        elif task[0] == 2:
            rollResult1 = diceRoll(2, 20)
            print('Now roll the 4 sided die')
            rollResult2 = diceRoll(1, 6)
            #3. Assign a float to a variable
            #use / operator
            calcResult = ('\nYou will be earning {0:.2f} per hour on your salary.').format(float(rollResult1[0]*rollResult1[1]) / float(rollResult2[0]))
            print calcResult
            time.sleep(2)
            
        elif task[0] == 3:
            rollResult = diceRoll(2, 6)
            #use - operator
            calcResult = '\nYou will be married ' + str(max(rollResult) - min(rollResult)) + ' times.'
            print calcResult
            time.sleep(2)
            
        elif task[0] == 4:
            rollResult = diceRoll(2, 6)
            #use + operator
            print ('\nCongratulations, {}').format(playerName)
            calcResult = '\nYou have ' + str(rollResult[0] + rollResult[1]) + ' children!'
            print calcResult
            time.sleep(2)

        elif task[0] == 5:
            rollResult = diceRoll(1, 4)
            # use or
            if rollResult[0] == 1 or rollResult[0] == 3:
                calcResult = '\nYou have a dog named Spot.'
                print calcResult
                time.sleep(2)
            else:
                calcResult = '\nYou have a cat named Fluffy.'
                print calcResult
                time.sleep(2)

        elif task[0] == 6:
            guessesLeft = 3
            while guessesLeft > 0:
                guess = raw_input('\nGuess and press enter.') #Doesn't catch non integer input
                if int(guess) in range(1,21):
                    rollResult = diceRoll(1, 20)
                    if rollResult[0] == int(guess):
                        calcResult = '\nYou\'ll win the lottery!!!'
                        print calcResult
                        time.sleep(2)
                        break
                    else:
                        print('No lottery for you.')
                        time.sleep(2)
                        calcResult = ('\nYou won\'t win the lottery. Sorry {}, you\'ll have to work like the rest of us.').format(playerName)
                        #use -= operator
                        guessesLeft -= 1
                else:
                    print ('\nI\'m sorry {}, you need to choose a number between 1 and 20.').format(playerName)

        else:
            calcResult = hipsterList()
            
        playerResults.append(calcResult)
    return playerResults


def hipsterList():
    inputDetect = raw_input('\nPress H and Enter.').lower()
    if inputDetect == 'h':  
    #13. Call the function you defined in 12 and print the result to the shelle
        calcResult = getHipPhrase()
        print calcResult
        return calcResult
    else:
        print ('\nI\'m sorry {}, you need to press H to roll. Try again').format()
        hipsterList()


#12. Define a function that returns a string variable 
def getHipPhrase():
    counter = 0
    hipPhrase = []
    while counter < 7:
        hipWord = (hipWords[randint(0,len(hipWords)-1)])
        # use not
        if hipWord not in hipPhrase:
            hipPhrase.append(hipWord)
            counter += 1
    calcResult = '\n' + hipPhrase[0] + '   ' +  hipPhrase[1] + '   ' +  hipPhrase[2] + '   ' +  hipPhrase[3] + '   ' +  hipPhrase[4] + '   ' +  hipPhrase[5] + '   ' +  hipPhrase[6]     
    return calcResult


if __name__ == '__main__':
    start()









 
