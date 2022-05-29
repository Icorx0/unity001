using System;

public class MeshGenerator {
    public static void Main(string[] args) {
        sortPoints3D();
    }



    public static void sortPoints3D() {
        // Creates vector using constructor
        Plane plane1 = new Plane(
            new Vector3(0.0, 0.0, 0.0),
            new Vector3(1.0, 0.0, 1.0),
            new Vector3(1.0, 1.0, 1.0)
        );
        Plane plane2 = new Plane(
            new Vector3(1.0, 0.0, 1.0),
            new Vector3(1.0, 1.0, 1.0),
            new Vector3(1.0, 0.0, 0.0)
        );
        Vector3 refPoint = new Vector3(0.0,0.0,6.0);

        Console.WriteLine("Angle between planes: " + Plane.angleBetweenPlanes(plane1, plane2));
    }
}

public class Plane {
    Vector3 A, B, C;

    public Plane(Vector3 point1, Vector3 point2, Vector3 point3) {
        A = point1;
        B = point2;
        C = point3;
    }
    public Plane(Vector3[] points) {
        A = points[0];
        B = points[1];
        C = points[2];
    }

    public override String ToString() {
        return "  " + A.ToString() + "\n  " + B.ToString() + "\n  " + C.ToString();
    }

    public Vector3 getNormal() {
        Vector3 AB = Vector3.substraction(A,B);
        Vector3 CB = Vector3.substraction(C,B);
        return Vector3.crossProduct(AB,CB);
    }

    public Boolean isAbovePlane(Vector3 point) {
        Vector3 normal = getNormal();
        Vector3 PA = Vector3.substraction(point, A);
        double result = Vector3.dotProduct(PA, normal);
        if(result > 0) 
            return true;
        return false;
    }

    public static double angleBetweenPlanes(Plane plane1, Plane plane2) {
        Vector3 normal1 = plane1.getNormal();
        Vector3 normal2 = plane2.getNormal();
        return Vector3.angleBetweenVectors(normal1, normal2);
    }    
}

public class Vector3 {
    private double x,y,z;
    public Vector3(double x, double y, double z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double getX() {return x;}
    public double getY() {return y;}
    public double getZ() {return z;}

    public double getModule() {
        return Math.Sqrt(Math.Pow(x,2.0) + Math.Pow(y,2.0) + Math.Pow(z,2.0));
    }

    public override String ToString() {
        return "(" + x.ToString() + "," + y.ToString() + "," + z.ToString() + ")";
    }

    /** In radians*/
    public static double angleBetweenVectors(Vector3 vector1, Vector3 vector2) {
        double costheta = dotProduct(vector1, vector2) / (vector1.getModule() * vector2.getModule());
        return Math.Acos(costheta);
    }

    public static Vector3 substraction(Vector3 vector1, Vector3 vector2) {
        return new Vector3(vector1.getX() - vector2.getX(), vector1.getY() - vector2.getY(), vector1.getZ() - vector2.getZ());
    }

    public static double dotProduct(Vector3 vector1, Vector3 vector2) {
        return vector1.getX()*vector2.getX() + vector1.getY()*vector2.getY() + vector1.getZ()*vector2.getZ();
    }

    public static Vector3 crossProduct(Vector3 vector1, Vector3 vector2) {
        double x = vector1.getY()*vector2.getZ() - vector1.getZ()*vector2.getY();
        double y = vector1.getZ()*vector2.getX() - vector1.getX()*vector2.getZ();
        double z = vector1.getX()*vector2.getY() - vector1.getY()*vector2.getX();
        return new Vector3(x,y,z);
    }
}