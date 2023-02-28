 # -*- coding: cp1251 -*-
#text = "Message:\n\"Hello World\""

#print(text)
#print(text[0])
#print(text[6])
#print(text[21])
#print(len(text))

#for i in text:
#    print(i)

#i=0
#while i < len(text):
#    print(text[i])
#    i+=1

#my_substring = text[:7] 
#print(my_substring)

#my_substring2 = text[10:15] 
#print(my_substring2)
 
#my_substring3 = text[16:21] 
#print(my_substring3)

#my_substring4 = text[16:21:2] 
#print(my_substring4)


#name = "Tom"
#age = 33
#info = name + str(age)
#print(info)



#name = "25"
#age = 33
#info = name + str(age)
#print(info)
#info = int(name) + age
#print(info)

#print(name*5)

#val1 = ('Написать функцию arithmetic, принимающую 3 аргумента:'
#'первые 2 - числа, третий - операция, которая должна быть произведена над ними. ')
#print(val1)
#substring = val1[:9]
#print(substring)
#substring2 = val1[9:17]
#print(substring2)

#str_a = "aa"
#str_b = "aa"
#if str_a == str_b:
#    print("equal")
#else:
#    print("not equal")

#str_a = "AA"
#str_b = "aa"
#if str_a.lower() == str_b.lower():
#    print("equal")
#else:
#    print("not equal")

#str_a = "AAbB"
#str_b = "aaBB"
#if str_a.upper() == str_b.upper():
#    print("equal")
#else:
#    print("not equal")

#text = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM"

#for i in text:
#    print(f'{i}:  {ord(i)}')

#print(len(text))

#print(ord(text))

text = ('написать функцию arithmetic, принимающую 3 аргумента:'
'первые 2 - числа, третий - операция, которая должна быть произведена над ними. ')

text2 = 'написать'
text3 = 'функцию'
#substring = 'Операция'

#if substring.upper() in text.upper():
#    print("present")
#else:
#    print("not present")

#result = substring.upper() in text.upper()
#print(result)

#result = text2.isalpha()
#result = text.islower()
#result  = text.startswith('Написать')
#print(result)
result2 = text.find(text2)
print(result2)
result3 = text.replace(text2,text3)
print(result3)

result4 = text.split(' ')

print(result4)



