# -*- coding: cp1251 -*-
import math
#def Summa(a, b):
#    return a+b

#def Print_Hello():
#    print("Hello")
#    print("Pyton")
#    print("I like")

#def Print_Message(message):
#    print(message)

 
#c = Summa(2,2)

#print(c)
#Print_Hello()
#Print_Hello()
#Print_Hello()
#Print_Message("Саша молодец")
#Print_Message("Сема тоже")
#def Ruts(a, b):
#    return(math.sqrt(a*b))


#a=int(input("Введите число: "))
#b=int(input("Введите число: "))

##c = Ruts(a, b)
##print(c)

##count=int(input('Введите число от 1 до 1000: '))
##if count==1:
##    print ('false')
##else:
##    val1 = 2
##    while val1 < count :
##        if(count%val1==0):
##            print('false')
##            break
##        val1+=1
##    else:
##        print('true')

#def alex_operation(a,b,c):
#    if( c=='+'):
#        return(a+b)
#    elif(c=='-'):
#        return(a-b)
#    elif(c=='*'):
#        return(a*b)
#    elif(c=='/'):
#        return(a/b)
#    else:
#        print( "Неизвестная операция")
 
    
#a=float(input('введите число а: '))
#b=float(input('введите число b: '))
#c=input('введите знак c: ')
#result = alex_operation(a,b,c)
#(result!=None):
#    print(result)


def Is_Year_Leap(a):
    if a%4==0:
        return("True")
    else:
        return("False")

def main():
    a = int(input("Введите год: "))
    result = Is_Year_Leap(a)
    print(result)

#main()


#def Is_Year_Leap(a):
#    if a%4==0:
#        print("True")
#    else:
#        print("False")

#def main():
#    a=int(input("Введите год: "))
#    Is_Year_Leap(a)
   
main()

