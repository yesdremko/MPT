import math

def power(a: float, b: float) -> float:
    return math.pow(a, b)

def main():
    try:
        a = float(input("Введіть основу (число): "))
        b = float(input("Введіть показник степеня: "))
        result = power(a, b)
        print(f"{a} в степені {b} = {result}")
    except ValueError:
        print("Помилка: введіть коректні числа.")
if __name__ == "__main__":
    main()
