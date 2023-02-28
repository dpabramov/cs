# -*- coding: cp1251 -*-
#import random
def get_float_from_console(prefix = "������� ��������"):
    while True:
        try:
            value = float(input(f'{prefix}: '))
            return value
        except:
            print('������������ ����\n��������� �������')



#random_value = random.randint(0,6)
#print('����� �������� � ����. � ������� ����� �� 0 �� 5\n������� ���.')



#while True:
#    inputed_value = get_int_from_console()
#    if inputed_value == random_value:
#        print('�� ������, �������')
#        break
#    else:
#        print('�� �����, ������� �������')

def calc_month_payment_annuitet(kredit,year_procent_stavka,year_period):
    month_stavka = year_procent_stavka /(100 * 12)
    month_period = year_period * 12
    month_pay = kredit * month_stavka / (1 - (1 + month_stavka)**(- month_period))
    return(round(month_pay,2))

#pereplata = month_pay * month_period - kredit
#print('��������� ��������: ',round(pereplata,2))
kredit = get_float_from_console('������� ����� �������')
year_procent_stavka = get_float_from_console('������� ������� ���������� ������')
year_period = get_float_from_console('������� ���� ������� � �����')
print(calc_month_payment_annuitet(kredit, year_procent_stavka, year_period))



      
