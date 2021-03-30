# Python Ver:   3.6.0
#
# Author:       Daniel Wallace
#
# Purpose:      Tech Academy Python Drill - Item 62 - datetime

from datetime import datetime, timedelta
from time import strftime

def start():
    portland_time = datetime.time(datetime.now())

    ny_time = datetime.now() + timedelta(hours=3)
    london_time = datetime.now() + timedelta(hours=8)
    
    print('\nLocal Portland time is ' + portland_time.strftime('%H:%M') + '.')

    print('\nThe time in New York is ' + ny_time.strftime('%H:%M') + '.')
    if int((ny_time.strftime('%H'))) > 8 and int((ny_time.strftime('%H'))) < 22:
        print('The New York office is OPEN.')    
    else:
        print('The New york office is CLOSED.')
        
    print('\nThe time in London is ' + london_time.strftime('%H:%M') + '.')
    if int((london_time.strftime('%H'))) > 8 and int((london_time.strftime('%H'))) < 22:
        print('The London office is OPEN.')    
    else:
        print('The London office is CLOSED.')

        

if __name__ == '__main__':
    start()

