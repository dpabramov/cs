
# -*- coding: cp1251 -*-
#def search_substr(subst, st):
#    if subst.upper() in st.upper() :
#        return('есть контакт')
#    else:
#        return('мимо')

#subs = 'QWERT'
#sts = 'qwert zxcvb jkluhym'
#val = search_substr(subs,sts)
#print(val)

#subs2 = 'asdF'
#print(search_substr(subs2,sts))

#from sys import getsizeof
#count = 3**9090001
#print(f'число {count} занимает {getsizeof(count)/(1024*1024)} МБ') 

#a = 4**4**4
#print(a)


#def pos_add(a, b):
#    return(abs(a+b))

#a = 3
#b = -5
#c = 2
#print(f'abs({a}+{b})={pos_add(a,b)}')
#print(f'abs({a}+{c})={pos_add(a,c)}' )


#def  foo(a):
#   #return (a // (-11), a % (-11))
#    return divmod(a, -11)

#print(foo(22))
#print(foo(23))


#def num_sum(a):
#    if isinstance(a,int) and not isinstance(a, bool):
#        a_to_str = str(abs(a))
#        summa = 0
#        for i in a_to_str:
#            summa  += int(i)
#        return summa
#    else:
#        return('это не целое число')


#print(num_sum(145))
#print(num_sum(145.1))
#print(num_sum('cnhjrf'))
#print(num_sum(True))
#print(num_sum(-145))

#def get_summa(number,value):
#    i=0
#    summa= 0
#    while value > i:
#        i+=1
#    while value <i < number:
#        summa += i
#        (i)+=1
#    return(summa)

#number = 5
#value = 2
#print(get_summa(number,value))

#def get_summa(finish = 10, start = 0):
#    i = start
#    summa = 0
#    while  i < finish:
#        summa += i
#        i +=1
#    return(summa)

#value1 = 6
#value2 = 2
#print(get_summa(value1, value2))
#print(get_summa(value1))
#print(get_summa())

#def get_summa(finish, start = 0):
#    summa = 0
#    for i in range(start, finish):
#        summa += i
#    return summa

#print(get_summa(5,1))   
#print(get_summa(5))
#print(get_summa(101,1))

def sasha_len(text):
    count = 0
    for i in text:
        count += 1
    return(count)

def get_substring(text, index_finish, index_start = 0):
    res_sub = ''
    for i in range(index_start,index_finish):
        res_sub += text[i]
    return(res_sub)

def get_count_words_text(text, spliter=' '):
    splited_text = text.split(spliter)
    return(len(splited_text))

def sasha_replace(text, old_substring, new_substring):
    old_index = text.find(old_substring)
    first = get_substring(text, old_index)
    start_ind = old_index + len(old_substring)
    end_index = len(text)
    second = get_substring(text,end_index, start_ind)
    result = first + new_substring + second
    return result





#message = ('На основании предоставленного отрывка текста определить 3 наиболее часто встречаемых символа в ней. ' 
#'Пробелы нужно игнорировать (не учитывать при подсчете)')
#count = 0


#splited_text = message.split(' ')
#print(len(splited_text))
#print(sasha_len(splited_text))
#print(sasha_len(text))
#print(len(text))
#print(text[1])
#print(get_substring(text,23,0))

#print(get_count_words_text(message, 'о'))

#print(message.find('основании'))

#print(message)
#print(sasha_replace(message, 'отрывка', 'куска'))

#print(message.replace('отрывка','куска', 1))

def is_even(number, value): 
    if number % value == 0:
        return(True)
    else:
        return(False)

print(is_even(15,3))
print(is_even(13,3))

def is_range(number, range_start,range_finish):
    if number in range(range_start, range_finish):
        return(True)
    else:
        return(False)

#print(is_range(55,1,100))
#print(is_range(55,1,53))
#summa = 0

#for i in range(1,101):
#    summa += i
#print(summa)

message = ('На основании предоставленного отрывка текста определить 3 наиболее часто встречаемых символа в ней. ' 
    'Пробелы нужно игнорировать (не учитывать при подсчете)')


#print(len(message))
#summa = 0
#for i in message:
#    summa += 1
#print(summa)
result = ''
#for i in range(10,21):
#    result += message[i]
#print(result)

def get_substring(message, range_1, range_2):
    result = ''
    for i in range( range_1, range_2):
        result+=message[i]
    return(result)

print(get_substring(message,2,20))



    



