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

#�������� ������� ������������ ����������� � �������� ������� �� 
#�� ����������� ���������� � ����������� ���������� ����� ��������
# ������ ������������� �-�
#def get_celsium(fareng):
#    cel=round(5/9*(fareng-32),1)
#    return cel

#def main():
#    far=float(input('������� ����������� � �����������: '))
#    cel=get_celsium(far)
#    print('����������� � ��������: ', cel)
    
#main()



#def get_square_by_diametr(diametr):
#    square=3.14*(diametr**2/4)
#    return square

#def get_square_by_radius(radius):
#    square=3.14*(radius**2)
#    return square

#radius=float(input('������� ������ �����: '))
#square = get_square_by_radius(radius)
#print(f'������� �����: {square}')



#diametr=float(input('������� ������ �����: '))
#square = get_square_by_diametr(diametr)
#print(f'������� �����: {square}')

import math


def get_float_from_console(prefix = "������� ��������"):
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


#a = get_float_from_console('������� ������ ������� ������������')
#b = get_float_from_console('������� ������ ������� ������������')
#c = get_float_from_console('������� ������ ������� ������������')
#print('������� ������������: ', get_square_geron(a,b,c))

#side_a = get_float_from_console('������� ������ ������� ������������')
#side_b = get_float_from_console('������� ������ ������� ������������')
#side_c = get_float_from_console('������� ������ ������� ������������')
#radius = get_float_from_console('������� ������ �������� ����������')
#print('������� ������������: ', get_square_radius_opis(radius, side_a, side_b, side_c))

#hight = get_float_from_console("������� ������")
#side = get_float_from_console("������� ������� ������������")
#square = get_square_triangle_by_hight(hight,side)
#print('������� ������������: ',square)

#side_a = get_float_from_console('�������  ������ ������� ������������')
#side_b = get_float_from_console('������� ������ ������� ������������')
#angle_ab = get_float_from_console('������� ���� ������������ � ��������')
#angle_rad = get_radian_from_grad(angle_ab)
#square_3angle = get_square_triangle_by_sinus(side_a, side_b, angle_rad)
#print('������� ������������ �����: ', square_3angle )

def calc_square_triangle():
    side_a = get_float_from_console('������� ������ ������� ������������')
    side_b = get_float_from_console('������� ������ ������� ������������')
    side_c = get_float_from_console('������� ������ ������� ������������')
    radius = get_float_from_console('������� ������ �������� ����������')
    print('������� ������������: ', get_square_radius_opis(radius, side_a, side_b, side_c))

calc_square_triangle()











