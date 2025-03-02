import unittest
from unittest.mock import patch
from lab1 import func

class TestFunc(unittest.TestCase):
    @patch('builtins.print')
    def test_not_a_number(self, mock_print):
        func("text")
        mock_print.assert_called_with("я тіко циферки панімаю")
    
    @patch('builtins.print')
    def test_not_an_integer(self, mock_print):
        func(3.5)
        mock_print.assert_called_with("я тіко ЦІЛІ циферки панімаю")
    
    @patch('builtins.print')
    def test_negative_number(self, mock_print):
        func(-5)
        mock_print.assert_called_with("від'ємні числа я не панімаю")
    
    @patch('builtins.print')
    def test_positive_number(self, mock_print):
        func(2)
        mock_print.assert_any_call("n =", 2)
        mock_print.assert_any_call("n^n-n =", 2**2 - 2)