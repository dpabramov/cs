 # -*- coding: cp1251 -*-
#temp = "hellow"

#for i in temp:
#    print(i, end = '   ')
 
#print('')

#for i in range(5, 10):
#    print(i, end = '   ')

#a = 0
#while a<10:
#    print(a)
#    a+=1
#else: 
#    print(a)

#def simple_calc():
#    a = 12 + 48
#    print(a)
#    print(a**2)
#    print(a*a*a)

#simple_calc()


#def get_average_grand_child(pasha_age, sasha_age, tima_age, sema_age, platon_age):
#    return (pasha_age +sasha_age + tima_age +sema_age + platon_age)/5

#def main():
#    pasha = int(input("age pasha: "))
#    sasha = int(input("age sasha: "))
#    tima = int(input("age tima: "))
#    sema = int(input("age sema: "))
#    platon = int(input("age platon: "))
#    avg = get_average_grand_child(pasha,sasha, tima, sema, platon)
#    print(avg)

#main()

#Написать функцию возвращающую температуру в градусах цельсия по 
#по температуре переданной в фапенгейтах переданной через параметр
# Пример использования ф-и
#def get_celsium(fareng):
#    cel=round(5/9*(fareng-32),1)
#    return cel

#def main():
#    far=float(input('введите температуру в фаренгейтах: '))
#    cel=get_celsium(far)
#    print('температура в цельсиях: ', cel)
    
#main()



#def get_square_by_diametr(diametr):
#    square=3.14*(diametr**2/4)
#    return square

#def get_square_by_radius(radius):
#    square=3.14*(radius**2)
#    return square

#radius=float(input('введите радиус круга: '))
#square = get_square_by_radius(radius)
#print(f'площадь круга: {square}')



#diametr=float(input('введите радиус круга: '))
#square = get_square_by_diametr(diametr)
#print(f'площадь круга: {square}')

import math


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


#a = get_float_from_console('введите первую сторону треугольника')
#b = get_float_from_console('введите вторую сторону треугольника')
#c = get_float_from_console('введите третью сторону треугольника')
#print('площадь треугольника: ', get_square_geron(a,b,c))

#side_a = get_float_from_console('введите первую сторону треугольника')
#side_b = get_float_from_console('введите вторую сторону треугольника')
#side_c = get_float_from_console('введите третью сторону треугольника')
#radius = get_float_from_console('введите радиус описаной окружности')
#print('площадь треугольника: ', get_square_radius_opis(radius, side_a, side_b, side_c))

#hight = get_float_from_console("Введите высоту")
#side = get_float_from_console("Введите сторону треугольника")
#square = get_square_triangle_by_hight(hight,side)
#print('площадь треугольника: ',square)

#side_a = get_float_from_console('введите  первую сторону треугольника')
#side_b = get_float_from_console('введите вторую сторону треугольника')
#angle_ab = get_float_from_console('введите угол треугольника в градусах')
#angle_rad = get_radian_from_grad(angle_ab)
#square_3angle = get_square_triangle_by_sinus(side_a, side_b, angle_rad)
#print('площадь треугольника равна: ', square_3angle )

def calc_square_triangle():
    side_a = get_float_from_console('введите первую сторону треугольника')
    side_b = get_float_from_console('введите вторую сторону треугольника')
    side_c = get_float_from_console('введите третью сторону треугольника')
    radius = get_float_from_console('введите радиус описаной окружности')
    print('площадь треугольника: ', get_square_radius_opis(radius, side_a, side_b, side_c))

calc_square_triangle()











