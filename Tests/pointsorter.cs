using System;

public class MeshGenerator {
    public static void Main(string[] args) {
        createPoints();
    }

    public static void createPoints() {
        // Creates vector using constructor
        Vector2[] points = {
            new Vector2(1.0, 1.0),
            new Vector2(2.0, 2.0),
            new Vector2(4.0, 2.0)
        };

        Console.WriteLine("Points inside collection");
        for(int i = 0; i < points.Length; i++) {
            Console.WriteLine(points[i].toString());
        }
    }

    public static int[] clockwisePoints() {
        
    }
}

public class Triangle{
    Vector3 point1, point2, point3;

    public Triangle(Vector3 point1, Vector3 point2, Vector3 point3) {
        this.point1 = point1;
        this.point2 = point2;
        this.point3 = point3;
    }
}

public class Mesh {
    Triangle[] triangles = {};

    public void setMesh(Triangle[] triangles) {
        this.triangles = triangles;
    }
}

public class Vector3 {
    double x,y,z;
    public Vector3(double x, double y, double z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    public String toString() {
        String s = "(";
        s += x.ToString("%.2f");
        s += ",";
        s += y.ToString("%.2f");
        s += ",";
        s += z.ToString("%.2f");
        s += ")";
        return s;
    }
}
public class Vector2 {
    double x,y;
    public Vector2(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    public String toString() {
        String s = "(";
        s += x.ToString("%.2f");
        s += ",";
        s += y.ToString("%.2f");
        s += ")";
        return s;
    }
}