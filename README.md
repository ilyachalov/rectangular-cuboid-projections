# rectangular-cuboid-projections
Приложение, рисующее разные проекции прямоугольного параллелепипеда.

Для рисования используются методы объекта [класса Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) платформы «.NET».

## Проекции

Пока что написал код для трех методов, рисующих проекции прямоугольного параллелепипеда:
- [прямоугольная изометрическая](https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/methods/DrawRectCuboid_Isometric.cs) (реализован в версиях 1 и 2);
- [прямоугольная диметрическая](https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/methods/DrawRectCuboid_Dimetric.cs) (реализован в версии 2);
- [прямоугольная аксонометрическая](https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/methods/DrawRectCuboid_Axonometric.cs) (реализован в версии 3).

Метод для рисования прямоугольной аксонометрической проекции может рисовать любой из видов прямоугольной аксонометрической проекции: изометрическая, диметрическая или триметрическая. Пользователь может менять вид проекции, переключая галочки или меняя два угла поворота прямоугольного параллелепипеда вокруг двух осей базовой системы координат.

В моем блоге есть подробные посты с пояснениями: [первый](https://ilyachalov.livejournal.com/375970.html), [второй](https://ilyachalov.livejournal.com/377384.html), [третий](https://ilyachalov.livejournal.com/378294.html).

## Что получается, иллюстрации

### Версия 2

![](https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/illustrations/cuboid-app-v2-ris1.png)

### Версия 1

<img src="https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/illustrations/cuboid-app-v1-ris4.png" width="350"> <img src="https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/illustrations/cuboid-app-v1-ris1.png" width="350"> <img src="https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/illustrations/cuboid-app-v1-ris2.png" width="350"> <img src="https://github.com/ilyachalov/rectangular-cuboid-projections/blob/main/illustrations/cuboid-app-v1-ris3.png" width="350">
