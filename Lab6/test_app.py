import unittest
from app import power

class TestPowerFunction(unittest.TestCase):
    def test_positive(self):
        self.assertEqual(power(2, 3), 8)

    def test_zero_exponent(self):
        self.assertEqual(power(2, 0), 1)

    def test_negative_exponent(self):
        self.assertAlmostEqual(power(2, -2), 0.25)

    def test_float_values(self):
        self.assertAlmostEqual(power(2.5, 2), 6.25)

    def test_power_of_zero(self):
        self.assertEqual(power(0, 5), 0)

if __name__ == "__main__":
    unittest.main()