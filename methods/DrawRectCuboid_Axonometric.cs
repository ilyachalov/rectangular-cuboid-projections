// рисование прямоугольного параллелепипеда в прямоугольной аксонометрической проекции
//   x0, y0 - оконные координаты проекции начала объемной системы координат
//            (невидимая вершина прямоугольного параллелепипеда)
//   sizeX, sizeY, sizeZ - размеры параллелепипеда по осям объемной системы координат
//   theta, phi - углы поворота вокруг вертикальной оси (OZ) и одной из горизонтальных (OX)
private void DrawRectCuboid_Axonometric(Graphics g, int x0, int y0, int sizeX, int sizeY, int sizeZ,
    double theta, double phi)
{
    // координаты восьми вершин прямоугольного параллелепипеда в объемной системе координат
    Vector3 p0 = new Vector3(0, 0, 0);
    Vector3 pX = new Vector3(-sizeX, 0, 0);
    Vector3 pY = new Vector3(0, sizeY, 0);
    Vector3 pXY = new Vector3(-sizeX, sizeY, 0);
    Vector3 pZ = new Vector3(0, 0, sizeZ);
    Vector3 pXZ = new Vector3(-sizeX, 0, sizeZ);
    Vector3 pYZ = new Vector3(0, sizeY, sizeZ);
    Vector3 pXYZ = new Vector3(-sizeX, sizeY, sizeZ);
    // три точки для рисования собственной системы координат фигуры
    int axisAdd = 30; // насколько ось будет длиннее размера фигуры
    Vector3 pAxisX = new Vector3(-sizeX - axisAdd, 0, 0);
    Vector3 pAxisY = new Vector3(0, sizeY + axisAdd, 0);
    Vector3 pAxisZ = new Vector3(0, 0, sizeZ + axisAdd);

    // угол поворота
    //double psi = 45.0;           // в градусах
    //psi = Math.PI * psi / 180.0; // перевод в радианы
    //// матрица поворота прямоугольного параллелепипеда вокруг оси OY объемной системы координат
    //Matrix4x4 mRot1 = new Matrix4x4(
    //    (float)Math.Cos(psi), 0, (float)Math.Sin(psi), 0,
    //    0, 1, 0, 0,
    //    (float)-Math.Sin(psi), 0, (float)Math.Cos(psi), 0,
    //    0, 0, 0, 1
    //);

    // угол поворота
    phi = Math.PI * phi / 180.0; // перевод в радианы
    // матрица поворота прямоугольного параллелепипеда вокруг оси OX объемной системы координат
    Matrix4x4 mRot2 = new Matrix4x4(
        1, 0, 0, 0,
        0, (float)Math.Cos(phi), (float)-Math.Sin(phi), 0,
        0, (float)Math.Sin(phi), (float)Math.Cos(phi), 0,
        0, 0, 0, 1
    );

    // угол поворота
    theta = Math.PI * theta / 180.0; // перевод в радианы
    // матрица поворота прямоугольного параллелепипеда вокруг оси OZ объемной системы координат
    Matrix4x4 mRot3 = new Matrix4x4(
        (float)Math.Cos(theta), (float)-Math.Sin(theta), 0, 0,
        (float)Math.Sin(theta), (float)Math.Cos(theta), 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1
    );

    // расчет коэффициентов искажения по осям
    // koef1, koef2 и koef3 - элементы класса TextBox на форме, определены вне данного метода
    Matrix4x4 m = mRot3 * mRot2;
    koef1.Text = Math.Sqrt(m.M11 * m.M11 + m.M12 * m.M12).ToString();
    koef2.Text = Math.Sqrt(m.M21 * m.M21 + m.M22 * m.M22).ToString();
    koef3.Text = Math.Sqrt(m.M31 * m.M31 + m.M32 * m.M32).ToString();

    // умножение вершин на матрицу поворота вокруг оси OZ
    p0 = Vector3.Transform(p0, mRot3);
    pX = Vector3.Transform(pX, mRot3);
    pY = Vector3.Transform(pY, mRot3);
    pXY = Vector3.Transform(pXY, mRot3);
    pZ = Vector3.Transform(pZ, mRot3);
    pXZ = Vector3.Transform(pXZ, mRot3);
    pYZ = Vector3.Transform(pYZ, mRot3);
    pXYZ = Vector3.Transform(pXYZ, mRot3);
    // умножение точек осей собственной системы координат фигуры
    pAxisX = Vector3.Transform(pAxisX, mRot3);
    pAxisY = Vector3.Transform(pAxisY, mRot3);
    pAxisZ = Vector3.Transform(pAxisZ, mRot3);

    // умножение вершин на матрицу поворота вокруг оси OX
    p0 = Vector3.Transform(p0, mRot2);
    pX = Vector3.Transform(pX, mRot2);
    pY = Vector3.Transform(pY, mRot2);
    pXY = Vector3.Transform(pXY, mRot2);
    pZ = Vector3.Transform(pZ, mRot2);
    pXZ = Vector3.Transform(pXZ, mRot2);
    pYZ = Vector3.Transform(pYZ, mRot2);
    pXYZ = Vector3.Transform(pXYZ, mRot2);
    // умножение точек осей собственной системы координат фигуры
    pAxisX = Vector3.Transform(pAxisX, mRot2);
    pAxisY = Vector3.Transform(pAxisY, mRot2);
    pAxisZ = Vector3.Transform(pAxisZ, mRot2);

    // получение двумерных координат (проецирование на плоскость)
    Point p2D0 = new Point((int)p0.X + x0, (int)p0.Y + y0);
    Point p2DX = new Point((int)pX.X + x0, (int)pX.Y + y0);
    Point p2DY = new Point((int)pY.X + x0, (int)pY.Y + y0);
    Point p2DXY = new Point((int)pXY.X + x0, (int)pXY.Y + y0);
    Point p2DZ = new Point((int)pZ.X + x0, (int)pZ.Y + y0);
    Point p2DXZ = new Point((int)pXZ.X + x0, (int)pXZ.Y + y0);
    Point p2DYZ = new Point((int)pYZ.X + x0, (int)pYZ.Y + y0);
    Point p2DXYZ = new Point((int)pXYZ.X + x0, (int)pXYZ.Y + y0);
    // получение двумерных координат точек осей собственной системы координат фигуры
    Point p2DaxisX = new Point((int)pAxisX.X + x0, (int)pAxisX.Y + y0);
    Point p2DaxisY = new Point((int)pAxisY.X + x0, (int)pAxisY.Y + y0);
    Point p2DaxisZ = new Point((int)pAxisZ.X + x0, (int)pAxisZ.Y + y0);

    // рисование осей координат
    Pen pen = new Pen(Color.Red, 1);
    g.DrawLine(pen, x0, y0, p2DaxisX.X, p2DaxisX.Y);
    g.DrawString("x", new Font("Verdana", 12), Brushes.Red, p2DaxisX.X, p2DaxisX.Y);
    g.DrawLine(pen, x0, y0, p2DaxisY.X, p2DaxisY.Y);
    g.DrawString("y", new Font("Verdana", 12), Brushes.Red, p2DaxisY.X, p2DaxisY.Y);
    g.DrawLine(pen, x0, y0, p2DaxisZ.X, p2DaxisZ.Y);
    g.DrawString("z", new Font("Verdana", 12), Brushes.Red, p2DaxisZ.X, p2DaxisZ.Y);

    // рисование первой грани
    Point[] points = [p2DX, p2DXZ, p2DXYZ, p2DXY];
    SolidBrush sBrush = new SolidBrush(Color.FromArgb(143, 143, 154));
    g.FillPolygon(sBrush, points);
    // рисование второй грани
    points = [p2DXZ, p2DZ, p2DYZ, p2DXYZ];
    sBrush = new SolidBrush(Color.FromArgb(176, 176, 189));
    g.FillPolygon(sBrush, points);
    // рисование третьей грани
    points = [p2DXY, p2DXYZ, p2DYZ, p2DY];
    sBrush = new SolidBrush(Color.FromArgb(89, 89, 95));
    g.FillPolygon(sBrush, points);
}