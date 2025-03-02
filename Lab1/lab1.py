def func(num):
    if not isinstance(num, (int, float)):
        return print("я тіко циферки панімаю")
    
    if not isinstance(num, int):
        return print("я тіко ЦІЛІ циферки панімаю")
    
    if num < 0:
        return print("від'ємні числа я не панімаю")
    
    print("n =", num)
    res = pow(num, num) - num
    return print("n^n-n =", res)

number = 3
func(number)