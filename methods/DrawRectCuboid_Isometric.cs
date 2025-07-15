// рисование прямоугольного параллелепипеда в прямоугольной изометрической проекции
//   x0, y0 - оконные координаты начала объемной системы координат
//            (невидимая вершина прямоугольного параллелепипеда)
//   sizeX, sizeY, sizeZ - размеры параллелепипеда по осям объемной системы координат
void DrawRectCuboid_Isometric(Graphics g, int x0, int y0, int sizeX, int sizeY, int sizeZ)
{
    // Предполагаем, что в параметры sizeX, sizeY и sizeZ переданы реальные размеры
    // фигуры (параллелепипеда). При этом в математически точной прямоугольной
    // изометрической проекции эти размеры уменьшатся. Правильные размеры можно
    // получить умножением на коэффциент искажения, примерно равный 0,82. Однако,
    // в российском стандарте ГОСТ 2.317-2011 сказано, что данную проекцию, как
    // правило, выполняют без искажения, то есть реальные размеры фигуры сохраняют.
    // Если нужна математически точная проекция, три нижележащие строки следует
    // раскомментировать.
    // sizeX = (int)(sizeX * 0.82);
    // sizeY = (int)(sizeY * 0.82);
    // sizeZ = (int)(sizeZ * 0.82);

    // расчет синусов углов (градусы переведены в радианы)
    double sin60 = Math.Sin(Math.PI * 60.0 / 180.0);
    double sin30 = Math.Sin(Math.PI * 30.0 / 180.0);

    // рисование осей координат
    int sizeAxis = new[] { sizeX, sizeY, sizeZ }.Max() + 30;
    Pen pen = new Pen(Color.Red, 1);
    g.DrawLine(pen, x0, y0, x0, y0 - sizeAxis);
    g.DrawString("z", new Font("Verdana", 12), Brushes.Red, x0, y0 - sizeAxis);
    g.DrawLine(pen, x0, y0, x0 - (int)(sin60 * sizeAxis), y0 + (int)(sin30 * sizeAxis));
    g.DrawString("x", new Font("Verdana", 12), Brushes.Red, x0 - (int)(sin60 * sizeAxis), y0 + (int)(sin30 * sizeAxis));
    g.DrawLine(pen, x0, y0, x0 + (int)(sin60 * sizeAxis), y0 + (int)(sin30 * sizeAxis));
    g.DrawString("y", new Font("Verdana", 12), Brushes.Red, x0 + (int)(sin60 * sizeAxis), y0 + (int)(sin30 * sizeAxis));

    // семь видимых вершин прямоугольного параллелепипеда
    Point pX = new Point(x0 - (int)(sin60 * sizeX), y0 + (int)(sin30 * sizeX));
    Point pY = new Point(x0 + (int)(sin60 * sizeY), y0 + (int)(sin30 * sizeY));
    Point pXY = new Point(pX.X + (int)(sin60 * sizeY), pX.Y + (int)(sin30 * sizeY));
    Point pZ = new Point(x0, y0 - sizeZ);
    Point pZX = new Point(pX.X, pX.Y - sizeZ);
    Point pZY = new Point(pY.X, pY.Y - sizeZ);
    Point pZXY = new Point(pXY.X, pXY.Y - sizeZ);

    // рисование первой грани
    Point[] points = [pX, pZX, pZXY, pXY];
    SolidBrush sBrush = new SolidBrush(Color.FromArgb(143, 143, 154));
    g.FillPolygon(sBrush, points);
    // рисование второй грани
    points = [pZX, pZ, pZY, pZXY];
    sBrush = new SolidBrush(Color.FromArgb(176, 176, 189));
    g.FillPolygon(sBrush, points);
    // рисование третьей грани
    points = [pXY, pZXY, pZY, pY];
    sBrush = new SolidBrush(Color.FromArgb(89, 89, 95));
    g.FillPolygon(sBrush, points);
}
