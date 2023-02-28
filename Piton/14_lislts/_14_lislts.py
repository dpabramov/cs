# -*- coding: cp1251 -*-
#for i in range(1, 11):
#    print(i, end = ', ')
#print('\n')

##список
#numbers = [1, 2, 3, 4, 5]
#for number in numbers:
#    print(number, end = ', ')  
#print('\n')
    
#people = ["Tom", "Sam", "Bob"]
#for person in people:
#    print(person, end = ', ')

#print('\n')

#numbers2 = list()
#numbers2.append(1)
#numbers2.append(2)

#print(numbers2)
#print(people)

#numbers1 = [1, 2, 3, 4, 5]
#numbers3 = list(numbers1)
#numbers4 = list([1, 2, 3, 4, 5, 6, 7])
#print(numbers3)
#print(numbers4)
#print(list())

#message = 'q'*10
#print(message)

#numbers5 = [1]*10
#print(numbers5)

#persons = ['Sasha', 'Pasha', 'Tima', 'Sema']
#print(persons)

#print(persons[0])
#print(persons[1])
#persons[2] = 'Timofey'
#print(persons[2])
#print(persons)

#sasha, pasha, tima, sema = persons

#sasha = persons[0]
#pasha = persons[1]
#tima = persons[2]
#sema = persons[3]

#for person in persons:
#    print(person)

#for i in range(1, 11):
#    print(i, end = ', ')
#print('\n')

#for i in [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]:
#    print(i, end = ', ')
#print('\n')

#for i in list([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
#    print(i, end = ', ')
#print('\n')

#list_a =list()
#list_b = []
#print(list_a)
#print(list_b)
#list_a.append(0)
#list_a.append(1)
#print(list_a)
#print(list_b)

#num = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]
#for i in num:
#    print(i, end = ', ')
#print('\n')

#i = 0
#while i < len(num):
#    print(num[i], end = ', ')
#    i +=1
#print('\n')

#def magic(count, list_num):
#    summa = 0
#    for i in list_num:
#        summa+=i**2
#    if summa%count ==0:
#        return('волшебство случается')
#    else:
#        return('никакого волшебства')

#list_num =[1,2,3]
#print(magic(2,list_num))
#print(magic(3,list_num))
        
#numbers = [2,4,6,8,10,3,5,7]
#print(numbers[2])
#print(numbers)
#for i in range(len(numbers)):
#    if i%2==0:
#        print(numbers[i], end =', ' )

#print('')        

#for i in range(len(numbers)):
#    if numbers[i] > 5:
#        print(numbers[i] )

#string = 'qwerty asdf zxcvw sdcxqwe  qw qw qw qe e wr et f c vz xc asf'
#summa = 0
#for i in string:
#    if i == 'w':
#        summa += 1

#print(f'В строке {string} \nсодержится {summa} раза буква W')

'''
На основании предоставленного отрывка текста определить 
3 наиболее часто встречаемых символа в ней. 
Пробелы нужно игнорировать (не учитывать при подсчете). 
Для выведения результатов вычислений требуется написать 
функцию top3(st). 
Итог работы функции представить в виде строки: 
«символ – количество раз, символ – количество раз…».
'''
from collections import Counter

#def top3(st):
#    counter_top3 = Counter(st.replace(' ', '')).most_common(5)
#    return ', '.join([f'{letter} - {cnt}' for letter, cnt in counter_top3])

message = 'qwerty asdf zxcvw sdcxqwe  qw qw qw qe e wr et f c vz xc asf'

def stop3(st):
    topLetters =  Counter(st.replace(' ', '')).most_common(3)
    result = ''
    for letter, count in topLetters:
        result += (f'{letter} - {count}, ')
    print(result)

stop3(message)

#написать функцию которая возвращает строку 
#из уникальных символов содержащихся в другой строке 
# которая передается через параметр
def get_unic_letters(text):
    result_text = ''
    for letter in text.replace(' ',''):
        if  result_text.find(letter) ==-1:
            result_text +=letter
    return result_text

#найти количество вхождений символа в строке
def get_count_enterence(letter,message):
    summa = 0
    for symbol in message:
        if symbol == letter:
            summa+=1
    return(summa)

# 
unic_message = get_unic_letters(message)
result = ''
for symbol in unic_message:
    result += f'{symbol} - {get_count_enterence(symbol, message)},' 
print(result)


