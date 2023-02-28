# -*- coding: cp1251 -*-

def calc_month_payment_annuitet(kredit,year_procent_stavka,year_period):
    month_stavka = year_procent_stavka /(100 * 12)
    month_period = year_period * 12
    month_pay = kredit * month_stavka / (1 - (1 + month_stavka)**(- month_period))
    return(round(month_pay,2))

def get_float_from_console(prefix = "введите float-значение"):
    while True:
        try:
            value = float(input(f'{prefix}: '))
            return value
        except:
            print('Некорректный ввод\nповторите попутку')

def get_float_from_console(prefix = "введите значение"):
    value = float(input(f'{prefix}: '))
    return value  
    
def get_square_triangle_by_hight(hight, side_a):
    square = hight * side_a / 2
    return square

def get_square_triangle_by_sinus(side_a, side_b, angle_ab):
    square = side_a * side_b * math.sin(angle_ab)/2
    return(square)

def get_radian_from_grad(gradus):
    return gradus * math.pi /180

def get_square_geron(a,b,c):
    p = (a + b + c)/2
    square = math.sqrt(p*(p-a)*(p-b)*(p-c))
    return(square)

def get_square_radius_opis(radius, a,b,c):
    square = (a*b*c)/(4*radius)
    return square

# функция возвращает температуру в градусах цельсия по 
#по температуре переданной в фапенгейтах 
def get_celsium(fareng):
    cel=round(5/9*(fareng-32),1)
    return cel