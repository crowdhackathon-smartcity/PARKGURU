package project.smartcity.com.smartcityapp.models;

/**
 * Created by dpapa on 12/5/2017.
 */

public enum  GeometryType {

    Polygon(1),
    Point(2),
    Line(3);

    private final int value;

    GeometryType(final int newValue) {
        value = newValue;
    }

    public int getValue() {
        return value;
    }
}
