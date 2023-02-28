# -*- coding: cp1251 -*-

#year = int(input('введите год:'))

#if(year%4 == 0):
#    print('true')
#else:
#    print('false')

#print(round(1.23456))
#print(round(1.23456, 3))

#import math
#a= math.sqrt(2*3.1**2)
#b = round(a,2)
#print(b)




import math
a = float(input("Введите число: "))
print(f'площадь:{a**2}\tпериметр:{a*4}\tдиагональ:{round(math.sqrt(2*a**2),2)}')

count=0
while count <= 100:
    print(f"{count}\t\t{count:0b}\t\t{count:0o}\t\t{count:0x} ")
    count+=1

#month = input('введите номер месяца: ')


#month=1
#while month<=13:
#    if(month<3):
#        print(month,'зима')
#    elif (2 < month < 6 ):
#        print(month,'весна')
#    elif (5 < month < 9):
#        print(month,'лето')
#    elif (8 < month < 12):
#        print(month,'осень')
#    elif (month==12):
#        print(month,'зима')
#    else:
#        print('такого месяца нет') 
#    month+=1


#month=1
#while month<=13:
#    if month in range(1,3):
#        print(month,'зима')
#    elif month in range(3,6):
#        print(month,'весна')
#    elif month in range(6,9):
#        print(month,'лето')
#    elif month in range(9,12):
#        print(month,'осень')
#    elif month ==12:
#        print(month,'зима')
#    else:
#        print('такого месяца нет') 
#    month+=1

#def isLeapYear(year):
#    if year==1:
#        print ('false')
#    else:
#        temp = 2
#        while temp < year :
#            if(year%temp==0):
#                return('false')
#                break
#            temp+=1
#        else:
#            return('true')

#a = int(input('Введите год: '))

#print(isLeapYear(a))

#year=int(input('Введите число от 1 до 1000: '))
#if year==1:
#    print ('false')
#else:
#    val1 = 2
#    while val1 < year :
#        if(year%val1==0):
#            print('false')
#            break
#        val1+=1
#    else:
#        print('true')




















