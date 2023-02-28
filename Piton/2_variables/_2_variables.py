# -*- coding: cp1251 -*-
'''
firstName = "Alex"
print("firstName = ", firstName)
print(f"firstName = {firstName}")

second_name = 'Dmitry'
surname = "Abramov"
print(f"{surname} {firstName} {second_name}" )
print(surname, firstName, second_name )

A = 3
print("a = ",A)
A = 6
print("a = ",A)

isValid = True
print(isValid)

isValid = True
print(isValid)

if(isValid):
    print("1")
else:
    print("2")

age = 1
print("Age:", age)    # Возраст: 21
 
count = 15
print("Count:", count) # Количество: 15


# двоичная
a = 0b11
b = 0b1011   # 2 в 0  + 2 в 1 + 2 в 3 = 1 + 2 + 8 
c = 0b100001
print(a)    # 3 в десятичной системе
print(b)    # 11 в десятичной системе
print(c)    # 33 в десятичной системе

# восьмиричная
d = 0o70    #  8 в 1 умножить на 7
e = 0o11    #  8 в 0  + 8 в 1
f = 0o17
print(d)    # 7 в десятичной системе
print(e)    # 9 в десятичной системе
print(f)    # 15 в десятичной системе

# шестнадцати    1-9, A,B,C,D,E,F
g = 0x0A     # 16  в 0 умножить 10
h = 0xFF    # 16 в 0 умн 15 + 16 в 1 умн 15
i = 0xA1
print(g)    # 10 в десятичной системе
print(h)    # 255 в десятичной системе
print(i)    # 161 в десятичной системе


height = 1.68
pi = 3.14
weight = 68.
print(height) # 1.68
print(pi)   # 3.14
print(weight)   # 68.0


x = 3.9e3
print(x) # 3900.0

x = 3.9e-3
print(x) # 0.0039

temp1 = 7.0
temp2 = 3.0
print(temp1/temp2)
'''
#строки

#message = "Hello World!"
#print(message)  # Hello World!
 

#name = 'Tom'
#print(name)  # Tom

#text = ("Laudate omnes gentes laudate "
#        "Magnificat in secula ")
#print(text)

##многострочная переменная
#'''
#Comments
#'''
#text = '''Laudate omnes gentes laudate
#Magnificat in secula
#Et anima mea laudate
#Magnificat in secula 
#'''
#print(text)

##управляющие последовательности

##    \  позволяет добавить внутрь строки слеш

##    \'  позволяет добавить внутрь строки одинарную кавычку

##    \"  позволяет добавить внутрь строки двойную кавычку

##    \n  осуществляет переход на новую строку

##    \t  добавляет табуляцию (4 отступа)

#text = "Message:\n\"Hello World\""
#print(text)

#path = "C:\python\name.txt"
#print(path)

#path = r"C:\python\name.txt"
#print(path)

##вставка значений в строку
#userName = "Tom"
#userAge = 37
#user = f"name: {userName}  age: {userAge}"
#print(user)   # name: Tom  age: 37
#'''
##динамическая типизация
#userId = "abc"  # тип str
#print(userId)
 
#userId = 234  # тип int
#print(userId)

#userId = "abc"      # тип str
#print(type(userId)) # <class 'str'>
 
#userId = 234        # тип int
#print(type(userId)) # <class 'int'>
#'''

from SDLL import *
print(get_celsium(99.5))