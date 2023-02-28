# -*- coding: cp1251 -*-
#import sasha_dll

#kredit = sasha_dll.get_float_from_console('Введите сумму кредита')
#year_procent_stavka = sasha_dll.get_float_from_console('Введите годовую процентную ставку')
#year_period = sasha_dll.get_float_from_console('Введите срок кредита в годах')
#print(sasha_dll.calc_month_payment_annuitet(kredit, year_procent_stavka, year_period))


#from sasha_dll import get_float_from_console
#from sasha_dll import calc_month_payment_annuitet

#kredit = get_float_from_console('Введите сумму кредита')
#year_procent_stavka = get_float_from_console('Введите годовую процентную ставку')
#year_period = get_float_from_console('Введите срок кредита в годах')
#print(calc_month_payment_annuitet(kredit, year_procent_stavka, year_period))

from SDLL import *

kredit = get_float_from_console('Введите сумму кредита')
year_procent_stavka = get_float_from_console('Введите годовую процентную ставку')
year_period = get_float_from_console('Введите срок кредита в годах')
print(calc_month_payment_annuitet(kredit, year_procent_stavka, year_period))
