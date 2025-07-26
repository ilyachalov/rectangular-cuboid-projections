// рисование прямоугольного параллелепипеда в прямоугольной диметрической проекции
//   x0, y0 - оконные координаты начала объемной системы координат
//            (невидимая вершина прямоугольного параллелепипеда)
//   sizeX, sizeY, sizeZ - размеры параллелепипеда по осям объемной системы координат
//   mathStrict - математически точные (true) или приведенные (false) коэффициенты
//                искажения
private void DrawRectCuboid_Dimetric(Graphics g, int x0, int y0, int sizeX, int sizeY, int sizeZ,
                                     bool mathStrict = false)
{
    // Предполагаем, что в параметры sizeX, sizeY и sizeZ переданы реальные размеры
    // фигуры (параллелепипеда). В математически точной прямоугольной диметрической
    // проекции эти размеры уменьшатся. Однако, в российском стандарте ГОСТ 2.317-2011
    // сказано, что в данной проекции, как правило, коэффициенты искажения округляют.

    // математически точные коэффициенты искажения
    double distCoefX = 0.94;
    double distCoefY = 0.47;
    double distCoefZ = 0.94;
    // приведенные (округленные) коэффициенты искажения
    // double rDistCoefX = 1.0;
    double rDistCoefY = 0.5;
    // double rDistCoefZ = 1.0;

    // применение коэффициентов искажения к размерам фигуры (параллелепипеда)
    int dSizeX, dSizeY, dSizeZ; // искаженные размеры фигуры
    if (mathStrict)
    {
        dSizeX = (int)(sizeX * distCoefX);
        dSizeY = (int)(sizeY * distCoefY);
        dSizeZ = (int)(sizeZ * distCoefZ);
    }
    else
    {
        dSizeX = sizeX;
        dSizeY = (int)(sizeY * rDistCoefY);
        dSizeZ = sizeZ;
    }

    // расчет синусов углов (градусы переведены в радианы)
    double sin7_10  = Math.Sin(Math.PI * (43 / 6) / 180.0);   // синус угла  7°10′
    double sin82_50 = Math.Sin(Math.PI * (497 / 6) / 180.0);  // синус угла 82°50′
    double sin41_25 = Math.Sin(Math.PI * (497 / 12) / 180.0); // синус угла 41°25′
    double sin48_35 = Math.Sin(Math.PI * (583 / 12) / 180.0); // синус угла 48°35′

    // семь видимых вершин прямоугольного параллелепипеда
    Point pX = new Point(x0 - (int)(sin82_50 * dSizeX), y0 + (int)(sin7_10 * dSizeX));
    Point pY = new Point(x0 + (int)(sin48_35 * dSizeY), y0 + (int)(sin41_25 * dSizeY));
    Point pXY = new Point(pX.X + (int)(sin48_35 * dSizeY), pX.Y + (int)(sin41_25 * dSizeY));
    Point pZ = new Point(x0, y0 - dSizeZ);
    Point pZX = new Point(pX.X, pX.Y - dSizeZ);
    Point pZY = new Point(pY.X, pY.Y - dSizeZ);
    Point pZXY = new Point(pXY.X, pXY.Y - dSizeZ);

    // три точки для рисования осей координат
    // (координаты этих точек вычисляются, исходя из приведенных коэффициентов
    // искажения, и не меняются при изменении флага mathStrict, чтобы не отвлекать
    // от изменения размеров самой фигуры)
    int axisAdd = 30; // насколько ось будет длиннее размера фигуры
    Point pAxisX = new Point(x0 - (int)(sin82_50 * (sizeX + axisAdd)),
                             y0 + (int)(sin7_10 * (sizeX + axisAdd)));
    Point pAxisY = new Point(x0 + (int)(sin48_35 * (sizeY + axisAdd) * rDistCoefY),
                             y0 + (int)(sin41_25 * (sizeY + axisAdd) * rDistCoefY));
    Point pAxisZ = new Point(x0, y0 - (sizeZ + axisAdd));

    // рисование осей координат
    Pen pen = new Pen(Color.Red, 1);
    g.DrawLine(pen, x0, y0, pAxisX.X, pAxisX.Y);
    g.DrawString("x", new Font("Verdana", 12), Brushes.Red, pAxisX.X, pAxisX.Y);
    g.DrawLine(pen, x0, y0, pAxisY.X, pAxisY.Y);
    g.DrawString("y", new Font("Verdana", 12), Brushes.Red, pAxisY.X, pAxisY.Y);
    g.DrawLine(pen, x0, y0, pAxisZ.X, pAxisZ.Y);
    g.DrawString("z", new Font("Verdana", 12), Brushes.Red, pAxisZ.X, pAxisZ.Y);

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