def func(num):
    if num < 0:
        return print("Нефіг вводити від'ємні числа")
    print("n =", num)
    res = pow(num, num) - num
    return print("n^n-n =", res)

number = 3

func(number)