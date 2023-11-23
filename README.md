# ConvertTypesUtil

Преобразование строкового значения чисел с дробной частью в число типа `decimal`.
</br>Разделитель целой и дробной части определяется автоматически.

Пример использования:

```C#
string str1="123,123"
string str1="123.123"

decimal out1=str1.ToDecimal(); // 123.123
decimal out2=str2.ToDecimal(); // 123.123
```