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
print("Age:", age)    # �������: 21
 
count = 15
print("Count:", count) # ����������: 15


# ��������
a = 0b11
b = 0b1011   # 2 � 0  + 2 � 1 + 2 � 3 = 1 + 2 + 8 
c = 0b100001
print(a)    # 3 � ���������� �������
print(b)    # 11 � ���������� �������
print(c)    # 33 � ���������� �������

# ������������
d = 0o70    #  8 � 1 �������� �� 7
e = 0o11    #  8 � 0  + 8 � 1
f = 0o17
print(d)    # 7 � ���������� �������
print(e)    # 9 � ���������� �������
print(f)    # 15 � ���������� �������

# �����������    1-9, A,B,C,D,E,F
g = 0x0A     # 16  � 0 �������� 10
h = 0xFF    # 16 � 0 ��� 15 + 16 � 1 ��� 15
i = 0xA1
print(g)    # 10 � ���������� �������
print(h)    # 255 � ���������� �������
print(i)    # 161 � ���������� �������


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
#������

#message = "Hello World!"
#print(message)  # Hello World!
 

#name = 'Tom'
#print(name)  # Tom

#text = ("Laudate omnes gentes laudate "
#        "Magnificat in secula ")
#print(text)

##������������� ����������
#'''
#Comments
#'''
#text = '''Laudate omnes gentes laudate
#Magnificat in secula
#Et anima mea laudate
#Magnificat in secula 
#'''
#print(text)

##����������� ������������������

##    \  ��������� �������� ������ ������ ����

##    \'  ��������� �������� ������ ������ ��������� �������

##    \"  ��������� �������� ������ ������ ������� �������

##    \n  ������������ ������� �� ����� ������

##    \t  ��������� ��������� (4 �������)

#text = "Message:\n\"Hello World\""
#print(text)

#path = "C:\python\name.txt"
#print(path)

#path = r"C:\python\name.txt"
#print(path)

##������� �������� � ������
#userName = "Tom"
#userAge = 37
#user = f"name: {userName}  age: {userAge}"
#print(user)   # name: Tom  age: 37
#'''
##������������ ���������
#userId = "abc"  # ��� str
#print(userId)
 
#userId = 234  # ��� int
#print(userId)

#userId = "abc"      # ��� str
#print(type(userId)) # <class 'str'>
 
#userId = 234        # ��� int
#print(type(userId)) # <class 'int'>
#'''

from SDLL import *
print(get_celsium(99.5))