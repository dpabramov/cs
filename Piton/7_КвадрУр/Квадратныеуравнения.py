
#print('a = 2\u00B2')
#print(u'\u221a')
print('\u221a')

import math
print("ax\u00B2 + bx + c = 0")
a = float(input("a = "))
b = float(input("b = "))
c = float(input("c = "))
 
discr = b ** 2 - 4 * a * c
print('d=b**2-4ac')
if discr > 0:
    x1 = (-b + math.sqrt(discr)) / (2 * a)
    x2 = (-b - math.sqrt(discr)) / (2 * a)
    print('(-b \u00B1 \u221ad) / (2 * a)')
    print('x1=',x1,'    x2=',x2)
elif discr == 0:
    x = -b / (2 * a)
    print('x = -b / (2 * a)')
    print('x=',x)
else:
    print('no korney')